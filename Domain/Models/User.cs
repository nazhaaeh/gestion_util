
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required]
        public string ville {  get; set; }
        [Required]
        public string Sexe { get; set; }
        [Required]
        public bool JobInTech { get; set; }=true;
       public virtual ICollection<Rolle> Roles { get; set; } = new HashSet<Rolle>();

    }
  
}
