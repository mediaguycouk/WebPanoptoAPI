using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace WebPanoptoAPI
{
    class Files
    {
        internal string textFileToString(string txtFileLocation)
        {
            String lines = "";
            
            try
            {
                using (StreamReader sr = new StreamReader(txtFileLocation))
                {
                    lines = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Debug.Print("Cannot read file. Exception {0}", e.ToString());
            }

            return lines;
        }
    }
}