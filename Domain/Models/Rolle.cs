using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Rolle
    {
        [Key]
        public int IdRolle { get; set; }
        public string NameRolle { get; set; }
        public virtual ICollection<User> Roles { get; set; }= new HashSet<User>();
    }
}
