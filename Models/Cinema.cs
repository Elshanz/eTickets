using System.Collections.Generic;

namespace eTickets.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public List<Movie> Movies { get; set; }
    }
}
 