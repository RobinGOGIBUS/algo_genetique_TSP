using System;
using System.Collections.Generic;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public class City
    {
        private string nom;
        private double x;
        private double y;

        public City(string nom, double x, double y)
        {
            this.nom = nom;
            this.x = x;
            this.y = y;
        }

        public string Nom
        {
            get {
                return nom;
            }
        }

        public double X
        {
            get {
                return x;
            }
        }

        public double Y
        {
            get {
                return y;
            }
        }

        public override string ToString()
        {
            return nom;

        }
    }
}
