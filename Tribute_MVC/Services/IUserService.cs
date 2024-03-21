using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_MVC.Models;

namespace Tribute_MVC.Services
{
    public interface IUserService
    {
        List<Tribute> GetTributes();
        List<Tribute> GetTributes(string searched_tributes);
        Tribute GetTributeByName(string tName);
        List<Tribute> GetTributeByUser(int uId);
        Tribute GetTributeById(int tId);
        User getUserById(int id);
        bool AddTribute(Tribute tribute);
        bool  UpdateTribute(Tribute tribute);
        bool DeleteTribute(int tId);
        bool EditUser(User user);
    }
}
