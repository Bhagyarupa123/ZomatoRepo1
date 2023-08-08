
using CaseStudy.Entities;
using CaseStudy.DTOs;

namespace CaseStudy.Service
{
    public class UserService:IUserService
    {
        private readonly ZomatoDBContext _dbContext;

        public UserService(ZomatoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SignUp(User user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.users.Update(user);
            _dbContext.SaveChanges();
        }
        public User Login(string userName, string password)
        {
           var users= _dbContext.users.ToList();
           return users.SingleOrDefault(u => u.UserName == userName && u.Password == password);

        }

       

        public void ForgotPassword(ForgotPasswordDTO dto)
        {
            User user = _dbContext.users.SingleOrDefault(u => u.UserName == dto.UserName);
             user.Password =dto. NewPassword;
             _dbContext.users.Update(user);
             _dbContext.SaveChanges();
                
        }

        public User GetUserByName(string name)
        {
            User user = _dbContext.users.SingleOrDefault(u => u.UserName == name);
            return user;

        }

        public List<User> GetUsersList()
        {
            return _dbContext.users.ToList();
        }






    }


}
