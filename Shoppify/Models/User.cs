using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppify.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }       
        public string UserName { get; set; }
        public string Password { get; set; }

        [Required]
        [MinLength(3),MaxLength(100)]
        public string Name { get; set; }

        [Required,MaxLength(50)]
        public string LastName { get; set; }
        public int AccountID { get; set; }        
        public string Info { get; set; }


    }
}
