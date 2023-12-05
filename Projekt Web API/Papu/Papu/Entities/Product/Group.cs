using Newtonsoft.Json;
using System.Collections.Generic;

namespace Papu.Entities
{
    public class Group
    {
        // Id i Nazwa grupy do której należy produkt
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        // Grupa
        [JsonIgnore]
        public virtual ICollection<ProductGroup> ProductGroups { get; set; }


    }
}
