using System;
using System.Collections.Generic;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public static class  Parameters
    {
        private static int individualsNb = 20;
        private static int generationMaxNb = 50;
        private static int initialGenesNb = 10;
        private static int minFitness = 0;
        private static double mutationsRate = 0.10;
        private static double mutationAddRate = 0.20;
        private static double mutationDeleteRate = 0.10;
        private static double crossoverRate = 0.60;
        private static Random randomGenerator = new Random();

        public static int IndividualsNb
        {
            get{
                return individualsNb;
            }

            set {
                individualsNb = value;
            }
        }

        public static int GenerationMaxNb
        {
            get
            {
                return generationMaxNb;
            }

            set
            {
                generationMaxNb = value;
            }
        }

        public static int InitialGenesNb 
        {
            get
            {
                return initialGenesNb;
            }

            set
            {
                initialGenesNb = value;
            }
        }

        public static int MinFitness
        {
            get
            {
                return minFitness;
            }

            set
            {
                minFitness = value;
            }
        }

        public static double MutationsRate
        {
            get
            {
                return mutationsRate;
            }

            set
            {
                mutationsRate = value;
            }
        }

        public static double MutationAddRate
        {
            get
            {
                return mutationAddRate;
            }

            set
            {
                mutationAddRate = value;
            }
        }

        public static double MutationDeleteRate
        {
            get
            {
                return mutationDeleteRate;
            }

            set
            {
                mutationDeleteRate = value;
            }
        }

        public static double CrossoverRate
        {
            get
            {
                return crossoverRate;
            }

            set
            {
                crossoverRate = value;
            }
        }

        public static Random RandomGenerator
        {
            get
            {
                return randomGenerator;
            }

            
        }
    }
}
