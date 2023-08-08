using CaseStudy.Entities;
using Microsoft.AspNetCore.Identity;
using CaseStudy.DTOs;
namespace CaseStudy.Service
{
    public interface IUserService
    {
        void SignUp(User user);

        User Login(string userName, string password);


        void ForgotPassword(ForgotPasswordDTO userdto);

        User GetUserByName(string name);

        List<User> GetUsersList();

    }
}
