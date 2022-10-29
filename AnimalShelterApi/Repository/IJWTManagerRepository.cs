using AnimalShelterApi.Models;

namespace AnimalShelterApi.Repository
{
  public interface IJWTManagerRepository
  {
    Tokens Authenticate(User user); 
  }
}