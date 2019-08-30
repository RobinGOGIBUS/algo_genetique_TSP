using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public class TSPIndividual : Individual
    {
        public TSPIndividual()
        {
            genome = new List<IGene>();
            List<City> cities = TSP.getCities();
            while (cities.Count != 0)
            {
                int index = Parameters.RandomGenerator.Next(cities.Count);
                genome.Add(new TSPGene(cities.ElementAt(index)));
                cities.RemoveAt(index);
            }
        }

        public TSPIndividual(TSPIndividual father)
        {
            this.genome = new List<IGene>();
            foreach (TSPGene g in father.genome)
            {
                this.genome.Add(new TSPGene(g));
            }
            Mutate();
        }

        public TSPIndividual(TSPIndividual father, TSPIndividual mother)
        {
            this.genome = new List<IGene>();
            int cuttingPoint = Parameters.RandomGenerator.Next(father.genome.Count);
            foreach (TSPGene g in father.genome.Take(cuttingPoint))
            {
                this.genome.Add(new TSPGene(g));
            }
            foreach (TSPGene g in mother.genome)
            {
                if (!genome.Contains(g))
                {
                    this.genome.Add(new TSPGene(g));
                }

            }
            Mutate();
        }

        public override double Evaluate()
        {
            double totalKm = 0;
            TSPGene oldGene = null;
            foreach (TSPGene g in genome)
            {
                if (oldGene != null)
                {
                    totalKm += g.getDistance(oldGene);
                }
                oldGene = g;
            }
            totalKm += oldGene.getDistance((TSPGene)genome.FirstOrDefault());
            fitness = totalKm;
            return fitness;
        }

        public override void Mutate()
        {
            if (Parameters.RandomGenerator.NextDouble() < Parameters.MutationsRate)
            {
                int index1 = Parameters.RandomGenerator.Next(genome.Count);
                TSPGene g = (TSPGene)genome.ElementAt(index1);
                genome.RemoveAt(index1);
                int index2 = Parameters.RandomGenerator.Next(genome.Count);
                genome.Insert(index2,g);
            }

        }
    }
}
