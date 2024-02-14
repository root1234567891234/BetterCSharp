using System;

namespace easycs
{
    class easy_string_ary (string[] content){
        public string[] ToArray()
        {
            return content;
        }
        public override string ToString()
        {
            string output = "";
            foreach(string i in content)
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
        public object inargs(string[] args,bool show_dic = false)
        {
            Dictionary<string,bool> check = new Dictionary<string,bool>();
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
            foreach(var i in args)
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
