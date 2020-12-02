using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2020Core
{
    public class ReadInput
    {
        public static List<int> ConvertInputTextToIntList(string path)
        {
            List<int> outputList = null;

            try
            {
                var sr = new StreamReader(path);
                
                outputList = new List<int>();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    outputList.Add(int.Parse(line));
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
                Console.WriteLine(e.Message);
            }
            return outputList;
        }

        public static List<string> ConvertInputTextToStringList(string path)
        {
            List<string> outputList = null;

            try
            {
                var sr = new StreamReader(path);

                outputList = new List<string>();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    outputList.Add(line);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred whilst loading {Path.GetFullPath(path)}.");
                Console.WriteLine(e.Message);
            }
            return outputList;
        }
    }
}
