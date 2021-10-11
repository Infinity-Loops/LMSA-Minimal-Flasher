using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LMSA
{
    public class FlashReader
    {
        public FlashReader(string path)
        {
            this.path = path;
            Read();
        }
        string path;
        public string DeviceName { get; private set; }
        public bool Sparsing { get; private set; }
        public List<string> RomFiles { get; private set; } = new List<string>();
        public List<string> RomPartitions { get; private set; } = new List<string>();
        public void Read()
        {
            string[] FlashLines = File.ReadAllLines(path + "/flashfile.xml");
            DeviceName = FlashLines[3].Replace("    <phone_model model=\"", "").Replace("\"/>","");
            if(FlashLines[7].Replace("    <sparsing enabled=\"", "").StartsWith("true"))
            {
                Sparsing = true;
            } else
            {
                Sparsing = false;
            }
            ScanFiles();
        }
        public void ScanFiles()
        {
            if (File.Exists(path + "/gpt.bin"))
            {
                RomFiles.Add("gpt.bin");
                RomPartitions.Add("partition");
            }
            if (File.Exists(path + "/bootloader.img"))
            {
                RomFiles.Add("bootloader.img");
                RomPartitions.Add("bootloader");
            }
            if (File.Exists(path + "/vbmeta.img"))
            {
                RomFiles.Add("vbmeta.img");
                RomPartitions.Add("vbmeta");
            }
            if (File.Exists(path + "/radio.img"))
            {
                RomFiles.Add("radio.img");
                RomPartitions.Add("radio");
            }
            if (File.Exists(path + "/BTFM.bin"))
            {
                RomFiles.Add("BTFM.bin");
                RomPartitions.Add("bluetooth");
            }
            if (File.Exists(path + "/dspso.bin"))
            {
                RomFiles.Add("dspso.bin");
                RomPartitions.Add("dsp");
            }
            if (File.Exists(path + "/logo.bin"))
            {
                RomFiles.Add("logo.bin");
                RomPartitions.Add("logo");
            }
            if (File.Exists(path + "/boot.img"))
            {
                RomFiles.Add("boot.img");
                RomPartitions.Add("boot");
            }
            if (File.Exists(path + "/dtbo.img"))
            {
                RomFiles.Add("dtbo.img");
                RomPartitions.Add("dtbo");
            }
            if (File.Exists(path + "/recovery.img"))
            {
                RomFiles.Add("recovery.img");
                RomPartitions.Add("recovery");
            }
            if (Sparsing)
            {
                for (int i = 0; i < 25; i++)
                {
                    if(File.Exists(path + "/super.img_sparsechunk." + i))
                    {
                        RomFiles.Add("super.img_sparsechunk." + i);
                        RomPartitions.Add("super");
                    }
                }
            }
            else
            {
                if (File.Exists(path + "/system.img"))
                {
                    RomFiles.Add("system.img");
                    RomPartitions.Add("system");
                }
            }
        }
    }
}
