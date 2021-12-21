using System.ComponentModel.DataAnnotations;

namespace SportSystemAPI.Model
{
    public class SubModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool Stopped { get; set; }
        public int Discount { get; set; }

    }
}