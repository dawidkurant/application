namespace Papu.Entities
{ 
    public class SecondBreakfastProduct
    {
        public int SecondBreakfastId { get; set; }
        public SecondBreakfast SecondBreakfast { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
