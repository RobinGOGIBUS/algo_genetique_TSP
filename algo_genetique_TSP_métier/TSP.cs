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
        private static List<string> listeNoms;
        private static string fichierVilles = @"ressources\villes.tsp";
        private static string fichierNoms = @"ressources\noms.csv";

        public static void Init()
        {
            cities = new List<City>();
            listeNoms = new List<string>();
            if (Lecture_fichierNom())
            {
                if (!Lecture_fichierNoms())
                {
                    throw new Exception("Un problème a lieu avec le fichier 'villes.tsp'.\n Vérifier que celui-ci existe et est bien présent dans le dossier ressoucres.\n");
                }
            }
            else
            {
                throw new Exception("Un problème a lieu avec le fichier 'noms.csv'.\n Vérifier que celui-ci existe et est bien présent dans le dossier ressoucres.\n");
            }


        }

        public static bool Lecture_fichierNoms()
        {
            bool res = false;
            if (File.Exists(fichierVilles))
            {
                StreamReader sr = File.OpenText(fichierVilles);
                string s;
                int numero;
                double x;
                double y;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] elements = Regex.Split(s, @" ");
                    elements[0] = elements[0] != null ? elements[0] : "";
                    if (int.TryParse(elements[0], out numero))
                    {
                        elements[1] = elements[1] != null ? elements[1] : "";
                        if (double.TryParse(elements[1], NumberStyles.Number, CultureInfo.InvariantCulture, out x))
                        {
                            elements[2] = elements[2] != null ? elements[2] : "";
                            if (double.TryParse(elements[2], NumberStyles.Number, CultureInfo.InvariantCulture, out y))
                            {
                                ajouteVille(numero, x, y);
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

        public static void ajouteVille(int numero, double x, double y)
        {
            if (listeNoms.ElementAtOrDefault(numero-1) != null)
            {
                cities.Add(new City(listeNoms[numero-1], x, y));
            }
            else {
                cities.Add(new City("???", x, y));
            }
        }

        public static bool Lecture_fichierNom()
        {
            bool res = false;
            //throw new NotImplementedException();
            if (File.Exists(fichierNoms)){
                StreamReader sr = File.OpenText(fichierNoms);
                string s;
                int numero;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] elements = System.Text.RegularExpressions.Regex.Split(s, @" ");
                    elements[0] = elements[0] != null ? elements[0] : "";
                    if (int.TryParse(elements[0], out numero))
                    {
                        elements[1] = elements[1] != null ? elements[1] : "";
                        if (elements[1] != "")
                        {
                            listeNoms.Insert(numero-1, elements[1]);
                        }
                        else
                        {
                            listeNoms.Insert(numero-1, "???");
                        }
                    }
           
                }
                if (listeNoms.Count != 0)
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

        public static string FichierVilles {
            get {
                return fichierVilles;
            }
            set {
                fichierVilles = value;
            }
        }

        public static string FichierNoms
        {
            get
            {
                return fichierNoms;
            }
            set
            {
                fichierNoms = value;
            }
        }


    }
}
