using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppify.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required, Range(0,float.MaxValue)]
        public float Price { get; set; }
        
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }

        [Required]
        public string Category { get; set; }
        [Required]
        public int Cantidad { get; set; }
        public int Calification { get; set; }

        //FK
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public User User { get; set; }
    }

}
