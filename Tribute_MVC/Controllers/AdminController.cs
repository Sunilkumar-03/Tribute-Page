using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tribute_MVC.Services;
using Tribute_MVC.Models;
using Tribute_MVC.Models.DataViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Tribute_MVC.Notification;

namespace Tribute_MVC.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private IAdminService _admin = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserService _user = null;
        public AdminController(IAdminService adminService, IWebHostEnvironment webHostEnvironment, IUserService userService)
        {
            _admin = adminService;
            _webHostEnvironment = webHostEnvironment;
            _user = userService;
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email,string password)
        {
            try
            {
                User user = _admin.Login(email, password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.UserId);
                    if (user.ImageUrl is null || user.ImageUrl == "")
                        HttpContext.Session.SetString("ImageUrl", "avatar7.png");
                    else
                        HttpContext.Session.SetString("ImageUrl", user.ImageUrl);
                    HttpContext.Session.SetString("UserName", user.UserName);
                    
                    HttpContext.Session.SetString("Role", user.Role);
                    if (user.Role == "User")
                        return RedirectToAction("UserDashboard", "User");
                    else
                        return RedirectToAction("AdminDashBoard");
                }
                else
                {
                    ViewBag.Error = "Invalid Crendentials";
                    ModelState.Clear();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            try
            {
                user.Status = "Active";
                user.Role = "User";
                if (_admin.Register(user))
                {
                    ViewBag.Success = "Account created Successfully please Login to continue";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ViewBag.Error = "Already Registerd";
                    ModelState.Clear();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("PostTribute")]
        public IActionResult AddTribute()
        {
            try
            {
                if(HttpContext.Session.GetString("Role") == "Admin")
                {
                    List<SelectListItem> genreList = _admin.GetListofCategories().Select(n => new SelectListItem { Value = n.CategoryId.ToString(), Text = n.Type }).ToList();

                    var genreTip = new SelectListItem()
                    {
                        Value = null,
                        Text = "--- Select Category ---"
                    };
                    genreList.Insert(0, genreTip);
                    ViewBag.generList = new SelectList(genreList, "Value", "Text");
                    ViewBag.Success = TempData["Success"];
                    ViewBag.Error = TempData["Error"];
                    return View();
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("PostTribute")]
        public IActionResult AddTribute(TributeDataView vm)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    List<SelectListItem>  genreList = _admin.GetListofCategories().Select(n => new SelectListItem { Value = n.CategoryId.ToString(), Text = n.Type }).ToList();
                    int UserId = (int)HttpContext.Session.GetInt32("UserId");
                    string fileName = UploadFile(vm);
                    Tribute tribute = new Tribute()
                    {
                        Name = vm.Name,
                        ImageUrl = fileName,
                        Abstract = vm.Abstract,
                        Description = vm.Description,
                        RefferenceLink = vm.RefferenceLink,
                        UserId = (int)HttpContext.Session.GetInt32("UserId"),
                        Status = "Active",
                        Approval = "Approved",
                        CategoryId = vm.CategoryId
                    };
                    if (_admin.AddTribute(tribute))
                    {
                        TempData["Success"] = "Tribute Posted";
                        ModelState.Clear();
                        return RedirectToAction("AddTribute");
                    }
                    else
                        TempData["Error"] = "Already Posted";
                        ModelState.Clear();
                    return RedirectToAction("AddTribute");
                }
                else
                {
                    ModelState.Clear();
                    return View();

                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        private string UploadFile(TributeDataView vm)
        {
            string fileName = null;
            if (vm.Image != null)
            {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Layout\\img"); // Project Directory path
                fileName = Guid.NewGuid().ToString() + vm.Image.FileName;
                string filePath = Path.Combine(UploadDir, fileName);   // Binding image to FileName
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Image.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult AdminDashBoard()
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                List<User> users = _admin.GetListofActiveUsers();
                List<Tribute> tributes = _user.GetTributes();
                List<TributeCategory> tributeCategories = _admin.GetListofCategories();
                List<Tribute> logs = _admin.GetPendingTributes();
                ViewBag.UsersCount = users.Count;
                ViewBag.TributesCount = tributes.Count;
                ViewBag.CategoriesCount = tributeCategories.Count;
                if (logs != null)
                    ViewBag.Tasks = logs.Count;
                else
                    ViewBag.Tasks = 0;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home",new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    _admin.DeleteUser(id);
                    return RedirectToAction("ViewAllActiveUsers");
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorized Acess" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayActiveUsers")]
        public IActionResult ViewAllActiveUsers()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    List<User> users = _admin.GetListofActiveUsers();
                    return View(users);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DeleteTribute")]
        public IActionResult DeleteTribute(int Id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    _admin.DeleteTribute(Id);
                    return RedirectToAction("ViewAllTributes");
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayTributes")]
        public IActionResult ViewAllTributes()
        {
            try
            {
                List<Tribute> tributes = _user.GetTributes();
                return View(tributes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayUser")]
        public IActionResult DisplayUser(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    ViewBag.TributesCount = _admin.GetCountOfTributesOfUser(id);
                    User user = _admin.GetUserById(id);
                    return View(user);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayTribute")]
        public IActionResult DisplayTribute(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    Tribute tribute = _admin.GetTributeById(id);
                    return View(tribute);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayCategories")]
        public IActionResult DisplayCategories()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    ViewBag.SportsCount = _admin.GetTributesByCategories(1).Count;
                    ViewBag.ScienceCount = _admin.GetTributesByCategories(2).Count;
                    ViewBag.PoliticsCount = _admin.GetTributesByCategories(3).Count;
                    ViewBag.MoviesCount = _admin.GetTributesByCategories(4).Count;
                    ViewBag.MilitaryCount = _admin.GetTributesByCategories(5).Count;
                    ViewBag.AwardsCount = _admin.GetTributesByCategories(6).Count;
                    List<TributeCategory> category = _admin.GetListofCategories();
                    return View(category);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayTributesOfSameCategory")]
        public IActionResult DisplayTributesofSameCategories(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    List<Tribute> tributes = _admin.GetTributesByCategories(id);
                    List<TributeCategory> categories = _admin.GetListofCategories();
                    foreach (TributeCategory category in categories)
                    {
                        if (id == category.CategoryId)
                            ViewBag.CategoryName = category.Type;
                    }
                    return View(tributes);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("DisplayPendingTributes")]
        public IActionResult ViewAllPendingTributes()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    List<Tribute> tributes = _admin.GetPendingTributes();
                    return View(tributes);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("TributeAction")]
        public IActionResult TributeAction(int id, string Opinion, string action)
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                Tribute tribute = _admin.GetTributeById(id);
                User user = _admin.GetUserById(tribute.UserId);
                string Title = "Tribute Status";
                string Message = null;
                if (action == "Approve")
                {
                    if (_admin.ApproveTribute(UserId, id))
                    {
                        Message = "Status : Approved" + "\n\nReason : " + Opinion + "\n\nThank You";
                        Mail.SendMailToUser(user.Email, Title, Message);
                        return RedirectToAction("ViewAllPendingTributes");
                    }
                    else
                        return View("Error");
                }
                else
                {

                    if (_admin.RejectTribute(UserId, id))
                    {
                        Message = "Status : Rejected" + "\n\nReason : " + Opinion + "\n\nThank You";
                        Mail.SendMailToUser(user.Email, Title, Message);
                        return RedirectToAction("ViewAllPendingTributes");
                    }
                    else
                        return View("Error");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }

        }
        [HttpGet]
        [Route("ApproveTribute")]
        public IActionResult Approvetribute(int id, string message)
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                if (_admin.ApproveTribute(UserId, id))
                    return RedirectToAction("ViewAllPendingTributes");
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("RejectTribute")]
        public IActionResult RejectTribute(int id)
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                if (_admin.RejectTribute(UserId, id))
                    return RedirectToAction("ViewAllPendingTributes");
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("AddUser")]
        public IActionResult AddUser()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                user.Password = GetRandomPassword();
                user.Status = "Active";
                if (_admin.Register(user))
                {
                    string Title = "User Credentials";
                    string Message = "Your Acount bas been Create Successfully\n\nYou Can Login By Using Following Credentials\n" +
                        "UserId : " + user.Email + "\nPassword : " + user.Password + "\n\nThank You";
                    if (Mail.SendMailToUser(user.Email, Title, Message))
                        ViewBag.Success = "Account created Successfully and credentials has been mailed to the User.";
                    else
                        ViewBag.Success = "Account created Successfully\nBut due to Technincal reason we can't send mail Now.";
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    ViewBag.Error = "Already Registerd";
                    ModelState.Clear();
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("TributeInfo")]
        public IActionResult TributeInfo(int id)
        {
            try
            {
                Tribute tribute = _admin.GetTributeById(id);
                return View(tribute);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("ViewTributeDetails")]
        public IActionResult ViewTributeDetails(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    ViewData["Comments"] = _admin.GetCommentsofTribute(id);
                    Tribute tribute = _admin.GetTributeById(id);
                    User user = _admin.GetUserById(tribute.UserId);
                    ViewBag.Author = user.UserName;
                    return View(tribute);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("ViewHistory")]
        public IActionResult ViewHistory()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    List<TributeLogModel> history = _admin.GetTributeModificationDetails();
                    return View(history);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("PostFeedback")]
        public IActionResult AddFeedback(string rate,string comment,int id)
        {
            try
            {
                TributeRating rating = new TributeRating()
                {
                    Rating = Convert.ToInt32(rate),
                    Comments = comment,
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    TributeId = id
                };
                _admin.AddFeedback(rating);
                return RedirectToAction("ViewTributeDetails", new { id = id });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("EditTribute")]
        public IActionResult EditTribute(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    Tribute tribute = _admin.GetTributeById(id);
                    return View(tribute);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("EditTribute")]
        public IActionResult EditTribute(Tribute tribute)
        {
            try
            {
                _admin.UpdateTribute(tribute);
                return RedirectToAction("ViewTributeDetails", new { id = tribute.TributeId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("SearchForTribute")]
        public IActionResult Search()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "Admin")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("SearchForTribute")]
        public IActionResult Search(string SearchValue)
        {
            try
            {
                if (SearchValue != null)
                {
                    List<Tribute> tributes = _user.GetTributes(SearchValue);
                    if (tributes.Count  > 0)
                        return View("Search", tributes);
                    else
                    {
                        ViewBag.Empty = "Search Not Found";
                        return View("Search");
                    }
                }
                else
                {
                    ViewBag.Empty = "Search Field Can't be Empty";
                    return View("Search");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }



        [HttpGet]
        [Route("Profile")]
        public IActionResult Profile()
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                User user = _admin.GetUserById(UserId);
                UserDataView userData = new UserDataView()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    Role = user.Role,
                    Status = user.Status,
                    ImageUrl = null,
                };
                return View(userData);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("Profile")]
        public IActionResult Profile(UserDataView user)
        {
            try
            {
                string fileName;
                if (user.ImageUrl != null)
                {
                    fileName = UploadFile(user);
                    HttpContext.Session.SetString("ImageUrl", fileName);
                }
                else
                    fileName = HttpContext.Session.GetString("ImageUrl");

                User userData = new User()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    Mobile = user.Mobile,
                    Role = user.Role,
                    Status = user.Status,
                    ImageUrl = fileName
                };
                if (_user.EditUser(userData))
                {
                    ViewBag.Success = "Profile Update Successfully";
                    return View();
                }
                else
                {
                    ViewBag.Error = "Profile Can't be updated right now";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        private string UploadFile(UserDataView vm)
        {
            try
            {
                string fileName = null;
                if (vm.ImageUrl != null)
                {
                    string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Layout\\Users"); // Project Directory path
                    fileName = Guid.NewGuid().ToString() + vm.ImageUrl.FileName;
                    string filePath = Path.Combine(UploadDir, fileName);   // Binding image to FileName
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        vm.ImageUrl.CopyTo(fileStream);
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string GetRandomPassword()
        {
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 1; i <=8;i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
        [HttpGet]
        [Route("LogOff")]
        public IActionResult LogOff()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
    }
}
