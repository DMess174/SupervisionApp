using System.ComponentModel;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SpecificationFileCategory : byte
    {
        /// <summary>
        /// Годен
        /// </summary>
        [Description("Спецификация")]
        Specification = 1,

        /// <summary>
        /// Ремонт
        /// </summary>
        [Description("Заявка на ТН")]
        SupervisionRequest = 2,

        /// <summary>
        /// Брак
        /// </summary>
        [Description("Письмо")]
        Letter = 3,
    }
}
