using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppify.Models
{
    public class Auction : Sale
    {   
        [Key]
        public long ID { get; set; }

        [Required]
        public DateTime InitialTime { get; set; }
        [Required]
        public DateTime TotalTime { get; set; }

        [Required]
        public int ActualUser { get; set; }
        [Required]
        public decimal ActualPrice { get; set; }
        [Required]
        public decimal InitialPrice { get; set; }

        [ForeignKey("ToUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual User User { get; set; }
    }
}
