using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebPanoptoAPI.superadmin
{
    public class FlashData
    {
        
        private List<string> filenameCollection = new List<string>();
        private List<string> titlesCollection = new List<string>();
        private List<string> desCollection = new List<string>();
        private List<bool> isPublicCollection = new List<bool>();

        public string filename = "";
        public string title = "";
        public string descritpion = "";
        public bool isPublic = false;

        public bool findFromURL(string url)
        {
            url = url.Replace("_m4v1000", "");
            url = url.Replace("_m4v350", "");
            url = url.Replace("_flv350", "");

            int index = filenameCollection.FindIndex(item => item == url);

            if (index > -1)
            {
                filename = filenameCollection[index];
                title = titlesCollection[index];
                descritpion = desCollection[index];
                isPublic = isPublicCollection[index];
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool InitaliseFromFile()
        {
            string line;

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\FlashPlayerDBVideos.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] splitStrings = line.Split('|');
                if (splitStrings.Count() == 5)
                {
                    filenameCollection.Add(splitStrings[0]);
                    titlesCollection.Add(splitStrings[1]);
                    desCollection.Add(splitStrings[2] + "\r\n© " + UnixTimeToDateTime(splitStrings[3]));
                    isPublicCollection.Add(splitStrings[4].Equals("0"));
                }

            }

            file.Close();

            return true;
        }

        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0,
                                                      DateTimeKind.Utc);

        public static string UnixTimeToDateTime(string text)
        {
            double seconds = double.Parse(text, CultureInfo.InvariantCulture);
            DateTime newDateTime = Epoch.AddSeconds(seconds);
            string yearToReturn = String.Format("{0:yyyy}", newDateTime);
            return yearToReturn;
        }
    }
}