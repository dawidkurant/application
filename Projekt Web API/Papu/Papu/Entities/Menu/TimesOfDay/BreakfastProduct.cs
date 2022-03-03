namespace Papu.Entities
{
    public class BreakfastProduct
    {
        public int BreakfastId { get; set; }
        public Breakfast Breakfast { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
