using GreenwichPrimesMeats.Data;
using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Enums;
using GreenwichPrimesMeats.Models.Users;
using GreenwichPrimesMeats.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

namespace GreenwichPrimesMeats.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserHelper _userHelper;
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;

        public AccountController(ILogger<AccountController> logger, IUserHelper userHelper, DataContext context, IBlobHelper blobHelper)
        {
            _logger = logger;
            _userHelper = userHelper;
            _context = context;
            _blobHelper = blobHelper;

        }
        public async Task<IActionResult> AdminsIndex()
        {
            var users = await _context.Users.ToListAsync();
            ICollection<User> result = new List<User>();
            foreach (var i in users)
            {
                if (i.UserType.ToString().Equals("Admin"))
                {
                    result.Add(i);
                }
            }

            return View(result);
        }
        public async Task<IActionResult> EmployedIndex()
        {
            var users = await _context.Users.ToListAsync();
            ICollection<User> result = new List<User>();
            foreach (var i in users)
            {
                if (i.UserType.ToString().Equals("Employed"))
                {
                    result.Add(i);
                }
            }

            return View(result);
        }
        public async Task<IActionResult> UsersIndex()
        {
            var users = await _context.Users.ToListAsync();
            ICollection<User> result = new List<User>();
            foreach (var i in users)
            {
                if (i.UserType.ToString().Equals("User"))
                {
                    result.Add(i);
                }
            }

            return View(result);
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email or Password don't MACTH");
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult NotAuthorized()
        {
            return View();
        }
        public async Task<IActionResult> RegisterAdmin()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Id = Guid.Empty.ToString(),
                UserType = UserType.Admin,
            };

            return View(model);
        }
        public async Task<IActionResult> RegisterEmployed()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Id = Guid.Empty.ToString(),
                UserType = UserType.Employed,
            };

            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            AddUserViewModel model = new AddUserViewModel
            {
                Id = Guid.Empty.ToString(),
                UserType = UserType.User,
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImageFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "users");
                }

                model.ImageId = imageId;

                User user = await _userHelper.AddUserAsync(model);


                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is alredy Used");
                    return View(model);
                }

                LoginViewModel loginViewModel = new LoginViewModel
                {
                    Password = model.Password,
                    RememberMe = false,
                    Username = model.Username
                };

                var result2 = await _userHelper.LoginAsync(loginViewModel);

                if (result2.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> RegisterService(string id)
        {
            /*if (email == null)
            {
                return NotFound();
            }*/
           // var email = await _context.Users.FindAsync(id);
            var user = await _userHelper.GetUserIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ServiceUserViewModel model = new()
            {
                UserId = user.Id,
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> RegisterService(ServiceUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                Service service = new()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type,
                    TypeDescription = model.TypeDescription,
                    PriceService = model.PriceService,
                };
                _context.Services.Add(service);
                try
                {                  
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "The employed have this service");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

                return View(model);

            }
            return View();
        }

    }
}
