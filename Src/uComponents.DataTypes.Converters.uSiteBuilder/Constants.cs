using UmbracoCore = Umbraco.Core;

namespace MMGY.Common.Umbraco.SiteBuilder
{
    public static class Constants
    {
        public static class RegularExpressions
        {
            public const string DecimalPercent = @"(?!^0*$)(?!^0*\.0*$)^\d{0,1}(\.\d{1,4})?$";
            public const string DecimalMoney = @"(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)";
            public const string Url = @"(http://|https://)([a-zA-Z0-9]+\.[a-zA-Z0-9\-]+|[a-zA-Z0-9\-]+)\.[a-zA-Z\.]{2,6}(/[a-zA-Z0-9\.\?=/#%&\+-]+|/|)";
            public const string IntegerPositive = @"^\d+$";
            public const string Year = @"^\d{4,4}$";
        }

        public static class DataEditor
        {
            // Umbraco Built-in DataEditor values
            public const string DropDownListRenderControlName = "Dropdown list";
            public const string DropDownListRenderControlGuid = UmbracoCore.Constants.PropertyEditors.DropDownList;

            public const string CheckBoxListRenderControlName = "Checkbox list";
            public const string CheckBoxListRenderControlGuid = UmbracoCore.Constants.PropertyEditors.CheckBoxList;

            public const string UltimatePickerRenderControlName = "Ultimate Picker";
            public const string UltimatePickerRenderControlGuid = UmbracoCore.Constants.PropertyEditors.UltimatePicker;

            public const string MultiNodeTreePickerControlName = "Multi-Node Tree Picker";
            public const string MultiNodeTreePickerControlGuid = uComponents.DataTypes.DataTypeConstants.MultiNodeTreePickerId;

            // uComponents DataEditor values
            public const string TextstringArrayControlName = "uComponents: Textstring Array";
            public const string TextstringArrayControlGuid = uComponents.DataTypes.DataTypeConstants.TextstringArrayId;

            public const string MultipleTextstringControlName = "uComponents-Legacy: Multiple Textstring";
            public const string MultipleTextstringControlGuid = uComponents.DataTypes.DataTypeConstants.MultipleTextstringId;

            public const string MultiUrlPickerControlName = "Multi-Url Picker";
            public const string MultiUrlPickerControlGuid = uComponents.DataTypes.DataTypeConstants.MultiUrlPickerId;

            public const string UrlPickerControlName = "Url Picker";
            public const string UrlPickerControlGuid = uComponents.DataTypes.DataTypeConstants.UrlPickerId;

            // Third-Party DataEditor values
            public const string GoogleMapsControlName = "Google Map";
            public const string GoogleMapsControlGuid = "1B64EAE2-F9A1-4276-A071-F25DDE6913DD";

            private static readonly TheFarm.Umbraco.EmbeddedContent.DataEditor EmbeddedContentDataEditor = new TheFarm.Umbraco.EmbeddedContent.DataEditor();

            /// <summary>
            /// Gets the name of the embedded content control.
            /// </summary>
            /// <value>
            /// The name of the embedded content control.
            /// </value>
            public static string EmbeddedContentControlName
            {
                get
                {
                    return EmbeddedContentDataEditor.DataTypeName;
                }
            }

            /// <summary>
            /// Gets the embedded content control unique identifier.
            /// </summary>
            /// <value>
            /// The embedded content control unique identifier.
            /// </value>
            public static string EmbeddedContentControlGuid
            {
                get
                {
                    return EmbeddedContentDataEditor.Id.ToString();
                }
            }
        }

        public static class DataType
        {
            // Custom DataType Definition values

            public const string HeroesPickerDataTypeName = "Heroes Picker"; // Multi-Node Tree Picker
            public const string HeroesPickerDataTypeUniqueId = "686016e7-9f25-49d7-947d-d2261392e03a";

            public const string SubPagesPickerDataTypeName = "SubPages Picker"; // Multi-Node Tree Picker
            public const string SubPagesPickerDataTypeUniqueId = "04700117-d816-44db-aa7f-ad51b356934f";

            public const string TextstringArrayDataTypeName = "Textstring Array"; // uComponents: Textstring Array
            public const string TextstringArrayDataTypeUniqueId = "85de75ea-32a5-4b75-8172-51457f910b33";

            public const string MultipleTextstringDataTypeName = "Multiple Textstring"; // uComponents-Legacy: Multiple Textstring
            public const string MultipleTextstringDataTypeUniqueId = "63c07635-e0fb-4a2a-af63-137ee9a372c9";

            public const string MultiUrlPickerDataTypeName = "Multi-Url Picker";
            public const string MultiUrlPickerDataTypeUniqueId = "f3277260-a39b-42f3-933a-d54a86f49077";

            public const string MapCoordinatePickerDataTypeName = "Map Coordinate Picker";
            public const string MapCoordinatePickerDataTypeUniqueId = "ef68a1c4-1812-4d71-9376-77f0ec7696d2";
        }
    }
}