using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ParcelDeliverySystem
{
    class TextParse
    {
        static string actualFile;
        //Check whether text file is available
        public void getFile(string file)
        {
            string[] harddisks_CD = {"a:", "b:", "c:", "d:", "e:", "f:", "g:", 
                                     "h:", "i:", "j:", "k:", "l:", "m:", "n:",
                                     "o:", "p:", "q:", "r:", "s:", "t:", "u:",
                                     "v:", "w:", "x:", "y:", "z:"};

            string[] directory = {Directory.GetCurrentDirectory()};

            foreach (string LocationFound in harddisks_CD)
            {
                checkFile(LocationFound + "\\" + file);
            }

            foreach (string LocationFound in harddisks_CD)
            {
                checkFile(LocationFound + "\\" + "ParcelDeliverySystem" + "\\" + file);
            }

            foreach (System.Environment.SpecialFolder specialFolder in 
                System.Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                string LocationFound = System.Environment.GetFolderPath(specialFolder);
                checkFile(LocationFound + "\\" + file);
            }

            foreach (System.Environment.SpecialFolder specialFolder in
                System.Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                string LocationFound = System.Environment.GetFolderPath(specialFolder);
                checkFile(LocationFound + "\\" + "ParcelDeliverySystem" + "\\" + file);
            }

            foreach (string LocationFound in directory)
            {
                checkFile(LocationFound + "\\" + file);
            }
        }

        public void checkFile(string file)
        {
            try
            {
                FileStream filestream = new FileStream(file, FileMode.Open);
                actualFile = file;
                //Replace all spaces and tabs to '-' and store in cookies folder;
                StreamReader filereader = new StreamReader(filestream);
                FileStream newfilestream = new FileStream(System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
                    + "\\" + "tempTextFile.txt", FileMode.Create);
                StreamWriter filewriter = new StreamWriter(newfilestream);
                string modifyString;

                while((modifyString= filereader.ReadLine()) != null)
                {
                    modifyString = modifyString.Replace(" ", "*");
                    modifyString = modifyString.Replace("\t", "*");
                    filewriter.WriteLine(modifyString);
                }
                actualFile = (System.Environment.GetFolderPath(Environment.SpecialFolder.Cookies)
                    + "\\" + "tempTextFile.txt");
                filestream.Close();
                filereader.Close();
                filewriter.Close();
                //return true;
            }
            catch (IOException e)
            {
                //return false;
            }
        }

        public string getFoundFile()
        {
            return actualFile;
        }
        //get the list of Singapore Postal Code
        public int[] sinPostalCode()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] sinPC = new int[37];
            while (sr.ReadLine() != null)
            {               
                for (int i = 0; i < 36; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 6)
                    {
                        sinPC[i] = int.Parse(StringLine.Substring(12,6));
                    }
                }
                break;
            }
            s.Close();
            sr.Close();              
            return sinPC;          
        }
        //get the list of Malaysia Postal Code
        public int[] masPostalCode()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] masPC = new int[37];
            while (sr.ReadLine() != null)
            {               
                for (int i = 0; i < 83; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 51)
                    {
                        masPC[i-50] = int.Parse(StringLine.Substring(12,5));
                    }
                }
                break;
            }
            s.Close();
            sr.Close();              
            return masPC;          
        }
        //get the list of USA Postal Code
        public int[] usPostalCode()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] usPC = new int[37];
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 128; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 96)
                    {
                        usPC[i - 95] = int.Parse(StringLine.Substring(12, 5));
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return usPC;
        }

    }
}
