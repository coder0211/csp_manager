using System;
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
    }
}
