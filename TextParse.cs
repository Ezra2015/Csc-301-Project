using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

public enum Day
{
    Mon, Tue, Wed, Thu, Fri, Sat, Sun
}
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
        //get the number of estimated working days for delivery for DHL from origin Singapore to 3 destinations
        public int[] workingDaysSIN_DHL()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysSIN_DHL = new int[3];
            int j=0; // starting index of  DaysSIN_DHL in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 17; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 6 && StringLine.Length > 120)
                    {
                        DaysSIN_DHL[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysSIN_DHL;
        }
        //get the number of estimated days for delivery for Fedex from origin Singapore to 3 destinations
        public int[] workingDaysSIN_Fedex()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysSIN_Fedex = new int[3];
            int j = 0; // starting index of  DaysSIN_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 32; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 21 && StringLine.Length > 120)
                    {
                        DaysSIN_Fedex[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysSIN_Fedex;
        }
        //get the number of estimated days for delivery for SpeedPost from origin Singapore to 3 destinations
        public int[] workingDaysSIN_SpeedPost()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysSIN_SpeedPost = new int[3];
            int j = 0; // starting index of  DaysSIN_SpeedPost in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 47; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 36 && StringLine.Length > 120)
                    {
                        DaysSIN_SpeedPost[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysSIN_SpeedPost;
        }
        //get the number of estimated days for delivery for DHL from origin Malaysia to 3 destinations
        public int[] workingDaysMAS_DHL()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysMAS_DHL = new int[3];
            int j = 0; // starting index of  DaysMAS_DHL in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 62; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 51 && StringLine.Length > 120)
                    {
                        DaysMAS_DHL[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysMAS_DHL;
        }
        //get the number of estimated days for delivery for Fedex from origin Malaysia to 3 destinations
        public int[] workingDaysMAS_Fedex()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysMAS_Fedex = new int[3];
            int j = 0; // starting index of  DaysMAS_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 77; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 66 && StringLine.Length > 120)
                    {
                        DaysMAS_Fedex[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysMAS_Fedex;
        }
        //get the number of estimated days for delivery for SpeedPost from origin Malaysia to 3 destinations
        public int[] workingDaysMAS_SpeedPost()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysMAS_SpeedPost = new int[3];
            int j = 0; // starting index of  DaysMAS_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 92 ; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 81 && StringLine.Length > 120)
                    {
                        DaysMAS_SpeedPost[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysMAS_SpeedPost;
        }
        //get the number of estimated days for delivery for DHL from origin USA to 3 destinations
        public int[] workingDaysUSA_DHL()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysUSA_DHL = new int[3];
            int j = 0; // starting index of  DaysMAS_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 107; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 96 && StringLine.Length > 120)
                    {
                        DaysUSA_DHL[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysUSA_DHL;
        }
        //get the number of estimated days for delivery for Fedex from origin USA to 3 destinations
        public int[] workingDaysUSA_Fedex()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysUSA_Fedex = new int[3];
            int j = 0; // starting index of  DaysMAS_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 122; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 111 && StringLine.Length > 120)
                    {
                        DaysUSA_Fedex[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysUSA_Fedex;
        }
        //get the number of estimated days for delivery for SpeedPost from origin USA to 3 destinations
        public int[] workingDaysUSA_SpeedPost()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            int[] DaysUSA_SpeedPost = new int[3];
            int j = 0; // starting index of  DaysMAS_Fedex in order to remove spaces between two elements in i
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 139; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 126 && StringLine.Length > 120)
                    {
                        DaysUSA_SpeedPost[j] = int.Parse(StringLine.Substring(120, 1));
                        j++;
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return DaysUSA_SpeedPost;
        }
        //get the available days for delivery in each three origin countries (SIN or MAS or USA) 
        //to 3 different destinations (SIN & MAS & USA) in DHL
        public string[] availableDaysOrigin_3DestDHL()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            string[] Days3Countries = new string[3];
            int j = 0; // starting index of  Days3Countries
            string[] getDays3Countries = new string[15];
            int k = 0; // starting index of getDays3Countries
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 18; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 6 && StringLine.Length > 100)
                    {
                        if (StringLine.Length != 121)// check whether string got estimated working days
                        {
                            getDays3Countries[k] = StringLine.Substring(100);
                        }
                        else
                        {
                            getDays3Countries[k] = StringLine.Substring(100, 16);
                        }
                        k++;
                    }
                }
                break;
            }
            for(int i = 0; i < getDays3Countries.Length; i++ )
            {
                if (getDays3Countries[i] != null)
                {
                    if (getDays3Countries[i].StartsWith("All"))
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ');
                    }
                    else
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ') +
                            " " + getDays3Countries[i + 1].Replace('*', ' ');
                        i+=1;
                    }
                }
                j++;
            }
            s.Close();
            sr.Close();
            return Days3Countries;
        }
        //get the available days for delivery in each three origin countries (SIN or MAS or USA) 
        //to 3 different destinations (SIN & MAS & USA) in Fedex
        public string[] availableDaysOrigin_3DestFedex()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            string[] Days3Countries = new string[3];
            int j = 0; // starting index of  Days3Countries
            string[] getDays3Countries = new string[15];
            int k = 0; // starting index of getDays3Countries
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 33; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 21 && StringLine.Length > 100)
                    {
                        if (StringLine.Length != 121)// check whether string got estimated working days
                        {
                            getDays3Countries[k] = StringLine.Substring(100);
                        }
                        else
                        {
                            getDays3Countries[k] = StringLine.Substring(100, 16);
                        }
                        k++;
                    }
                }
                break;
            }
            for (int i = 0; i < getDays3Countries.Length; i++)
            {
                if (getDays3Countries[i] != null)
                {
                    if (getDays3Countries[i].StartsWith("All"))
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ');
                    }
                    else
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ') +
                            " " + getDays3Countries[i + 1].Replace('*', ' ');
                        i += 1;
                    }
                }
                j++;
            }
            s.Close();
            sr.Close();
            return Days3Countries;
        }
        //get the available days for delivery in each three origin countries (SIN or MAS or USA) 
        //to 3 different destinations (SIN & MAS & USA) in SpeedPost
        public string[] availableDaysOrigin_3DestSpeedPost()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            string[] Days3Countries = new string[3];
            int j = 0; // starting index of  Days3Countries
            string[] getDays3Countries = new string[15];
            int k = 0; // starting index of getDays3Countries
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 48; i++)
                {
                    string StringLine = sr.ReadLine();
                    if (i >= 36 && StringLine.Length > 100)
                    {
                        if (StringLine.Length != 121)// check whether string got estimated working days
                        {
                            getDays3Countries[k] = StringLine.Substring(100);
                        }
                        else
                        {
                            getDays3Countries[k] = StringLine.Substring(100, 16);
                        }
                        k++;
                    }
                }
                break;
            }
            for (int i = 0; i < getDays3Countries.Length; i++)
            {
                if (getDays3Countries[i] != null)
                {
                    if (getDays3Countries[i].StartsWith("All"))
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ');
                    }
                    else
                    {
                        Days3Countries[j] = getDays3Countries[i].Replace('*', ' ') +
                            " " + getDays3Countries[i + 1].Replace('*', ' ');
                        i += 1;
                    }
                }
                j++;
            }
            s.Close();
            sr.Close();
            return Days3Countries;
        }
        // get 3 Delivery Service from text file
        public string[] threeDeliveryService()
        {
            this.getFile("LocalOverseasSimpleText.txt");
            FileStream s = new FileStream(this.getFoundFile(), FileMode.Open);
            StreamReader sr = new StreamReader(s);

            string[] threeDS = new string[3];
            int j = 0; // starting index of  threeDS
            while (sr.ReadLine() != null)
            {
                for (int i = 0; i < 38; i++)
                {
                    string StringLine = sr.ReadLine();
                    StringLine = StringLine.Replace("*", " ");
                    if (i >= 6 && StringLine.Length >= 25 && StringLine.Substring(40, 1) != " ")
                    {
                        threeDS[j] = StringLine.Substring(40, 10).Replace(" ","");
                        if (j < threeDS.Length - 1 )
                        {
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                break;
            }
            s.Close();
            sr.Close();
            return threeDS;
        }
        //Split available days into individual day in array if got delimiter, ','
        public string[] daysEachDayConverter(string availableDaysOrigin)
        {
            string[] daysEachDay = new string[7]; // get maximum number of days in 1 week
            
            if (availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Mon)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Tue)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Wed)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Thu)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Fri)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Sat)) ||
                availableDaysOrigin.StartsWith(Enum.GetName(typeof(Day), Day.Sun)))
            {
                string replaceString = availableDaysOrigin.Replace(" ","");
                daysEachDay = replaceString.Split(',');
            }
            return daysEachDay;
        }
    }
}
