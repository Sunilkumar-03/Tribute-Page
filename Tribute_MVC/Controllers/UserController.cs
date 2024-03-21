using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tribute_MVC.Models;
using Tribute_MVC.Models.DataViewModel;
using Tribute_MVC.Services;

using Microsoft.AspNetCore.Http;

namespace Tribute_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserService _user = null;
        private IAdminService _admin = null;
        public UserController(IUserService userService, IAdminService adminService, IWebHostEnvironment webHostEnvironment)
        {
            _user = userService;
            _admin = adminService;
            _webHostEnvironment = webHostEnvironment;
        }
        
        [Route("AddTribute")]
        [HttpGet]
        public IActionResult AddTribute()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
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

        [Route("AddTribute")]
        [HttpPost]
        public IActionResult AddTribute(TributeDataView vm)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    List<SelectListItem>  genreList = _admin.GetListofCategories().Select(n => new SelectListItem { Value = n.CategoryId.ToString(), Text = n.Type }).ToList();
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
                        Approval = "Pending",
                        CategoryId = vm.CategoryId
                    };
                    if (_user.AddTribute(tribute))
                    {
                        TempData["Success"] = "Tribute Posted";
                        ModelState.Clear();
                        return RedirectToAction("AddTribute");

                    }
                    else
                    {
                        TempData["Error"] = "Already Posted";
                        ModelState.Clear();
                        return RedirectToAction("AddTribute");
                    }

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
            try
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        [Route("DisplayCategories")]
        public IActionResult DisplayCategories()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
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
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorized Access" });
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
                if (HttpContext.Session.GetString("Role") == "User")
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
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorized Access" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [Route("ViewAllTributes")]
        [HttpGet]
        public IActionResult ViewAllTributes()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                {
                    List<Tribute> tributes = _user.GetTributes();
                    return View(tributes);
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
        [HttpGet]
        [Route("ViewTributeDetails")]
        public IActionResult ViewTributeDetails(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                {
                    ViewData["Comments"] = _admin.GetCommentsofTribute(id);
                    Tribute tribute = _admin.GetTributeById(id);
                    User user = _admin.GetUserById(tribute.UserId);
                    ViewBag.Author = user.UserName;
                    return View(tribute);
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
        [HttpGet]
        [Route("GetTributeById")]
        public IActionResult GetTributeById(int tId)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                {
                    Tribute tribute = _user.GetTributeById(tId);
                    return View(tribute);
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
        [HttpGet]
        [Route("SearchForTribute")]
        public IActionResult Search()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                { 
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
        [Route("SearchForTribute")]
        public IActionResult Search(string SearchValue)
        {
            try
            {
                if (SearchValue != null)
                {
                    List<Tribute> tributes = _user.GetTributes(SearchValue);
                    if (tributes.Count > 0)
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
        public IActionResult GetTributeByName(string tName)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                {
                    Tribute tribute = _user.GetTributeByName(tName);
                    return View(tribute);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorized Access"});
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        public IActionResult DeleteTribute(int tId)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User")
                { 
                    _user.DeleteTribute(tId);
                return RedirectToAction("GetTributeByUser");
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
        public IActionResult DeleteUser(int tId)
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User") 
                { 
                    _admin.DeleteUser(tId);
                return RedirectToAction("UserHomePage");
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
        public IActionResult UserDashboard()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == "User") 
                {
                    int UserId = (int)HttpContext.Session.GetInt32("UserId");
                    List<Tribute> postedTributes = _user.GetTributeByUser(UserId);
                    List<Tribute> tributes = _user.GetTributes();
                    List<Tribute> suggestedTributes = new List<Tribute>();
                    Random rnd = new Random();
                    for (int i = 1; i <= 8; i++)
                    {
                        int index = rnd.Next(tributes.Count);
                        suggestedTributes.Add(tributes.ElementAt(index));
                        tributes.RemoveAt(index);
                    }
                    ViewData["Suggestions"] = suggestedTributes;
                    return View(postedTributes);
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
        [Route("GetTributeByUser")]
        [HttpGet]
        public IActionResult GetTributeByUser()
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                List<Tribute> tribute = _user.GetTributeByUser(UserId);
                return View(tribute);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
     
        [HttpGet]
        [Route("DisplayUser")]
        public IActionResult DisplayUser()
        {
            try
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");
                ViewBag.TributesCount = _admin.GetCountOfTributesOfUser(UserId);
                User user = _user.getUserById(UserId);
                return View(user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        [HttpPost]
        [Route("PostFeedback")]
        public IActionResult AddFeedback(string rate, string comment, int id)
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
                if (HttpContext.Session.GetString("Role") == "User")
                {
                    Tribute tribute = _admin.GetTributeById(id);
                    return View(tribute);
                }
                else
                {
                    return RedirectToAction("Error", "Home", new { message = "UnAuthorizes Access" });
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
                _user.UpdateTribute(tribute);
                return RedirectToAction("GetTributeByUser");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
    }
}
