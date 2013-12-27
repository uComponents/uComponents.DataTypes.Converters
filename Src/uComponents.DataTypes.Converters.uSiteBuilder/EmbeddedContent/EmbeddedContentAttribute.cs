using System;
using Vega.USiteBuilder;

namespace uComponents.DataTypes.Converters.uSiteBuilder.EmbeddedContent
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class EmbeddedContentAttribute : DataTypeAttribute
    {
        public EmbeddedContentAttribute()
        {
            RenderControlName = Constants.DataEditor.EmbeddedContentControlName;    // "Embedded Content";
            RenderControlGuid = Constants.DataEditor.EmbeddedContentControlGuid;    // "454545ab-1234-4321-abcd-1234567890ab";
            DatabaseDataType = umbraco.cms.businesslogic.datatype.DBTypes.Ntext;
            //editor = null;

            ShowLabel = true;
            MaxCount = 0;
            ShowType = true;
            ShowDescription = false;
            ShowTitle = false;
            ShowRequired = false;
            ShowValidation = false;
        }

        public bool ShowLabel { get; set; }
        public int MaxCount { get; set; }
        public bool ShowType { get; set; }
        public bool ShowDescription { get; set; }
        public bool ShowTitle { get; set; }
        public bool ShowRequired { get; set; }
        public bool ShowValidation { get; set; }
    }
}