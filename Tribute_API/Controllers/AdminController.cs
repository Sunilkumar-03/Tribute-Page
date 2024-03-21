using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_API.Entities;
using Tribute_API.Repository;

namespace Tribute_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminRepository _admin = null;
        public AdminController(IAdminRepository adminRepository)
        {
            _admin = adminRepository;
        }
        [HttpPost]
        [Route("Addtribute")]
        public IActionResult Add(Tribute tribute)
        {
            try
            {
                if (_admin.AddTribute(tribute))
                    return Ok("Tribute Added");
                else
                    return NotFound();
            }
            catch(Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("Login/{email}/{password}")]
        public IActionResult Login(string email,string password)
        {
            try
            {
                User user = _admin.Login(email, password);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound("Invalid User");
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpPut]
        [Route("Updatetribute")]
        public IActionResult Update(Tribute tribute)
        {
            try
            {
                if (_admin.UpdateTribute(tribute))
                    return Ok("Tribute updated");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("Deletetribute/{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                if (_admin.DeleteTribute(Id))
                    return Ok("Tribute Deleted");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                if (_admin.Register(user))
                    return Ok("User Added");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_admin.DeleteUser(id))
                    return Ok("User Deleted");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("ApproveTribute/{userId}/{tributeId}")]
        public IActionResult ApproveTribute(int userId, int tributeId)
        {
            try
            {
                if (_admin.ApproveTribute(userId,tributeId))
                    return Ok("TributeApproved");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("RejectTribute/{userId}/{tributeId}")]
        public IActionResult RejectTribute(int userId, int tributeId)
        {
            try
            {
                if (_admin.RejectTribute(userId, tributeId))
                    return Ok("Tribute Rejected");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributesHistory")]
        public IActionResult GetTributeData()
        {
            try
            {
                List<TributeLogModel> tributeLogs = _admin.GetTributeModificationDetails();
                if(tributeLogs != null)
                    return Ok(tributeLogs);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributeComments/{id}")]
        public IActionResult GetTributeComments(int id)
        {
            try
            {
                List<TributeLogModel> comments = _admin.GetCommentsofTribute(id);
                if (comments != null)
                    return Ok(comments);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetPendingTributes")]
        public IActionResult GetTributesWaitingForApproval()
        {
            try
            {
                List<Tribute> tributes = _admin.GetPendingTributes();
                if (tributes.Count > 0)
                    return Ok(tributes);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributeCategories")]
        public IActionResult GetListofTributeCategories()
        {
            try
            {
                List<TributeCategory> categories = _admin.GetListofCategories();
                if (categories.Count > 0)
                    return Ok(categories);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetListofUsers()
        {
            try
            {
                List<User> users = _admin.GetListofActiveUsers();
                if (users.Count > 0)
                    return Ok(users);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributes")]
        public IActionResult GetTributes()
        {
            try
            {
                List<Tribute> tributes = _admin.GetTributes();
                if (tributes.Count > 0)
                    return Ok(tributes);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                User user = _admin.GetUserById(id);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTribute/{id}")]
        public IActionResult GetTribute(int id)
        {
            try
            {
                Tribute tribute = _admin.GetTributeById(id);
                if (tribute != null)
                    return Ok(tribute);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributeOfSameCategory/{id}")]
        public IActionResult GetTributes(int id)
        {
            try
            {
                List<Tribute> tributes = _admin.GetTributesByCategories(id);
                if (tributes != null)
                    return Ok(tributes);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpPost]
        [Route("AddFeedback")]
        public IActionResult AddFeedback(TributeRating rating)
        {
            try
            {
                if(_admin.AddFeedback(rating))
                    return Ok("Rating added");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetRating")]
        public IActionResult GetRating(int id)
        {
            try
            {
                int rating = _admin.GetTotalRatingsofTribute(id);
                return Ok(rating);
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTributesCountOfUser/{id}")]
        public IActionResult GetTributesCountOfUser(int id)
        {
            try
            {
                int Count = _admin.GetCountOfTributesOfUser(id);
                return Ok(Count);
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [HttpGet]
        [Route("GetTrendingTributes")]
        public IActionResult GetTrendingTributes()
        {
            try
            {
                List<Tribute> tributes = (List<Tribute>)GetTrendingTributes();
                if (tributes.Count > 0)
                    return Ok(tributes);
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
    }
}
