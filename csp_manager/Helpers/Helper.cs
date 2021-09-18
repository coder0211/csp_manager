using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSChat.Helpers
{
    class Helper
    {
        private string stringKey = ".... --- .- .--. .... .- - -- .. -. .... -.-. ... -.-. .... .- -";

        public string StringKey { get => stringKey; }

        public static string XORCipher(string data, string key)
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];

            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }

            return new string(output);
        }
    }

}
