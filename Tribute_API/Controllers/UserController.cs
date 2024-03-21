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
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository = null;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Route("AddTribute")]
        [HttpPost]
        public IActionResult AddTribute(Tribute tribute)
        {
            try
            {
                if (_userRepository.AddTribute(tribute))
                    return Ok("Tribute Posted");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }

        }
        [Route("UpdateTribute")]
        [HttpPut]
        public IActionResult UpdateTribute(Tribute tribute)
        {
            try
            {
                if (_userRepository.UpdateTribute(tribute))
                    return Ok("Tribute Updated");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [Route("DeleteTribute/{tId}")]
        [HttpDelete]
        public IActionResult DeleteTribute(int tId)
        {
            try
            {
                if (_userRepository.DeleteTribute(tId))
                    return Ok("Tribute Deleted");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [Route("GetTributeByName/{tName}")]
        [HttpGet]
        public IActionResult GetTributeByName(string tName)
        {
            try
            {
                Tribute tribute = _userRepository.GetTributeByName(tName);
                return Ok(tribute);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
        [Route("EditUser")]
        [HttpPut]
        public IActionResult EditUser(User user)
        {
            try
            {
                if (_userRepository.EditUser(user))
                    return Ok("User Edited");
                else
                    return NotFound();
            }
            catch (Exception exception)
            {
                return Content(exception.InnerException.Message);
            }
        }
        [Route("GetTributes")]
        [HttpGet]
        public IActionResult GetTributes()
        {
            try
            {
                List<Tribute> tribute = _userRepository.GetTributes();
                return Ok(tribute);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
        [Route("GetTributes/{searched_names}")]
        [HttpGet]
        public IActionResult GetTributes(string searched_names)
        {
            try
            {
                List<Tribute> tribute = _userRepository.GetTributes(searched_names);

                return Ok(tribute);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
        [HttpGet]
        [Route("GetTributeById/{tId}")]
        public IActionResult GetTributeById(int tId)
        {
            try
            {
                Tribute tribute = _userRepository.GetTributeById(tId);
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
        [Route("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                User user = _userRepository.GetUserById(id);
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
        [Route("GetTributeByUser/{uId}")]
        [HttpGet]
        public IActionResult GetTributeByUser(int uId)
        {
            try
            {
                List<Tribute> tribute = _userRepository.GetTributeByUser(uId);
                return Ok(tribute);
            }
            catch (Exception exception)
            {
                return NotFound(exception.InnerException.Message);
            }
        }

    }
}
