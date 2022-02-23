namespace Papu.Entities
{
    public class ProductSunday
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int SundayId { get; set; }
        public Sunday Sunday { get; set; }
    }
}
