﻿using MyShop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Model.Models
{
    [Table("Pages")]
    public class Page : Auditable
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string? Alias { get; set; }

        public string Content { get; set; }

        [MaxLength(256)]
        public string MetaKeyword { get; set; }
        [MaxLength(256)]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}
