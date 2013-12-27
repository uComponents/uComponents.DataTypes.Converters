using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using umbraco.MacroEngines;
using Vega.USiteBuilder;
using Vega.USiteBuilder.Types;

namespace MMGY.Common.Umbraco.SiteBuilder.DataTypes.DataTypeConverters
{
    public class MultiNodeTreePickerListConverter : ICustomTypeConvertor
    {
        public Type ConvertType
        {
            get { return typeof (DynamicNodeList); }
        }

        public object ConvertValueWhenRead(object inputValue)
        {
            var list = new DynamicNodeList();
            var commaSeparated = inputValue as string;
            if (!string.IsNullOrEmpty(commaSeparated))
            {
                var ids = commaSeparated.Split(new[] {','});
                foreach (var dn in ids.Select(id => new DynamicNode(id)))
                {
                    list.Add(dn);
                }
            }
            return list;
        }

        public object ConvertValueWhenWrite(object inputValue)
        {
            var list = inputValue as DynamicNodeList;
            return list != null ? list.Select(d => d.Id.ToString(CultureInfo.InvariantCulture)) : new List<string>();
        }
    }

    public class MultiNodeTreePickerListConverter<T> : ICustomTypeConvertor where T : DocumentTypeBase, new()
    {
        public Type ConvertType
        {
            get { return typeof(List<T>); }
        }

        public object ConvertValueWhenRead(object inputValue)
        {
            var list = new List<T>();
            var commaSeparated = inputValue as string;
            if (!string.IsNullOrEmpty(commaSeparated))
            {
                var ids = commaSeparated.Split(new[] { ',' });
                list.AddRange(ids.Select(id => ContentHelper.GetByNodeId<T>(int.Parse(id))));
            }
            return list;
        }

        public object ConvertValueWhenWrite(object inputValue)
        {
            var list = inputValue as List<T>;
            return list != null ? list.Select(n => n.Id.ToString(CultureInfo.InvariantCulture)) : new List<string>();
        }
    }
}
