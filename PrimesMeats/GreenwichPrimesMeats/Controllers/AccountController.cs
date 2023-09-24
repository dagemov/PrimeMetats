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

		public AccountController(ILogger<AccountController> logger,IUserHelper userHelper, DataContext context,  IBlobHelper blobHelper)
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

				model.ImageId= imageId;

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
        public async Task<IActionResult> RegisterSchedule(string id)
        {
            if (id ==null)
            {
                return NotFound();
            }
            var user = await _userHelper.GetUserAsync(id);
            if (user ==null)
            {
                return NotFound();
            }
            return View(user);
            
        }
        [HttpPost]
        public async Task<IActionResult> RegisterSchedule(string id,EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (id == null || model == null)
                {
                    return NotFound();
                }
               // var schedule = 
            }
            return View();
        }

    }
}
