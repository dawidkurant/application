namespace Papu.Entities
{
    public class LunchProduct
    {
        public int LunchId { get; set; }
        public Lunch Lunch { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
