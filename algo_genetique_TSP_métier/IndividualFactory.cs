using System;
using System.Collections.Generic;
using System.Text;

namespace algo_genetique_TSP_métier
{
    public class IndividualFactory
    {
        private static IndividualFactory instance;

        private IndividualFactory() { }

        public static IndividualFactory getInstance()
        {
            if (instance == null)
            {
                instance = new IndividualFactory();
            }
            return instance;
        }

        public void Init(string type)
        {
            switch (type)
            {
                case "TSP":
                    TSP.Init();
                    break;
            }
        }

        public Individual getIndividual(string type)
        {
            Individual ind = null;
            switch (type)
            {
                case "TSP":
                    ind = new TSPIndividual();
                    break;
            }
            return ind;
        }

        public Individual getIndividual(string type, Individual father)
        {
            Individual ind = null;
            switch (type)
            {
                case "TSP":
                    ind = new TSPIndividual((TSPIndividual) father);
                    break;
            }
            return ind;
        }

        public Individual getIndividual(string type, Individual father, Individual mother)
        {
            Individual ind = null;
            switch (type)
            {
                case "TSP":
                    ind = new TSPIndividual((TSPIndividual) father, (TSPIndividual) mother);
                    break;
            }
            return ind;
        }
    }
}
