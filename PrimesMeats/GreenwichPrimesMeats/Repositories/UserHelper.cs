using GreenwichPrimesMeats.Data;
using GreenwichPrimesMeats.Data.Entities;
using GreenwichPrimesMeats.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace GreenwichPrimesMeats.Repositories
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
		public async Task<User> AddUserAsync(AddUserViewModel model)
		{
            User user = new ()
            {
                Email = model.Username,
                Name = model.Name,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
				ImageId = model.ImageId,
				UserName = model.Username,
				UserType = model.UserType,
                Street = model.Street,
                ZipCode = model.ZipCode,
                DateTimeCreation= DateTime.Now,
			};


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            User newUser = await GetUserAsync(model.Username);
            await AddUserToRoleAsync(newUser, user.UserType.ToString());
            return newUser;
        }
		

		public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);

        }
       

        public async  Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async  Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }

        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
           .FirstOrDefaultAsync(u => u.Email == email);

        }

        public  async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);

        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
                return await _signInManager.PasswordSignInAsync(
           model.Username,
           model.Password,
           model.RememberMe,
           false);

        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }
}
