using System.ComponentModel;

namespace DataLayer.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum DetailFileCategory : byte
    {
        /// <summary>
        /// Акт входного контроля
        /// </summary>
        [Description("Акт входного контроля")]
        InputControlAct = 1,

        /// <summary>
        /// Акт выявленных несоответствий
        /// </summary>
        [Description("Акт выявленных несоответствий")]
        ControlAct = 2,

        /// <summary>
        /// Техническое решение
        /// </summary>
        [Description("Техническое решение")]
        TechnicalSolution = 3,

        /// <summary>
        /// Техническое решение
        /// </summary>
        [Description("Письмо")]
        Letter = 4,

        /// <summary>
        /// Фотография
        /// </summary>
        [Description("Фото")]
        Photo = 5,
    }
}
