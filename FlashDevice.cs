using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LMSA
{
    public class FlashDevice
    {
        public FlashDevice(string FastbootPath)
        {
            this.FastbootPath = FastbootPath;
        }
        string FastbootPath;
        public void FlashImage(string Partition, string Path)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = FastbootPath;
            process.StartInfo.Arguments = string.Format(@"flash {0} {1}", Partition, Path);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            while (!process.HasExited)
            {
               //handle process to wait
            }
        }
    }
}
