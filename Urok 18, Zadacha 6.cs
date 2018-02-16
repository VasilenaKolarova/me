using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spisuchen_manipulator_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> rezult = new List<int>();
            int pos = 0;
            string command = Console.ReadLine();
            while (command != "print")
            {
                List<string> comm = command.Split(' ').ToList();
                if (comm[0] == "sumPairs")
                {
                    for (int i = 0; i < nums.Count; i+=2)
                    {
                        rezult[pos] = nums[i] + nums[i + 1];
                        pos++;
                    }
                    nums = rezult;
                    
                }
                else
                {
                    List<int> element = new List<int>();
                    for (int i = 1; i < comm.Count; i++)
                    {
                        element.Add(Convert.ToInt32(comm[i]));
                    }
                    if (comm[0] == "add")
                    {
                        nums.Insert(element[0], element[1]);
                    }
                    else if (comm[0] == "addMany")
                    {
                        for (int i = 1; i < element.Count; i++)
                        {
                            nums.Insert(element[0], element[i]);
                        }
                    }
                    else if (comm[0] == "contains")
                    {
                        bool a = true;
                        for (int i = 0; i < nums.Count; i++)
                        {
                            if (element[0] == nums[i])
                            {
                                Console.WriteLine(i);
                                a = false;
                                break;

                            }
                            
                        }
                        if (a == true)
                        {
                            Console.WriteLine("-1");
                        }
                    }
                    else if (comm[0] == "remove")
                    {
                        nums.RemoveAt(element[0]);
                    }
                    else if (comm[0] == "shift")
                    {
                        List<int> rezult1 = new List<int>();
                        for (int j = 0; j < 1; j++)
                        {
                            int position = element[0] - 1;

                            for (int i = nums.Count - 1; i > nums.Count - element[0]; i--)
                            {
                                rezult1[i] = nums[position];
                                position--;
                            }
                            for (int i = 0; i < nums.Count - element[0]; i++)
                            {
                                rezult1[i] = nums[i + element[0]];
                            }
                            
                        }
                        nums = rezult1;
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join("[" + ", ", nums + "]"));
        }
    }
}
