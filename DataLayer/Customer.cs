using System.Collections.ObjectModel;

namespace DataLayer
{
    public class Customer : BaseTable
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ObservableCollection<Specification> Specifications { get; set; }

        public Customer()
        {
        }

        public Customer(Customer customer)
        {
            Name = customer.Name;
            ShortName = customer.ShortName;
        }
    }
}
