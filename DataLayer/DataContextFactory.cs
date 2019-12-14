using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class DataContextFactory : IDataContextFactory
    {
        public DataContextFactory()
        {
        }

        public DataContext Create()
        {
            return new DataContext();
        }
    }
}