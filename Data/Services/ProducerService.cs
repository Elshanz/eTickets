using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IProducerService : IGenericRepository<Producer>
    {

    }
    public class ProducerService : GenericRepository<Producer> ,IProducerService 
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}
