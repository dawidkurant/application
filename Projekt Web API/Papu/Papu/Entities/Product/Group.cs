using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Group
    {
        //Id i Nazwa grupy do której należy produkt
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
