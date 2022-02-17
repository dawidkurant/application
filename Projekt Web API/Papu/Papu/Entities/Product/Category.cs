using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Category
    {
        //Id i Nazwa kategorii do której należy produkt
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
