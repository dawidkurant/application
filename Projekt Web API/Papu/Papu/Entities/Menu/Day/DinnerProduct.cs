namespace Papu.Entities
{
    public class DinnerProduct
    {
        public int DinnerId { get; set; }
        public Dinner Dinner { get; set; }


        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
