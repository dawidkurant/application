namespace Papu.Entities
{
    public class ProductFriday
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int FridayId { get; set; }
        public Friday Friday { get; set; }
    }
}
