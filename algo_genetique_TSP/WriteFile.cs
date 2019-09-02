using algo_genetique_TSP_métier;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace algo_genetique_TSP
{
    public  class WriteFile
    {
        private static string fichier = "results.txt";
        private StreamWriter sw = null;
        private static WriteFile instance = null;

        private WriteFile() { }

        public static WriteFile getInstance()
        {
            if (instance == null)
            {
                instance = new WriteFile();
            }
            return instance;
        }

        
        public void Init()
        {
            try {
                if (File.Exists(@"" + fichier))
                {
                    //File.Open(@"" + fichier, FileMode.Truncate);
                    sw = new StreamWriter(@"" + fichier, false, Encoding.UTF8);
                }
                else
                {
                    //File.Create(@"" + fichier);
                    sw = new StreamWriter(@"" + fichier, true, Encoding.UTF8);
                }
            }
            catch (Exception e) {
                throw (e);
            }
            
        }

        public void Write(Individual individual, int generation)
        {
            string line = generation + " -> " + individual;
            try
            {
                sw.WriteLine(line);
            }
            catch (Exception e)
            {
                throw(e);
            }
            
        }

        public void Open()
        {
            sw.Close();
            if (File.Exists(@"" + fichier))
            {
                Process.Start(@"" + fichier);
            }
            else {
                throw new Exception("Un problème a eu lieu avec le fichier, veuillez réssayer.");
            }
            
            
        }
    }
}