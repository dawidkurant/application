using Newtonsoft.Json;
using System.Collections.Generic;

namespace Papu.Entities
{
    public class Type
    {
        //Id i Nazwa typu do którego należy danie
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<DishType> DishTypes { get; set; }

    }
}
