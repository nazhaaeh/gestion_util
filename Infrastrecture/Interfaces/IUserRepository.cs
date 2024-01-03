using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrecture.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void AddUserAndSave(User user);
       Task<IEnumerable<User>> GetAll();
       
        void Save();
    }
}
