using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02
{
    class UsersManager
    {
        private List<Models.User> users;

        public List<Models.User> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
            }
        }

        public UsersManager()
        {
            BuildList();
            Console.WriteLine("Starting with this list:");
            PrintList();
            PrintUsernameWithHelloPassword();
            RemovePasswordEqualsUsername();
            RemoveFirstHelloPassword();
            Console.WriteLine("\nThe following list is what remains:");
            PrintList();
        }

        public void BuildList()
        {
            users = new List<Models.User>();
            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });
        }

        private void PrintUsernameWithHelloPassword()
        {
            List<Models.User> temp = users.Where(i => i.Password == "hello").ToList();
            foreach(var item in temp)
            {
                Console.WriteLine("{0} has the password of 'hello'", item.Name);
            }
            Console.WriteLine("\n");
        }

        private void RemovePasswordEqualsUsername()
        {
            users.RemoveAll(i => i.Password == i.Name.ToLowerInvariant());
        }

        private void RemoveFirstHelloPassword()
        {
            string nameToDelete = users.Where(i => i.Password == "hello").Select(j => j.Name).FirstOrDefault();

            users.RemoveAll(i => i.Name == nameToDelete);
        }

        private void PrintList()
        {
            Console.WriteLine("User\tPass");
            Console.WriteLine("-------------------------------------------");
            foreach(var item in users)
            {
                Console.WriteLine("{0}\t{1}", item.Name, item.Password);
            }
            Console.WriteLine("\n");
        }
    }
}
