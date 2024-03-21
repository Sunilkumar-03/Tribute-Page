using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.Entities;

namespace Tribute_API.Repository
{
    public interface IUserRepository
    {
        List<Tribute> GetTributes();
        List<Tribute> GetTributes(string searched_tributes);
        List<Tribute> GetTributeByUser(int uId);
        Tribute GetTributeById(int tId);
        User GetUserById(int id);
        Tribute GetTributeByName(string tName);
        bool AddTribute(Tribute tribute);
        bool UpdateTribute(Tribute tribute);
        bool DeleteTribute(int tId);
        bool EditUser(User user);
    }
}
