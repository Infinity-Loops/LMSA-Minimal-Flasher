using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSA
{
    public class Paths
    {
        public Paths()
        {
            SetupPaths();
        }
        public List<string> Path = new List<string>();
        public void SetupPaths()
        {
            Path.Add("Resources/Google/adb.exe");
            Path.Add("Resources/Google/AdbWinApi.dll");
            Path.Add("Resources/Google/AdbWinUsbApi.dll");
            Path.Add("Resources/Google/fastboot.exe");
            Path.Add("Resources/Google/libwinpthread-1.dll");
        }
    }
}
