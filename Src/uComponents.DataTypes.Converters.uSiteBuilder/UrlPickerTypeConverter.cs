using System;
using uComponents.DataTypes.UrlPicker;
using uComponents.DataTypes.UrlPicker.Dto;
using Vega.USiteBuilder.Types;

namespace uComponents.DataTypes.Converters.uSiteBuilder
{
	public class UrlPickerTypeConverter : ICustomTypeConvertor
	{
		public Type ConvertType
		{
			get
			{
				return typeof(UrlPickerState);
			}
		}

		public object ConvertValueWhenRead(object inputValue)
		{
			if (inputValue is string)
				return UrlPickerState.Deserialize(inputValue.ToString());

			return null;
		}

		public object ConvertValueWhenWrite(object inputValue)
		{
			if (inputValue is UrlPickerState)
				((UrlPickerState)inputValue).Serialize(UrlPickerDataFormat.Xml);

			return null;
		}
	}
}