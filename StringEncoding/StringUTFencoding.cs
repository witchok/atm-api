using System;
using System.Collections.Generic;
using System.Text;

namespace StringEncoding
{
    public static class StringUTFencoding
    {
        public static string EncodeForUTF8(this string text)
        {
            return System.Text.Encoding.UTF8.EncodeBase64(text);
        }

        public static string DecodeForUTF8(this string text)
        {
            return System.Text.Encoding.UTF8.DecodeBase64(text);
        }
    }
}
