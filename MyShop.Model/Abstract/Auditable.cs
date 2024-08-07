﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Model.Abstract
{
    public abstract class Auditable
    {

      public  DateTime? CreatedDate { get; set; }
        [MaxLength(256)]
      public  string CreatedBy { get; set; }
      public  DateTime? UpdatedDate { get; set; }
        [MaxLength(256)]
      public string? UpdatedBy { get; set; }
    }
}
