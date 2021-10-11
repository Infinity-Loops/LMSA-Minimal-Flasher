using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace LMSA
{
    public class InControlConsole
    {
        public class Console { 
            public static void WriteLine(string Pointer, string Data,ref RichTextBox CR)
            {
                if(CR.Text.Length != 0)
                {
                    CR.Text += string.Format("\n[{1}] {0}:~ {2}", Pointer, DateTime.Now.ToString("hh:mm"), Data);
                } else
                {
                    CR.Text += string.Format("[{1}] {0}:~ {2}", Pointer, DateTime.Now.ToString("hh:mm"), Data);
                }
                
            }
        }

    }
}
