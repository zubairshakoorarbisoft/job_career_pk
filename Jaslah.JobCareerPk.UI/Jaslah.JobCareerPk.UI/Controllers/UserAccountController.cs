using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jaslah.JobCareerPk.UI.Data;
using Jaslah.JobCareerPk.UI.Models;
using Jaslah.JobCareerPk.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Jaslah.JobCareerPk.UI.Controllers
{
    [AllowAnonymous]
    public class UserAccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserAccountController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            SignUpViewModel model = new SignUpViewModel()
            {
                IndustryTypes = _context.IndustryTypes.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            ModelState.Clear();
            if (model.RoleId == 1)
            {
                if (string.IsNullOrWhiteSpace(model.FirstName))
                    ModelState.AddModelError("FirstName", "First Name is Required");
                if (string.IsNullOrWhiteSpace(model.LastName))
                    ModelState.AddModelError("LastName", "Last Name is Required");
                if (string.IsNullOrWhiteSpace(model.KeySkills))
                    ModelState.AddModelError("KeySkills", "Key Skills are Required");
            }
            else if (model.RoleId == 2)
            {
                if (string.IsNullOrWhiteSpace(model.EmployerName))
                    ModelState.AddModelError("EmployerName", "Employer/Company is Required");
            }
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.EmailAddress, Email = model.EmailAddress, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //User created a new account with password.
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    // Sending Confirmation Email

                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    // Checking if Email Confirmation is Required then Redirect to Confirm Email otherwise loggin to the system

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}

                    // Adding User in to the Role he/she selected
                    IdentityRole role = await _roleManager.FindByNameAsync(model.RoleId == 1 ? "Employee" : "Employer");
                    var createRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
                    if (createRoleResult.Succeeded)
                    {
                        if (model.RoleId == 1)
                        {
                            _context.Employees.Add(new Employee()
                            {
                                FirstName = model.FirstName,
                                MiddleName = model.MiddleName,
                                LastName = model.LastName,
                                Address = model.Address,
                                ContactNumber = model.ContactNumber,
                                LastDegree = model.LastDegree,
                                Age = model.Age,
                                JobTypeId = model.IndustryTypeId,
                                KeySkills = model.KeySkills,
                                UserId = user.Id
                            });
                        }
                        else
                        {
                            _context.Employers.Add(new Employer()
                            {
                                EmployerName = model.EmployerName,
                                Address = model.Address,
                                ContactNumber = model.ContactNumber,
                                UserId = user.Id
                            });
                        }

                        await _context.SaveChangesAsync();

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        model.IndustryTypes = _context.IndustryTypes.ToList();
                        return View(model);
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    model.IndustryTypes = _context.IndustryTypes.ToList();
                    return View(model);
                }
            }
            else
            {
                model.IndustryTypes = _context.IndustryTypes.ToList();
                return View(model);
            }
        }
    }
}
