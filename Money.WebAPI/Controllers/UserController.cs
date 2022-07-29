using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Money.Domain.Entities.UserAggregate;
using Money.Domain.Repositories;
using Money.Services.Interfaces;
using Money.WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Money.WebAPI.Controllers
{
    //POST api/user/?
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager; //дозволяє аутентифікувати користувача и установляти или видаляти його куки.
        private IAuthenticationUser _authenticationUser;
        public UserController(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            IAuthenticationUser authenticationUser)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationUser = authenticationUser;
        }


        [HttpGet("get")]
        public async Task<ActionResult<User>> Get(string id)
        {
            if(await _userManager.IsEmailConfirmedAsync(await _userManager.FindByIdAsync(id)))
            {
                User user = await _userManager.FindByIdAsync(id);

                if(user != null)
                {
                    return new ObjectResult(user);
                }

                return NotFound("Користувач не знайдений");
            }

            return NotFound("Спочатку пройдіть аутентифікацію");
        }


        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] EditUserViewModel model)
        {
            if (await _userManager.IsEmailConfirmedAsync(await _userManager.FindByIdAsync(model.Id)))
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByIdAsync(model.Id);

                    if(user != null)
                    {
                        if (!RegisterViewModel.CheckUserName(model.Name))
                        {
                            return Content("Не коректне введене ім'я користовуча");
                        }

                        user.Name = model.Name;
                        //user.PhoneNumber = model.PhoneNumber;
                        
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            return Ok($"Користувач успішно змінив данні. {user}");
                        }
                        else
                        {
                            return Content("Щось пішло не так.");
                        }
                    }
                    else
                    {
                        return NotFound("Користувач не знайдений");
                    }
                }

                return ValidationProblem($"Не вірні введені дані. Count errors - {ModelState.ErrorCount}");
            }

            return NotFound("Спочатку пройдіть аутентифікацію");
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Ok(true);
                }
            }
            return NotFound("Користувач не знайдений");
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var _user = await _userManager.FindByEmailAsync(model.Email);
                
                if (RegisterViewModel.CheckUserName(model.Name))
                {
                    if(_user == null)
                    {
                        User user = new User() { Email = model.Email, UserName = model.Email, Name = model.Name };

                        try
                        {
                            var result = await _userManager.CreateAsync(user, model.Password);
                            if (result.Succeeded)
                            {
                                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                                var callbackUrl = Url.Action("ConfirmEmail", "User", new { userId = user.Id, code = code },
                                    protocol: HttpContext.Request.Scheme);

                                await _authenticationUser.SendMessageAsync(model.Email, "Підтвердження користувача",
                                    $"Підтвердіть реєстрацію по силці: <a href='{callbackUrl}'>НАЖМИ_НА_МЕНЕ</a>");

                                return Ok("Ви успішно зареєстровані, підтвердіть вашу пошту");
                            }
                        }
                        catch(Exception ex)
                        {
                            await _userManager.DeleteAsync(user);
                            
                            return NotFound($"Пошта не найдена. Exception - {ex.Message}");
                        }
                    }

                    return Content("Такий логін уже зайнятий");
                }

                return Content("Не коректне введене ім'я користовуча");
            }

            return ValidationProblem($"Не вірні введені дані. Count errors - {ModelState.ErrorCount}");
        }


        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user != null)
                {
                    if(!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        return Content("Підтвердіть вашу пошту для повної реєстрації");
                    }
                }
                else
                {
                    return Content("Такого користувача не знайдено");
                }

                /*This method does a lot more. Here's a rough breakdown:
                 1)Checks whether sign-in is allowed. For example, if the user must have a confirmed email 
                before being allowed to sign-in, the method returns SignInResult.Failed.
                 2)Calls UserManager.CheckPasswordAsync to check that the password is correct (as detailed above).
                If the password is not correct and lockout is supported, the method tracks the failed sign-in attempt. 
                If the configured amount of failed sign-in attempts is exceeded, the method locks the user out.
                 3)If two-factor authentication is enabled for the user, the method sets up the relevant cookie and returns SignInResult.TwoFactorRequired.
                 4)Finally, performs the sign-in process, which ends up creating a ClaimsPrincipal and persisting it via a cookie.*/

                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

                if (result.Succeeded)
                {
                    return Ok(user.Id);
                }
                else
                {
                    return Content("Не вірні введені дані (login or password).");
                }
            }

            return ValidationProblem($"Не вірні введені дані. Count errors - {ModelState.ErrorCount}");
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] UserViewModel model)
        {
            if (model.Id == null)
            {
                return Content("Не має кому виходити, такого користувача не існує");
            }

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user != null)
            {
                //За выход отвечает метод _signInManager.SignOutAsync(), который очищает аутентификационные куки.
                await _signInManager.SignOutAsync();

                return Ok(true);
            }

            return Content("Не має кому виходити, такого користувача не існує");
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if(userId == null || code == null)
            {
                return Content("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return Content("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return Ok("Пошта підтверджена");
            }
            else
            {
                return Content("Пошта не підтверджена");
            }
        }
    }
}
