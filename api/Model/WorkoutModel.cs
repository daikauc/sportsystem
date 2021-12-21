using System.ComponentModel.DataAnnotations;

namespace SportSystemAPI.Model
{
    public class WorkoutModel
    {
        [Key]
        public int Id { get; set; }
        public double Length { get; set; }
        public string Date { get; set; }
        public string StartDate { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public double Diff { get; set; }
        public int Max { get; set; }
        public int CurrCount { get; set; }
    }
}