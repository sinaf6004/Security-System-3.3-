using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Security_system
{
    [Serializable]
    class Parser
    {
        public static void SaveFile()
        {
            FileStream stream = new FileStream(@"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Users.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, User.users);
            stream.Close();
        }
        public static void ReadFile()
        {
            FileStream fs = null;
            try {
                fs = File.Open(@"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Users.txt", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                User.users = (List<User>)formatter.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                if(fs!= null)
                {
                    fs.Close();
                }
            }



            for (int i = 0; i < User.users.Count; i++)
            {
                if (!CheckKey1(User.users[i].id, User.users[i])){
                    User.users.RemoveAt(i);
                    //write in log
                }
            }
        }
        //only Id reminder!!!!
        public static bool CheckKey1(int Id, User user)
        {
            if (user.key[0] == (char)(((Id * 11) % 26) + 'a'))
            {
                if (CheckKey2(Id, user))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckKey2(int Id, User user)
        {
            if (user.key[1] == (char)(((Id * 46) % 26) + 'a'))
            {
                if (CheckKey3(Id, user))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckKey3(int Id, User user)
        {
            if (user.key[2] == (char)(((Id * 98) % 26) + 'a'))
            {
                if (CheckKey4(Id, user))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckKey4(int Id, User user)
        {
            if (user.key[3] == (char)(((Id * 2) % 26) + 'a'))
            {
                if (CheckKey5(Id, user))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckKey5(int Id, User user)
        {
            if (user.key[4] == (char)(((Id * 314) % 26) + 'a'))
            {
                return true;
            }
            return false;
        }


    }
}
