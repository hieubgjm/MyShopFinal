using MyShop.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyShop.Model.Models
{
    [Table("Footer")]
    public class Footer : Auditable
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}