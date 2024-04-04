using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_system
{
    class Program
    {
        static User currentUser = null;
        static void Main(string[] args)
        {
            Parser.ReadFile();

            while (true)
            {
                Console.WriteLine("1. Sign up\n2. Login\n3. Change Username\n4. Change Password\n5. register log\n6. See log n\n7. see report username");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        if (currentUser.Lvl == User.securityLvl.Lvl2)
                        {
                            new User();
                        }
                        else
                        {
                            Console.WriteLine("Please enter as an admin");
                        }
                        break;
                    case 2:
                        currentUser = User.GetUser();
                        break;
                    case 3:
                        if (currentUser != null)
                        {
                            currentUser.ChangeUserName();
                        }
                        else
                        {
                            Console.WriteLine("please enter as a user");
                        }
                        break;
                    case 4:
                        if (currentUser != null)
                        {
                            currentUser.ChangePassword();
                        }
                        else
                        {
                            Console.WriteLine("please enter as a user");
                        }
                        break;
                    case 5:
                        Console.Write("What do you want to write in the log file?: ");
                        Log.Write(Console.ReadLine());
                        Log.Write($"{currentUser.username} wrothe something in the log file");
                        break;
                    case 6:
                        //exeption handling!!!!
                        if (currentUser.Lvl == User.securityLvl.Lvl2)
                        {
                            Console.Write("Enter the number n: ");
                            int n = int.Parse(Console.ReadLine());
                            Log.Read(n);
                        }
                        else
                        {
                            Console.WriteLine("Please enter as an admin to see the logs");
                        }
                        break;
                    case 7:
                        if (currentUser.Lvl == User.securityLvl.Lvl2)
                        {
                            Console.Write("Username: ");
                            Log.Read(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("please enter as an admin");
                        }
                        break;
                    default:
                        Console.WriteLine("Please Enter a correct number");
                        break;
                }
                Parser.SaveFile();
            }
        }
    }
}
