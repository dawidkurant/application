using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Group
    {
        //Id i Nazwa grupy do której należy produkt
        public int GroupId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
