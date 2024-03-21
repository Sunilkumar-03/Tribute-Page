using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.Entities;
using Tribute_API.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Tribute_API.Repository
{
    public class AdminRepository:IAdminRepository
    {
        private StoreContext _context = null;
        public AdminRepository(StoreContext context)
        {
            _context = context;
        }

        public bool AddFeedback(TributeRating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            return true;
        }

        public bool AddTribute(Tribute tribute)
        {
            if(_context.Tributes.Any(i=>i.Name == tribute.Name))
            {
                return false;
            }
            else
            {
                tribute.Status = "Active";
                tribute.Approval = "Approved";
                _context.Tributes.Add(tribute);
                _context.SaveChanges();
                return true;
            }
        }

        public bool ApproveTribute(int userId,int tributeId)
        {
            Tribute tribute = _context.Tributes.Find(tributeId);
            if (tribute != null)
            {
                tribute.Approval = "Approved";
                _context.Tributes.Update(tribute);
                _context.SaveChanges();
                Approval approval = new Approval()
                {
                    UserId = userId,
                    TributeId = tributeId,
                    DateOfApproval = DateTime.Now
                };
                _context.Approvals.Add(approval);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteTribute(int id)
        {
            Tribute tribute = _context.Tributes.Find(id);
            if (tribute != null)
            {
                tribute.Status = "Inactive"; 
                _context.Tributes.Update(tribute);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                user.Status = "Inactive";
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public List<TributeLogModel> GetCommentsofTribute(int id)
        {
            if (_context.Ratings.Any(i => i.TributeId == id))
            {
                List<TributeLogModel> tributeLogs = new List<TributeLogModel>();
                List<TributeRating> ratings = _context.Ratings.Where(i => i.TributeId == id).ToList();
                if (ratings.Count > 0)
                {
                    foreach (var rating in ratings)
                    {
                        string userName = _context.Users.Where(i => i.UserId == rating.UserId).Select(i => i.UserName).SingleOrDefault();                        TributeLogModel model = new TributeLogModel()
                        {
                            UserName = userName,
                            Comment = rating.Comments,
                            Rating = rating.Rating
                        };
                        tributeLogs.Add(model);
                    }
                    return tributeLogs;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public int GetCountOfTributesOfUser(int id)
        {
            return _context.Tributes.Count(i => i.UserId == id);
            
        }

        public List<User> GetListofActiveUsers()
        {
            return _context.Users.ToList();
        }

        public List<TributeCategory> GetListofCategories()
        {
            return _context.TributeCategories.ToList();

        }

        public List<Tribute> GetPendingTributes()
        {
            return _context.Tributes.Where(i => i.Status == "Active" && i.Approval == "Pending").ToList();
        }

        public int GetTotalRatingsofTribute(int id)
        {
            if (_context.Tributes.Any(i => i.TributeId == id))
            {
                return _context.Ratings.Where(i => i.TributeId == id).Sum(i => i.Rating);
            }
            else
                return 0;
        }

        public Tribute GetTributeById(int id)
        {
            Tribute tribute = _context.Tributes.Find(id);
            if (tribute.Status == "Active")
                return tribute;
            else
                return null;
        }

        public List<TributeLogModel> GetTributeModificationDetails()
        {
            List<TributeLogModel> tributeLogs = new List<TributeLogModel>();
            List<TributeLog> logs = _context.TributeLogs.ToList();
            if (logs.Count > 0)
            {
                foreach (var tribute in logs)
                {
                    string userName = _context.Users.Where(i => i.UserId == tribute.UserId).Select(i => i.UserName).SingleOrDefault();
                    string tributeName = _context.Tributes.Where(i => i.TributeId == tribute.TributeId).Select(i => i.Name).SingleOrDefault();
                    TributeLogModel model = new TributeLogModel()
                    {
                        UserName = userName,
                        TributeName = tributeName,
                        dateTime = tribute.DateOfModification,
                    };
                    tributeLogs.Add(model);
                }
                return tributeLogs;
            }
            else
                return null;
        }

        public List<Tribute> GetTributes()
        {
            return _context.Tributes.Where(i => i.Status == "Active" && i.Approval == "Approved").Take(6).ToList();
        }

        public List<Tribute> GetTributesByCategories(int id)
        {
            return _context.Tributes.Where(i => i.CategoryId == id && i.Approval == "Approved" && i.Status == "Active").ToList();
        }

        public User GetUserById(int id)
        {
            User user = _context.Users.Find(id);
                return user;
        }

        public User Login(string email, string password)
        {
            return _context.Users.SingleOrDefault(i => i.Email == email && i.Password == password && i.Status == "Active");

        }

        public bool Register(User user)
        {
            if(_context.Users.Any(i=>i.Email == user.Email))
            {
                return false;
            }
            else
            {
                user.Status = "Active";
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
        }

        public bool RejectTribute(int userId, int tributeId)
        {
            Tribute tribute = _context.Tributes.Find(tributeId);
            if (tribute != null)
            {
                tribute.Approval = "Rejected";
                tribute.Status = "Active";
                _context.Tributes.Update(tribute);
                _context.SaveChanges();
                Approval approval = new Approval()
                {
                    UserId = userId,
                    TributeId = tributeId,
                    DateOfApproval = DateTime.Now
                };
                _context.Approvals.Add(approval);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool UpdateTribute(Tribute newTribute)
        {
            if(_context.Tributes.Any(i=>i.TributeId == newTribute.TributeId))
            {
                _context.Tributes.Update(newTribute);
                _context.SaveChanges();
                TributeLog log = new TributeLog()
                {
                    UserId = newTribute.UserId,
                    TributeId = newTribute.TributeId,
                    DateOfModification = DateTime.Now,
                };
                _context.TributeLogs.Add(log);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
