using eTickets.Data.Base;
using FluentValidation;
using System.Collections.Generic;

namespace eTickets.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Navigation Properties
        public List<Movie> Movies { get; set; }
    }
    public class ProducerToUpdate
    {
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
    public class ProducerToUpdateValidator : AbstractValidator<Producer>
    {
        public ProducerToUpdateValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty();

            RuleFor(p => p.Bio)
                .NotEmpty();

            RuleFor(p => p.ProfilePictureUrl)
                .NotEmpty();
        }
    }
}
