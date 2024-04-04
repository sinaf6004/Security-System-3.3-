using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_system
{
    [Serializable]
    class User
    {
        public static List<User> users = new List<User>();
        public enum securityLvl { Lvl1, Lvl2 }
        securityLvl lvl;
        public securityLvl Lvl { get => lvl; }
        public string username { get => UserName;}
        int Id;
        public int id { get => Id; }
        string UserName;
        string Password;
        string Key;
        public string key { get => Key; }
        //constructor
        public User()
        {
            while (true)
            {
                Console.Write("Security level(1. level1, 2. level2): ");
                try
                {
                    lvl = (securityLvl)(int.Parse(Console.ReadLine())-1);
                    break;
                }
                catch
                {

                }
            }
            while (true)
            {

                Console.Write("Id: ");
                try
                {
                    Id = int.Parse(Console.ReadLine());
                    if (Id > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number greater than 0");
                    }

                }
                catch
                {
                    Console.WriteLine("Please enter a number");
                }
            }
            while (true)
            {
                Console.Write("UserName: ");
                UserName = Console.ReadLine();
                int t = 0;
                foreach (User user in users)
                {
                    if (!(user == this))
                    {
                        if (user.UserName == UserName)
                        {
                            Console.WriteLine("This username already exists");
                            t = 1;
                            break;
                        }

                    }
                }
                if(t == 0)
                {
                    break;
                }

            }
            Console.Write("Password: ");
            Password = Console.ReadLine();
            Key = KeyMaker(Id);
            users.Add(this);
        }

        //Methods
        public string KeyMaker(int Id)
        {
            char[] String = new char[5];
            String[0] = (char)(((Id * 11) % 26) + 'a');
            String[1] = (char)(((Id * 46) % 26) + 'a');
            String[2] = (char)(((Id * 98) % 26) + 'a');
            String[3] = (char)(((Id * 2) % 26) + 'a');
            String[4] = (char)(((Id * 314) % 26) + 'a');
            return new string(String);
        }

        public static User GetUser()
        {
            Console.Write("UserName: ");
            string UserName = Console.ReadLine();
            foreach (User user in users)
            {
                if (user.UserName == UserName)
                {
                    Console.Write("Password: ");
                    string Password = Console.ReadLine();
                    if (Password == user.Password)
                    {
                        Console.WriteLine("Successfully logged in");
                        Log.Write($"A user whith {user.UserName} Username Logged in");
                        return user;
                    }
                    else
                    {
                        Console.WriteLine("Wrong password");
                        Log.Write($"A user whith {user.UserName} Username tryed to log in but entered a wrong username");
                        return null;
                    }

                }
            }
            Console.WriteLine("Could not find such a username");
            return null;
        }
        public void ChangeUserName()
        {
            while (true)
            {
                Console.Write("New UserName: ");
                UserName = Console.ReadLine();
                int t = 0;
                foreach (User user in users)
                {
                    if (user == this)
                    {

                    }
                    else
                    {
                        if (user.UserName == UserName)
                        {
                            Console.WriteLine("This username already exists");
                            t = 1;
                            break;
                        }
                        else
                        {

                        }
                    }
                }
                if(t == 0)
                {
                    Log.Write($"A user with {UserName} username changed the username");
                    break;
                }

            }

        }
        public void ChangePassword()
        {
            Console.Write("New password: ");
            Password = Console.ReadLine();
            Log.Write($"A user with {UserName} username changed the password");
        }
    }
}