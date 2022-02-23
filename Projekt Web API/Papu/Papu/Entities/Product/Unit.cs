﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Papu.Entities
{
    public class Unit
    {
        //Id i Nazwa jednostki miary produktu 
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}
