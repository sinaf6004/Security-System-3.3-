using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Security_system
{
    class Log
    {
        //public Log()
        //{
        //    FileStream stream = new FileStream(@"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Log.txt", FileMode.Create);
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    formatter.Serialize(stream, User.users);
        //    stream.Close();
        //}
        public static void Write(string thing)
        {
            string filePath = @"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Log.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(thing);
            }
        }
        public static List<string> Read(int n)
        {
            List<string> st = new List<string>();
            try
            {
                List<string> linesList = File.ReadLines(@"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Log.txt").ToList();
                for (int i = linesList.Count - 1; i > linesList.Count - 1 - n; i--)
                {
                    st.Add(linesList[i]);
                    Console.WriteLine(linesList[i]);
                }
            }
            catch
            {

            }
            return st;
        }
        public static List<string> Read(string Username)
        {
            List<string> st = new List<string>();
            try
            {
                List<string> linesList = File.ReadLines(@"D:\elmos\AP\homeworks\tamrin 3\Security system\Security system\bin\Debug\Log.txt").ToList();
                foreach (var line in linesList)
                {
                    int t = 0;
                    foreach (var word in line.Split(' '))
                    {
                        if (word == Username)
                        {
                            t = 1;
                            break;
                        }
                    }
                    if(t == 1)
                    {
                        Console.WriteLine(line);
                        st.Add(line);
                    }
                }
            }
            catch
            {

            }
            return st;
        }










    }
}
