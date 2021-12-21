using System.ComponentModel.DataAnnotations;

namespace SportSystemAPI.Model
{
    public class WorkoutRegistrationModel
    {
        [Key]
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
    }
}