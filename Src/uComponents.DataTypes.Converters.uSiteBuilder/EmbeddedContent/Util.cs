using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Vega.USiteBuilder;

namespace uComponents.DataTypes.Converters.uSiteBuilder.EmbeddedContent
{
    public static class Util
    {
        #region Public Methods

        public static List<T> GetMappedList<T>(XDocument embeddedContentValueDoc) where T : new()
        {
            if (EmbeddedContentTypesAliases.Count == 0)
            {
                lock (Lock)
                {
                    if (EmbeddedContentTypesAliases.Count == 0)
                    {
                        var embeddedContentTypes = AppDomain.CurrentDomain.GetAssemblies()
                            .Select(a => a.GetTypes().Where(t => GetEmbeddedContentAttribute(t) != null))
                            .SelectMany(types => types);

                        foreach (var type in embeddedContentTypes)
                        {
                            EmbeddedContentTypesAliases.Add(type, GetPropertyAliases(type));
                        }
                    }
                }
            }
            var mappedList = (List<T>)Activator.CreateInstance(typeof(List<T>));

            if (!EmbeddedContentTypesAliases.ContainsKey(typeof (T))) return mappedList;

            var data = embeddedContentValueDoc.Root;
            if (data == null) return mappedList;

            var itemElements = data.Elements("item");

            foreach (var itemElement in itemElements)
            {
                var objToMap = new T();

                foreach (var alias in EmbeddedContentTypesAliases[typeof(T)])
                {
                    var element = itemElement.Element(alias);
                    if (element == null)
                    {
                        continue;
                    }
                    var objProp = objToMap.GetType().GetProperty(alias, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    var value = ConvertValue(objProp.PropertyType, element.Value);
                    if (value == null)
                    {
                        continue;
                    }
                    objProp.SetValue(objToMap, value, null);
                }
                mappedList.Add(objToMap);
            }

            return mappedList;
        }

        public static string GetEmbeddedContentValue<T>(List<T> list) where T : DataTypeBase
        {
            var retVal = new StringBuilder("<data>");
            if (list == null) return retVal.Append("</data>").ToString();

            var props = typeof(T).GetProperties();
            var indexer = 1;
            foreach (var item in list)
            {
                retVal.AppendFormat("<item id=\"{0}\">", indexer);
                indexer++;
                foreach (var propertyInfo in props)
                {
                    var value = ConvertValue(propertyInfo.PropertyType, propertyInfo.GetValue(item, null).ToString());
                    retVal.AppendFormat("<{0}>{1}</{0}>", propertyInfo.Name, value);
                }
                retVal.Append("</item>");
            }
            return retVal.Append("</data>").ToString();
        }

        public static int BoolToInt(bool value)
        {
            return value ? 1 : 0;
        }

        public static DataTypePrevalue[] GetEmbeddedContentPrevalues(this DataTypeBase dataType)
        {
            var eca = GetEmbeddedContentAttribute(dataType.GetType());
            if (eca == null)
            {
                return new DataTypePrevalue[] { };
            }

            var id = 1;
            var value = new StringBuilder();
            foreach (var attribute in dataType.GetType().GetProperties().Select(GetEmbeddedContentPropertyAttribute).Where(attribute => attribute != null))
            {
                attribute.Id = id;
                value.Append(attribute.Value);
                id++;
            }

            value.AppendFormat("||showLabel:{0};maxCount:{1};showType={2},showDescription={3},showTitle={4},showRequired={5},showValidation={6}",
                BoolToInt(eca.ShowLabel),
                eca.MaxCount,
                BoolToInt(eca.ShowType),
                BoolToInt(eca.ShowDescription),
                BoolToInt(eca.ShowTitle),
                BoolToInt(eca.ShowRequired),
                BoolToInt(eca.ShowValidation));

            return new[] { new DataTypePrevalue("myCustomValue", value.ToString()) };
        }

        /// <summary>
        /// Gets a camel case representation of the specified string.
        /// Removes spaces and lowercases the first letter.
        /// Uppercase values are determined by the spaces in the specified string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetCamelCase(string value)
        {
            var values = value.Split(new[] { ' ' }).ToList();

            var retVal = "";
            foreach (var val in values)
            {
                if (val == values.First())
                {
                    retVal += val.ToLower();
                }
                else
                {
                    retVal += val.Substring(0, 1).ToUpper() + val.Substring(1, val.Length - 1).ToLower();
                }
            }

            return retVal;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Convert an XML string to an XDocument for Embedded Content
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        internal static XDocument GetEmbeddedContentXDocument(string strValue)
        {
            XDocument xDoc;

            if (String.IsNullOrEmpty(strValue))
            {
                xDoc = XDocument.Parse("<data></data>");
            }
            else if (!strValue.StartsWith("<data>") || !strValue.EndsWith("</data>"))
            {
                xDoc = XDocument.Parse("<data></data>");
            }
            else
            {
                xDoc = XDocument.Parse(strValue);
            }

            return xDoc;
        }

        #endregion

        #region Private Methods

        private static readonly object Lock = new object();

        private static readonly Dictionary<Type, string[]> EmbeddedContentTypesAliases = new Dictionary<Type, string[]>();

        private static string[] GetPropertyAliases(Type type)
        {
            return type.GetProperties().Select(GetEmbeddedContentPropertyAttribute).Where(attribute => attribute != null).Select(attribute => attribute.Alias).ToArray();
        }

        private static object ConvertValue(Type propertyType, string value)
        {
            object val = null;
            if (propertyType == typeof (string))
            {
                val = value;
            }
            else if (propertyType == typeof (DateTime))
            {
                DateTime dtVal;
                if (DateTime.TryParse(value, out dtVal))
                {
                    val = dtVal;
                }
            }
            else if (propertyType == typeof (bool))
            {
                val = value != "" & value != "0";
            }
            else if (propertyType == typeof (long))
            {
                long longVal;
                if (Int64.TryParse(value, out longVal))
                {
                    val = longVal;
                }
            }
            else if (propertyType == typeof (int))
            {
                int strVal;
                if (Int32.TryParse(value, out strVal))
                {
                    val = strVal;
                }
            }
            else if (propertyType == typeof(decimal))
            {
                decimal strVal;
                if (Decimal.TryParse(value, out strVal))
                {
                    val = strVal;
                }
            } 
            return val;
        }

        private static EmbeddedContentAttribute GetEmbeddedContentAttribute(Type type)
        {
            var customAttributes = type.GetCustomAttributes(typeof(EmbeddedContentAttribute), true);
            return customAttributes.Length <= 0 ? default(EmbeddedContentAttribute) : (EmbeddedContentAttribute)customAttributes[0];
        }

        private static EmbeddedContentPropertyAttribute GetEmbeddedContentPropertyAttribute(PropertyInfo propertyInfo)
        {
            var customAttributes = propertyInfo.GetCustomAttributes(typeof(EmbeddedContentPropertyAttribute), true);
            return customAttributes.Length <= 0 ? default(EmbeddedContentPropertyAttribute) : (EmbeddedContentPropertyAttribute)customAttributes[0];
        }

        #endregion
    }
}