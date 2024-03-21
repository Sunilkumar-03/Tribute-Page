using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.Entities;

namespace Tribute_API.Repository
{
    public interface IAdminRepository
    {
        User Login(string email, string password);
        bool Register(User user);
        bool DeleteUser(int id);
        bool AddTribute(Tribute tribute);
        bool UpdateTribute(Tribute tribute);
        bool DeleteTribute(int id);
        bool ApproveTribute(int userId,int tributeId);
        bool RejectTribute(int userId, int tributeId);
        List<TributeLogModel> GetTributeModificationDetails();
        List<Tribute> GetPendingTributes();
        List<TributeCategory> GetListofCategories();
        List<User> GetListofActiveUsers();
        User GetUserById(int id);
        Tribute GetTributeById(int id);
        List<Tribute> GetTributes();
        List<Tribute> GetTributesByCategories(int id);
        bool AddFeedback(TributeRating rating);
        int GetTotalRatingsofTribute(int id);
        List<TributeLogModel> GetCommentsofTribute(int id);
        int GetCountOfTributesOfUser(int id);
    }
}
