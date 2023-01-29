using PX.Objects.CA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeamDelta2023
{
    public class FileIndexer
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool FreeLibrary(IntPtr hModule);
        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = false)]
        internal static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        // delegate
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int ExtractText(
          [MarshalAs(UnmanagedType.BStr)] String lpFileName,
          bool bProp,
          [MarshalAs(UnmanagedType.BStr)] ref String lpFileText);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int ExtractTextEx(
          [MarshalAs(UnmanagedType.BStr)] String lpFileName,
          bool bProp,
          [MarshalAs(UnmanagedType.BStr)] String lpOptions,
          [MarshalAs(UnmanagedType.BStr)] ref String lpFileText);

        public static string GetFileText(string FileName)
        {
            int l;

            string fileText = "";
            IntPtr handle = LoadLibrary(AppContext.BaseDirectory + "\\Bin\\xd2txlib.dll");
            /*
                            IntPtr funcPtr = GetProcAddress(handle, "ExtractText");
                            ExtractText extractText = (ExtractText)Marshal.GetDelegateForFunctionPointer(funcPtr, typeof(ExtractText));
                            l = extractText(ofd.FileName, false, ref fileText);
            */
            IntPtr funcPtr = GetProcAddress(handle, "ExtractTextEx");
            ExtractTextEx extractText = (ExtractTextEx)Marshal.GetDelegateForFunctionPointer(funcPtr, typeof(ExtractTextEx));
            l = extractText(FileName, false, "", ref fileText);
            FreeLibrary(handle);
            return fileText.Substring(0, Math.Min(2048, fileText.Length));
        }
        public Dictionary<string,int> KeywordMatches(string keywordData,string FileText)
        {
            var retVal=new Dictionary<string,int>();
            var keywords = keywordData.Split(',');
            foreach (var word in keywords)
            {
                var result = Regex.Matches(FileText, word);
                //MessageBox.Show(string.Format("Found {0}: {1} times", word, result.Count));
                retVal.Add(word, result.Count);
            }
            return retVal;
        }

    }
}
