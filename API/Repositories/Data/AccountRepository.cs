using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public Login Get(string email, string password)
        {
            var data = myContext.Role_User.
                Include(x => x.User).
                Include(x => x.User.Employee).
                Include(x => x.Role).
                Where(x => x.User.Email == email).
                Where(x => x.User.Password == password).
                ToList();

            Login login = new Login();
            login.Id = data.FirstOrDefault().User.Id;
            login.Email = data.FirstOrDefault().User.Email;
            login.Password = data.FirstOrDefault().User.Password;

            foreach (var item in data)
            {
                login.Role.Add(item.Role);
            }

            return login;
        }

        public Login Post(string email, string password)
        {
            var data = myContext.Role_User.
                Include(x => x.User).
                Include(x => x.User.Employee).
                Include(x => x.Role).
                Where(x => x.User.Email == email).
                Where(x => x.User.Password == password).
                ToList();

            Login login = new Login();
            login.Id = data.FirstOrDefault().User.Id;
            login.Email = data.FirstOrDefault().User.Email;
            login.Password = data.FirstOrDefault().User.Password;

            foreach (var item in data)
            {
                login.Role.Add(item.Role);
            }

            return login;
        }

        public User Get(int id)
        {
            var data = myContext.User.Find(id);
            return data;
        }

        public int Post(User user)
        {
            myContext.User.Add(user);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Put(User user)
        {
            myContext.User.Update(user);
            var data = myContext.SaveChanges();
            return data;
        }
    }
}
