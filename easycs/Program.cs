using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
namespace easycs
{
    public class unsinged<type> : IDisposable
    {
        public type num { get; set; }
        public double rnum { get; set; }

        public static implicit operator int(unsinged<type> from) { return from.ToInt(); }
        public static implicit operator string(unsinged<type> from) { return from.ToString(); }
        public static implicit operator double(unsinged<type> from) { return from.ToDouble(); }
        public static implicit operator unsinged<type>(type from) { return new unsinged<type>(from); }
        public unsinged(type arg)
        {
            double dpi = (double)Convert.ToDouble(arg.ToString());
            if (dpi < 0) throw new Exception("unsinged error");
            else { this.rnum = dpi; this.num = arg;}
        }
        public override string ToString()
        {
            if (this.rnum < 0) throw new Exception("unsinged error");
            else return this.num.ToString();
        }
        public int ToInt()
        {
            if (this.rnum < 0) throw new Exception("unsinged error");
            else return Convert.ToInt32(this.num.ToString());
        }
        public double ToDouble()
        {
            if (this.rnum < 0) throw new Exception("unsinged error");
            else return Convert.ToDouble(this.num);
        }
        public void Dispose()
        {
            this.num = default(type);
            this.rnum = default(double);
        }
    }
    public class @string : IDisposable
    {
        public string value { get; set; }
        public @string(string arg) => this.value = arg;
        public static implicit operator int(@string from) { return from.ToInt(); }
        public static implicit operator string(@string from) { return from.ToString(); }
        public static implicit operator double(@string from) { return from.ToDouble(); }
        public static implicit operator @int(@string from) { return new @int(from.ToInt()); }
        public static implicit operator @double(@string from) { return new @double(from.ToDouble()); }
        public static implicit operator @string(string from) { return new @string(from); }
        public static implicit operator @string(char from) { return from.ToString(); }
        public static implicit operator @string(char[] from)
        {
            @string output = "";
            foreach (char c in from) output += c;
            return output;
        }
        public override string ToString() { return this.value; }
        public @string[] Split(char keyword)
        {
            @string index = "";
            List<@string> output = new List<@string>();
            foreach (char s in this.value)
            {
                if (s.Equals(keyword))
                {
                    output.Add(index);
                    index = "";
                    continue;
                }
                index += s;
            }
            output.Add(index);
            return output.ToArray();
        }
        public string[] ToArray(@string[] arg)
        {
            List<string> output = new List<string>();
            foreach (@string s in arg) output.Add(s.value);
            return output.ToArray();
        }
        public @string[] @ToArray(string[] arg)
        {
            List<@string> output = new List<@string>();
            foreach (string s in arg) output.Add(s);
            return output.ToArray();
        }
        public @string Replace(char oldkeyword,char newkeyword)
        {
            this.value = this.value.Replace(oldkeyword,newkeyword);
            return this;
        }
        public @string Remove(int index)
        {
            this.value = this.value.Remove(index);
            return this;
        }
        public int ToInt() { return (int)Convert.ToInt16(this.value); }
        public double ToDouble() { return (double)Convert.ToDouble(this.value); }
        public static @string operator +(@string a, @string b) { return new @string(a.ToString() + b.ToString()); }
        public void Dispose()
        {
            this.value = default(string);
        }
    }
    public struct @int : IDisposable
    {
        public int value { get; set; }
        public @int(int arg) => this.value = arg;
        public static implicit operator int(@int from) { return from.ToInt(); }
        public static implicit operator string(@int from) { return from.ToString(); }
        public static implicit operator double(@int from) { return from.ToDouble(); }
        public static implicit operator @string(@int from) { return new @string(from.ToString()); }
        public static implicit operator @double(@int from) { return new @double(from.ToDouble()); }
        public static implicit operator @int(int from) { return new @int(from); }
        public override string ToString() { return this.value.ToString(); }
        public int ToInt() { return this.value; }
        public int ToDouble() { return (int)Convert.ToDouble(this.value); }
        public static @int operator ++(@int a) { return new @int(a.ToInt() + 1); }
        public static @int operator --(@int a) { return new @int(a.ToInt() - 1); }
        public static @int operator +(@int a, @int b) { return new @int(a.ToInt() + b.ToInt()); }
        public static @int operator -(@int a, @int b) { return new @int(a.ToInt() - b.ToInt()); }
        public static @int operator /(@int a, @int b) { return new @int(a.ToInt() / b.ToInt()); }
        public static @int operator *(@int a, @int b) { return new @int(a.ToInt() * b.ToInt()); }
        public void Dispose()
        {
            this.value = default(int);
        }
    }
    public struct @double : IDisposable
    {
        public double value { get; set; }
        public @double(double arg) => this.value = arg;
        public static implicit operator int(@double from) { return from.ToInt(); }
        public static implicit operator string(@double from) { return from.value.ToString(); }
        public static implicit operator double(@double from) { return from.ToDouble(); }
        public static implicit operator @int(@double from) { return new @int(from.ToInt()); }
        public static implicit operator @string(@double from) { return new @string(from.ToString()); }
        public static implicit operator @double(double from) { return new @double(from); }
        public double ToDouble() { return this.value; }
        public int ToInt() { return (int)this.Round(); }
        public int Round() { return (int)Math.Round(this.value); }
        public int upper() { return (int)Math.Ceiling(this.value); }
        public int lower() { return (int)Math.Truncate(this.value); }
        public override string ToString() { return this.value.ToString(); }

        public static @double operator ++(@double a) { return new @double(a.ToDouble() + 1.0); }
        public static @double operator --(@double a) { return new @double(a.ToDouble() - 1.0); }
        public static @double operator +(@double a, @double b) { return new @double(a.ToDouble() + b.ToDouble()); }
        public static @double operator -(@double a, @double b) { return new @double(a.ToDouble() - b.ToDouble()); }
        public static @double operator /(@double a, @double b) { return new @double(a.ToDouble() / b.ToDouble()); }
        public static @double operator *(@double a, @double b) { return new @double(a.ToInt() * b.ToDouble()); }
        public void Dispose()
        {
            this.value = default(double);
        }
    }
    class tool
    {
        public static string[] sum_string_ary_by_ary(string[] input_1, string[] input_2)
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
            return output.ToArray();
        }
        public static bool inarg(string[] content, string arg)
        {
            bool check = false;
            foreach (var i in content)
            {
                if (i == arg) { check = true; break; }
            }
            return check;
        }
        public static object inargs(string[] content, string[] args, bool show_dic = false)
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
        public static string[] split_ary(string[] content, int start, int end)
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
            return output.ToArray();
        }
    }
}
