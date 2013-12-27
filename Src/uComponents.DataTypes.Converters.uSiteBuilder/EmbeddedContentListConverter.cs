using System;
using System.Collections.Generic;
using Vega.USiteBuilder;
using Vega.USiteBuilder.Types;
using Util = uComponents.DataTypes.Converters.uSiteBuilder.EmbeddedContent.Util;

namespace uComponents.DataTypes.Converters.uSiteBuilder
{
    public class EmbeddedContentListConverter<T> : ICustomTypeConvertor where T : DataTypeBase, new()
    {
        #region Implementation of ICustomTypeConvertor

        /// <summary>
        /// Converts inputValue to other type and returns converted value. This method is used when reading item from Umbraco.
        /// </summary>
        /// <param name="inputValue">Input value (for example string xml)</param>
        /// <returns>
        /// Output value (instance of class created from input xml, could be anything)
        /// </returns>
        public object ConvertValueWhenRead(object inputValue)
        {
            var embeddedContentXml = Util.GetEmbeddedContentXDocument(inputValue as string);
            return Util.GetMappedList<T>(embeddedContentXml);
        }

        /// <summary>
        /// Converts inputValue to other type and returns converted value. This method is used when writing item to Umbraco (e.g. with ContentHelper.Save).
        /// </summary>
        /// <param name="inputValue">Input value (for example List of RelatedLinks)</param>
        /// <returns>
        /// Output value (string or xml)
        /// </returns>
        public object ConvertValueWhenWrite(object inputValue)
        {
            var list = inputValue as List<T>;
            return Util.GetEmbeddedContentValue(list);
        }

        /// <summary>
        /// Gets the Type that this converter converts to and from
        /// </summary>
        public Type ConvertType
        {
            get { return typeof (List<T>); }
        }

        #endregion
    }
}