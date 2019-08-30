using System;
using System.Collections.Generic;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public class TSPGene : IGene
    {
        private City city;

        public TSPGene(City _city)
        {
            city = _city;
        }

        public TSPGene(TSPGene g)
        {
            city = g.City;
        }

        public double getDistance(TSPGene g)
        {
            return TSP.getDistance(city, g.city);
        }

        public void Mutate()
        {
            throw new NotImplementedException();
        }

        public City City
        {
            get {
                return city;
            }
        }

        public override string ToString()
        {
            return city.ToString();
        }
    }
}
