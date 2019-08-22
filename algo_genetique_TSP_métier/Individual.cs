using System;
using System.Collections.Generic;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public abstract class Individual
    {
        protected double fitness = -1;
        private List<IGene> genome;

        public double Fitness
        {
            get {
                return fitness;
            }
        }

        public abstract void Mutate();

        public abstract double Evaluate();

        public override string ToString()
        {
            String gen = fitness + " : ";
            gen += String.Join(" - ", genome);
            return gen;
        }


    }
}
