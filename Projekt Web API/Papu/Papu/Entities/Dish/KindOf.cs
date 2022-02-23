﻿using System.Collections.Generic;

namespace Papu.Entities
{
    public class KindOf
    {
        //Id i Nazwa rodzaju do którego należy danie
        public int KindOfId { get; set; }
        public string KindOfName { get; set; }

        public virtual ICollection<DishKindOf> DishKindsOf { get; set; }

    }
}
