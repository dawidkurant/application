namespace Papu.Models.Create
{
    public class CreateBreakfastDto
    {
        //Produkty wchodzące w skład śniadania
        public int[] ProductId { get; set; }

        //Dania wchodzące w skład śniadania
        public int[] DishId { get; set; }
    }
}
