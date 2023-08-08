using CaseStudy.Entities;
using CaseStudy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CaseStudy.Controllers;
using CaseStudy.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
        private static List<User> formData = new List<User>();
        [HttpPost]
        [Route("SignUp")]
        public IActionResult AddUser([FromBody]User formData)
        {

            try
            {
                List<User> usersList = UserService.GetUsersList();
                foreach(var item in usersList)
                {
                    if (item.UserName == formData.UserName)
                    {
                        return StatusCode(400, "User alreay exists, Try with another name!");
                       
                    }
                   
                }
                UserService.SignUp(formData);
                return StatusCode(200, formData);

            }
            catch(Exception) {
                throw;
            }
        }

        [HttpPost, Route("ForgotPassword")]

        public IActionResult ForgotPassword(ForgotPasswordDTO dto)
        {
            try
            {
                User user = UserService.GetUserByName(dto.UserName);
                if (user != null)
                {
                    if( dto.NewPassword== dto.ConfirmPassword )
                    {
                        UserService.ForgotPassword(dto);
                        return StatusCode(200, "Password Successfully updated");

                    }
                    else
                    {
                        return StatusCode(400, "Username and password must match");
                    }
                }
                else
                {
                    return StatusCode(400, "user not found");
                }

              
            }
            catch(Exception)
            {
                throw;
            }
        }
 

       
    }
}
