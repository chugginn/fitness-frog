using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Treehouse.FitnessFrog.Shared.Models;
using Treehouse.FitnessFrog.Shared.Security;
using Treehouse.FitnessFrog.ViewModels;

namespace Treehouse.FitnessFrog.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public AccountController(ApplicationSignInManager signInManager, 
                                 ApplicationUserManager userManager,
                                 IAuthenticationManager authenticationManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterViewModel viewModel)
        {
            // If the ModelState is valid...
            if (ModelState.IsValid)
            {
                // verify that the user doesn't already exist
                var existingUser = await _userManager.FindByEmailAsync(viewModel.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", $"The provided email address '{viewModel.Email}' has already been used. Please sign-in using your existing account.");
                }
                else
                {
                    // Instantiate a User object
                    var user = new User { UserName = viewModel.Email, Email = viewModel.Email };

                    // Create the user
                    var result = await _userManager.CreateAsync(user, viewModel.Password);

                    // If the user was successfully created...
                    if (result.Succeeded)
                    {
                        // Sign-in the user and redirect them to the web app's "Home page"
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToAction("Index", "Entries");

                    }

                    // If there were errors...
                    // Add model errors
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View(viewModel);
        }
    }
}