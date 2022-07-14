using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppify.Models
{
    public class Notification
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        
        public int ToUser { get; set; }

        [ForeignKey("ToUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual User User { get; set; }
    }
}
