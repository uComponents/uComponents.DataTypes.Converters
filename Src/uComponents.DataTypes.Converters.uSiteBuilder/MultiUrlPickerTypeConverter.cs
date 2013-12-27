using System;
using uComponents.DataTypes.MultiUrlPicker.Dto;
using uComponents.DataTypes.UrlPicker;
using Vega.USiteBuilder.Types;

namespace uComponents.DataTypes.Converters.uSiteBuilder
{
	public class MultiUrlPickerTypeConverter : ICustomTypeConvertor
	{
		public Type ConvertType
		{
			get
			{
				return typeof(MultiUrlPickerState);
			}
		}

		public object ConvertValueWhenRead(object inputValue)
		{
			if (inputValue is string)
				return MultiUrlPickerState.Deserialize(inputValue.ToString());

			return inputValue;
		}

		public object ConvertValueWhenWrite(object inputValue)
		{
			if (inputValue is MultiUrlPickerState)
				((MultiUrlPickerState)inputValue).Serialize(UrlPickerDataFormat.Xml, true);

			return inputValue.ToString();
		}
	}
}