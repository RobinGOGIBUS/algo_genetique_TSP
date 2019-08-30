using algo_genetique_TSP_métier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algo_genetique_TSP
{
    public interface IGUI
    {
        void PrintBestIndividual(Individual individual, int generation);
        void PrintError(string error);
    }
}
