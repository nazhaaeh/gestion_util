using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserRolle
    {
        [Key] public int IDRolleUser { get; set; }
        [Required]
        [ForeignKey("IdRolle")]
        public int IdRolle { get; set; }
        public virtual Rolle Rolle { get; set; }
        [Required]
        [ForeignKey("IdUser")]
        public int IdUser { get; set; }
        public virtual User user { get; set; }
    }
}
