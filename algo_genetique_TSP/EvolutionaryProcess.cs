using algo_genetique_TSP_métier;
using System.Collections.Generic;
using System.Linq;

namespace algo_genetique_TSP
{
    public class EvolutionaryProcess
    {
        private List<Individual> population;
        private int generationNb = 0;
        private IGUI program;
        private string problem;
        private double bestFitness;
        private Individual bestInd;
        private List<Individual> newGeneration;

        public EvolutionaryProcess(IGUI _program, string _problem)
        {
            program = _program;
            problem = _problem;
            IndividualFactory.getInstance().Init(problem);
            population = new List<Individual>();
            for (int i = 0; i < Parameters.IndividualsNb; i++)
            {
                population.Add(IndividualFactory.getInstance().getIndividual(problem));
            }
        }

        public void Run() {
            bestFitness = Parameters.MinFitness + 1;
            while (generationNb < Parameters.GenerationMaxNb && bestFitness > Parameters.MinFitness) {
                EvaluatePopulation();
                UpdateBestIndAndStats();
                newGeneration = new List<Individual>();
                newGeneration.Add(bestInd);
                for (int i = 0;i < Parameters.IndividualsNb - 1; i++)
                {
                    Reproduction();
                }

                Survival(newGeneration);
                generationNb++;
            }
        }

        private void Reproduction()
        {
            bool twoParents = (Parameters.RandomGenerator.NextDouble() < Parameters.CrossoverRate);
            if (twoParents)
            {
                Individual father = Selection();
                Individual mother = Selection();
                newGeneration.Add(IndividualFactory.getInstance().getIndividual(problem, father, mother));
            }
            else{
                Individual father = Selection();
                newGeneration.Add(IndividualFactory.getInstance().getIndividual(problem, father));
            }
        }

        private void UpdateBestIndAndStats()
        {
            bestInd = population.OrderBy(x => x.Fitness).FirstOrDefault();
            program.PrintBestIndividual(bestInd, generationNb);
            bestFitness = bestInd.Fitness;
        }

        private void EvaluatePopulation()
        {
            foreach (Individual ind in population)
            {
                ind.Evaluate();
            }
        }

        private void Survival(List<Individual> newGeneration)
        {
            population = newGeneration;
        }

        public Individual Selection()
        {
            int totalRanks = Parameters.IndividualsNb * (Parameters.IndividualsNb + 1) / 2;
            int rand = Parameters.RandomGenerator.Next(totalRanks);

            int indIndex = 0;
            int nbParts = Parameters.IndividualsNb;
            int totalParts = 0;

            while (totalParts < rand) {
                indIndex++;
                totalParts += nbParts;
                nbParts--;
            }

            return population.OrderBy(x => x.Fitness).ElementAt(indIndex);

        }
    }
}
