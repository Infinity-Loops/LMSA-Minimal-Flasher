using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSA
{
    public static class FileUtils
    {
        public static long GetFileSize(this string FilePath)
        {
            if (File.Exists(FilePath))
            {
                var a = new FileInfo(FilePath).Length;
                a = a / (1024 * 1024);
                return a;
            }
            return 0;
        }
    }
}
