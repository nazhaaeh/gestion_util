﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.User.Commands
{
    public class CreateUserCommandRequest: IRequest<int>
    {
      
        public int IdUser { get; set; }
      
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
       
        public string Email { get; set; }
      
        public string Password { get; set; }
      
        public string ville { get; set; }

        public string Sexe { get; set; }
     
        public bool JobInTech { get; set; } = true;
      
    }
}
