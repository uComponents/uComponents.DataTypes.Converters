namespace uComponents.DataTypes.Converters.uSiteBuilder
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
            public const string DropDownListRenderControlGuid = Umbraco.Core.Constants.PropertyEditors.DropDownList;

            public const string CheckBoxListRenderControlName = "Checkbox list";
            public const string CheckBoxListRenderControlGuid = Umbraco.Core.Constants.PropertyEditors.CheckBoxList;

            public const string UltimatePickerRenderControlName = "Ultimate Picker";
            public const string UltimatePickerRenderControlGuid = Umbraco.Core.Constants.PropertyEditors.UltimatePicker;

            // uComponents DataEditor values
            public const string MultiNodeTreePickerControlName = "Multi-Node Tree Picker";
            public const string MultiNodeTreePickerControlGuid = DataTypeConstants.MultiNodeTreePickerId;

            public const string TextstringArrayControlName = "uComponents: Textstring Array";
            public const string TextstringArrayControlGuid = DataTypeConstants.TextstringArrayId;

            public const string MultipleTextstringControlName = "uComponents-Legacy: Multiple Textstring";
            public const string MultipleTextstringControlGuid = DataTypeConstants.MultipleTextstringId;

            public const string MultiUrlPickerControlName = "Multi-Url Picker";
            public const string MultiUrlPickerControlGuid = DataTypeConstants.MultiUrlPickerId;

            public const string UrlPickerControlName = "Url Picker";
            public const string UrlPickerControlGuid = DataTypeConstants.UrlPickerId;

            /*
            private static readonly TheFarm.Umbraco.EmbeddedContent.DataEditor EmbeddedContentDataEditor = new TheFarm.Umbraco.EmbeddedContent.DataEditor();

             * /// <summary>
            /// Gets the name of the embedded content control.
            /// </summary>
            /// <value>
            /// The name of the embedded content control.
            /// </value>
            public static string EmbeddedContentControlName
            {
                get { return EmbeddedContentDataEditor.DataTypeName; }
            }

            /// <summary>
            /// Gets the embedded content control unique identifier.
            /// </summary>
            /// <value>
            /// The embedded content control unique identifier.
            /// </value>
            public static string EmbeddedContentControlGuid
            {
                get { return EmbeddedContentDataEditor.Id.ToString(); }
            }
            */
        }
    }
}