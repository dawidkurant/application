namespace Papu.Entities
{
    public class SnackProduct
    {
        public int SnackId { get; set; }
        public Snack Snack { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
