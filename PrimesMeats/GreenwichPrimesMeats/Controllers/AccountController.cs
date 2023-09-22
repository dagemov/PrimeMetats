﻿using GreenwichPrimesMeats.Data;
using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Enums;
using GreenwichPrimesMeats.Models.Users;
using GreenwichPrimesMeats.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace GreenwichPrimesMeats.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
		private readonly DataContext _context;
		private readonly IBlobHelper _blobHelper;

		public AccountController(IUserHelper userHelper, DataContext context,  IBlobHelper blobHelper)
        {
            _userHelper = userHelper;
			_context = context;
			_blobHelper = blobHelper;

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

    }
}
