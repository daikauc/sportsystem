using System.ComponentModel.DataAnnotations;

namespace SportSystemAPI.Model
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }


    }
}