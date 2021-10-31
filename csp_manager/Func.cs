﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace csp_manager
{
    class Func
    {
        public string NumberToStr(int number)
        {
            return string.Format("{0:n0}", number);
        }
        public string NumberToStr(long number)
        {
            return string.Format("{0:n0}", number);
        }

        private static Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void InitProperties(object obj)
        {
            foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite))
            {
                var type = prop.PropertyType;
                var constr = type.GetConstructor(Type.EmptyTypes); //find paramless const
                if (type.IsClass && constr != null)
                {
                    var propInst = Activator.CreateInstance(type);
                    prop.SetValue(obj, propInst, null);
                    InitProperties(propInst);
                }
            }
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
