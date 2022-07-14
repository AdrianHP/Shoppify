using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shoppify.Models
{
    public class Sale
    {

        [Key]
        public long SaleId { get; set; }
        
        public long ProductId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        [Required,Range(0,float.MaxValue)]
        public float Import { get; set; }

        [Required,Range(0,int.MaxValue)]
        public int Ammount { get; set; }

        public long User_Buy_ID { get; set; }
        public long User_Sale_ID { get; set; }

        [ForeignKey("User_Buy_ID")]
        public User User_Buy { get; set; }

        [ForeignKey("User_Sale_ID")]
        public User User_Sale { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }





    }

}
