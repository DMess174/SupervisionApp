namespace DataLayer
{
    public class BaseTable : BasePropertyChanged
    {
        public int Id { get; set; }

        public BaseTable() { }

        public BaseTable(BaseTable table) { }
    }
}