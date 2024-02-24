using System;
using System.Collections.Generic;
namespace easycs
{
    class type
    {
        class defined_string<type>
        {
            private type content;
            private int count = 0;
            private int max;
            public defined_string(type arg, int use_count)
            {
                content = arg;
                max = use_count;
            }
            public override string ToString()
            {
                if (this.count > this.max) throw new Exception("string_count is over than string_max");
                else
                {
                    this.count++;
                    return this.content.ToString();
                }
            }
        }
        class unsinged<type>
        {
            int num;
            int max;
            type content;
            public unsinged(int arg, int max)
            {
                if (arg < 0 || arg > max) throw new Exception("unsinged error");
                else { this.num = arg; this.max = max; }
            }
            public unsinged(type arg, int max)
            {
                if (arg.ToString().Length > max || arg.ToString().Length < 0) throw new Exception("unsinged error");
                else { this.max = max; this.content = arg; }

            }
            public override string ToString()
            {
                if (this.content.ToString().Length > this.max || this.content.ToString().Length < 0) throw new Exception("unsinged error");
                else return this.content.ToString();
            }
            public int ToInt()
            {
                if (this.num < 0 || this.num > this.max) throw new Exception("unsinged error");
                else return this.num;
            }
        }
        class easy_string_ary
        {
            private string[] content;
            easy_string_ary(string[] arg)
            {
                content = arg;
            }
            public string[] ToArray()
            {
                return content;
            }
            public override string ToString()
            {
                string output = "";
                foreach (string i in content)
                {
                    output += i + " ";
                }
                return output;
            }
            private static easy_string_ary sum_string_ary_by_ary(string[] input_1, string[] input_2)
            {
                List<string> output = new List<string>();
                foreach (string i in input_1)
                {
                    output.Add(i);
                }
                foreach (string j in input_2)
                {
                    output.Add(j);
                }
                return new easy_string_ary(output.ToArray());
            }
            public bool inarg(string arg)
            {
                bool check = false;
                foreach (var i in content)
                {
                    if (i == arg) { check = true; break; }
                }
                return check;
            }
            public object inargs(string[] args, bool show_dic = false)
            {
                Dictionary<string, bool> check = new Dictionary<string, bool>();
                bool check_sub = true;
                foreach (var i in args)
                {
                    check.Add(i, false);
                }
                foreach (var j in content)
                {
                    foreach (var k in args)
                    {
                        if (j == k)
                        {
                            check.Remove(k);
                            check.Add(k, true);
                        }
                    }
                }
                if (show_dic)
                {
                    return check;
                }
                foreach (var i in args)
                {
                    if (!check[i])
                    {
                        check_sub = false;
                    }
                }
                return check_sub;
            }
            public easy_string_ary split_ary(int start, int end)
            {
                int i = 0;
                List<string> output = new List<string>();
                foreach (string line in content)
                {
                    if ((i >= start) && (i <= end))
                    {
                        output.Add(line);
                    }
                    i++;
                }
                return new easy_string_ary(output.ToArray());
            }
            public static easy_string_ary operator +(easy_string_ary a, easy_string_ary b)
            {
                return sum_string_ary_by_ary(a.ToArray(), b.ToArray());
            }
        }
    }
}