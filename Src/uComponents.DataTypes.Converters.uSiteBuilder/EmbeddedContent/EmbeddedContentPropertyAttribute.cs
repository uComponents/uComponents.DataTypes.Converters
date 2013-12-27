using System;
using System.Collections.Generic;
using System.Linq;

namespace uComponents.DataTypes.Converters.uSiteBuilder.EmbeddedContent
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class EmbeddedContentPropertyAttribute : Attribute
    {
        private static Dictionary<EmbeddedContentPropertyType, string> _propertyTypeDictionary;
        private static Dictionary<EmbeddedContentPropertyType, string> PropertyTypeDictionary
        {
            get
            {
                return _propertyTypeDictionary ?? (_propertyTypeDictionary = new Dictionary<EmbeddedContentPropertyType, string>
                    {
                        {EmbeddedContentPropertyType.Textstring, "Textstring"},
                        {EmbeddedContentPropertyType.TextboxMultiple, "Textbox multiple"},
                        {EmbeddedContentPropertyType.TrueFalse, "True/false"},
                        {EmbeddedContentPropertyType.ContentPicker, "Content picker"},
                        {EmbeddedContentPropertyType.MediaPicker, "Media picker"},
                        {EmbeddedContentPropertyType.SimpleEditor, "Simple editor"},
                        {EmbeddedContentPropertyType.DatePicker, "Date picker"},
                        {EmbeddedContentPropertyType.RichtextEditor, "Richtext editor"}
                    });
            }
        }

        private string _alias;

        public EmbeddedContentPropertyAttribute() : this(EmbeddedContentPropertyType.Textstring, "")
        {
        }

        public EmbeddedContentPropertyAttribute(EmbeddedContentPropertyType type, string label)
        {
            Type = type;
            Label = label;

            Id = -1;
            Alias = Util.GetCamelCase(label);
            Description = string.Empty;
            ShowInTitle = true;
            Required = false;
            Validation = string.Empty;
        }

        public int Id { private get; set; }
        public string Label { get; set; }
        public string Alias
        {
            get { return _alias; }
            set { _alias = string.IsNullOrEmpty(value) ? Util.GetCamelCase(Label) : value.Replace(" ", ""); }
        }
        public EmbeddedContentPropertyType Type { get; set; }
        public string Description { get; set; }
        public bool ShowInTitle { get; set; }
        public bool Required { get; set; }
        public string Validation { get; set; }

        internal string Value
        {
            get
            {
                return
                    string.Format(
                        "||id:{0}|Name: {1}| Alias: {2}| Type: {3}| Description: {4}| Show in title? {5}| Required? {6}| Validation: {7}",
                        Id,
                        Label, 
                        Alias,
                        PropertyTypeDictionary[Type],
                        Description,
                        ShowInTitle.ToString().ToLower(), 
                        Required.ToString().ToLower(),
                        Validation);
            }
        }
    }
}