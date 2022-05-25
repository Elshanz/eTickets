using eTickets.Data.Base;
using FluentValidation;
using System.Collections.Generic;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Navigation Properties
        public List<Actor_Movie> Actors_Movies { get; set; } 
    }
    public class ActorToUpdate
    {
        public string ProfilePictureUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
    }
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(x => x.ProfilePictureUrl)
                .NotEmpty();
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Full Name should not be empty. Test")
                .Length(2, 30)
                .WithMessage("Characters must be between 2 and 30");
            RuleFor(x => x.Bio)
                .NotEmpty()
                .WithErrorCode("25")
                .MaximumLength(250);
        }
    }
}