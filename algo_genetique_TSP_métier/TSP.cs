using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace algo_genetique_TSP_métier
{
    public static class TSP
    {
        private static List<City> cities;
        private static List<string> listNames;
        private static string fichierCities = @"ressources\villes.tsp";
        private static string fileCitiesNames = @"ressources\noms.csv";

        public static void Init()
        {
            cities = new List<City>();
            listNames = new List<string>();
            if (Lecture_fileCitiesNames())
            {
                if (!Lecture_fileCities())
                {
                    throw new Exception("Un problème a lieu avec le fichier 'villes.tsp'.\n Vérifier que celui-ci existe et est bien présent dans le dossier ressoucres.\n");
                }
            }
            else
            {
                throw new Exception("Un problème a lieu avec le fichier 'noms.csv'.\n Vérifier que celui-ci existe et est bien présent dans le dossier ressoucres.\n");
            }


        }

        public static bool Lecture_fileCities()
        {
            bool res = false;
            if (File.Exists(fichierCities))
            {
                StreamReader sr = File.OpenText(fichierCities);
                string s;
                int number;
                double x;
                double y;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] elements = Regex.Split(s, @" ");
                    elements[0] = elements[0] != null ? elements[0] : "";
                    if (int.TryParse(elements[0], out number))
                    {
                        elements[1] = elements[1] != null ? elements[1] : "";
                        if (double.TryParse(elements[1], NumberStyles.Number, CultureInfo.InvariantCulture, out x))
                        {
                            elements[2] = elements[2] != null ? elements[2] : "";
                            if (double.TryParse(elements[2], NumberStyles.Number, CultureInfo.InvariantCulture, out y))
                            {
                                AddCity(number, x, y);
                            }
                        }
                    }

                }
                if (cities.Count != 0)
                {
                    res = true;
                }
            }

            return res;
            
            
        }

        public static void AddCity(int numero, double x, double y)
        {
            if (listNames.ElementAtOrDefault(numero-1) != null)
            {
                cities.Add(new City(listNames[numero-1], x, y));
            }
            else {
                cities.Add(new City("???", x, y));
            }
        }

        public static bool Lecture_fileCitiesNames()
        {
            bool res = false;
            //throw new NotImplementedException();
            if (File.Exists(fileCitiesNames)){
                StreamReader sr = File.OpenText(fileCitiesNames);
                string s;
                int number;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] elements = System.Text.RegularExpressions.Regex.Split(s, @" ");
                    elements[0] = elements[0] != null ? elements[0] : "";
                    if (int.TryParse(elements[0], out number))
                    {
                        elements[1] = elements[1] != null ? elements[1] : "";
                        if (elements[1] != "")
                        {
                            listNames.Insert(number - 1, elements[1]);
                        }
                        else
                        {
                            listNames.Insert(number - 1, "???");
                        }
                    }
           
                }
                if (listNames.Count != 0)
                {
                    res = true;
                }
            }

            return res;
            
        }

        public static double getDistance(City _city1, City _city2)
        {
            
            double distance = (Math.Pow((_city1.X - _city2.X), 2) + Math.Pow((_city1.Y - _city2.Y), 2));
            distance = Math.Sqrt(distance) * 100;
            return distance;

        }

        public static List<City> getCities()
        {
            List<City> listCities = new List<City>();
            listCities.AddRange(cities);
            return listCities;
            
        }

        public static string FichierCities {
            get {
                return fichierCities;
            }
            set {
                fichierCities = value;
            }
        }

        public static string FileCitiesNames
        {
            get
            {
                return fileCitiesNames;
            }
            set
            {
                fileCitiesNames = value;
            }
        }


    }
}
