namespace DataLayer.Journals
{/// <summary>
/// Номера журналов
/// </summary>
    public class JournalNumber : BaseTable
    {
        /// <summary>
        /// Номер журнала
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Отметка о закрытии журнала
        /// </summary>
        public bool IsClosed { get; set; } = false;
    }
}
