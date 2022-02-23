namespace Papu.Entities
{
    public class ProductSaturday
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int SaturdayId { get; set; }
        public Saturday Saturday { get; set; }
    }
}
