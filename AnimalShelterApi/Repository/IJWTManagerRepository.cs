using AnimalShelterApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterApi.Repository
{
   public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users); 
    }
   
}