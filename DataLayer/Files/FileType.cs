using System.ComponentModel;

namespace DataLayer.Files
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FileType : byte
    {
        [Description("Спецификация")]
        Specification = 1,

        [Description("Заявка на ТН")]
        SupervisionRequest = 2,

        [Description("План поставки")]
        SupplyPlan = 3,

        [Description("Письмо")]
        Letter = 4,

        [Description("Акт входного контроля")]
        InputControlAct = 5,

        [Description("Акт выявленных несоответствий")]
        ProductionControlAct = 6,

        [Description("Акт забракования")]
        RejectAct = 7,

        [Description("Техническое решение")]
        TechSolution = 8,

        [Description("Фотоматериал")]
        Photo = 9
    }
}
