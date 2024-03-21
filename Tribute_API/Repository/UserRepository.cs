using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.DataContext;
using Tribute_API.Entities;

namespace Tribute_API.Repository
{
    public class UserRepository:IUserRepository
    {
        private StoreContext _context = null;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }
        public List<Tribute> GetTributes()
        {
            return _context.Tributes.Where(i => i.Status == "Active" && i.Approval == "Approved").ToList();
        }
        public Tribute GetTributeByName(string tName)
        {
            return _context.Tributes.Where(i => i.Name == tName).SingleOrDefault();
        }
        public bool AddTribute(Tribute tribute)
        {
            if (_context.Tributes.Any(i => i.Name == tribute.Name))
            {
                return false;
            }
            else
            {
                tribute.Status = "Active";
                tribute.Approval = "Pending";
                _context.Tributes.Add(tribute);
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteTribute(int tId)
        {
            Tribute tribute = _context.Tributes.Find(tId);
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


        public bool UpdateTribute(Tribute newTribute)
        {
            if (_context.Tributes.Any(i => i.TributeId == newTribute.TributeId))
            {
                newTribute.Approval = "Pending";
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

        public bool EditUser(User newUser)
        {
            if (_context.Users.Any(i => i.UserId == newUser.UserId))
            {
                _context.Users.Update(newUser);
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }

        public List<Tribute> GetTributes(string searched_tributes)
        {
            return _context.Tributes.Where(i => i.Name.Contains(searched_tributes) && i.Status == "Active" && i.Approval == "Approved").ToList();
        }

        public Tribute GetTributeById(int tId)
        {
            Tribute tribute = _context.Tributes.Find(tId);
            
                return tribute;
         
          
        }
        public List<Tribute> GetTributeByUser(int uId)
        {
           
            return _context.Tributes.Where(i => i.UserId == uId).ToList();
        }
        public User GetUserById(int id)
        {
            User user = _context.Users.Find(id);
            if (user.Status == "Active")
                return user;
            else
                return null;
        }

    }
}
