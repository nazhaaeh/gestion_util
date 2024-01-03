using Domain.Models;
using Infrastrecture.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrecture.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DBcontexAppt dbcontext) : base(dbcontext)
        {
        }

        public void AddUserAndSave(User user)
        {
            Add(user);
            Save();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await dbcontext.Set<User>().ToListAsync();
        }

        public object GetAllAsync()
        {
            throw new NotImplementedException();
        }

       

        public void Save()
        {
           dbcontext.SaveChanges();
        }

 
    }
}
