using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services
{
    public interface IActorService : IGenericRepository<Actor>
    {
        
    }
    public class ActorService : GenericRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context) : base(context) { }
    }
}
