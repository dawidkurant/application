namespace Papu.Entities
{
    public class ProductGroup
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
