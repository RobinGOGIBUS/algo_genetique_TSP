using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algo_genetique_TSP_métier;
using algo_genetique_TSP;

namespace algo_genetique_TSP_testUnitaire
{
    /// <summary>
    /// Description résumée pour Test_algo_genetique_TSP
    /// </summary>
    [TestClass]
    public class Test_algo_genetique_TSP
    {
        public Test_algo_genetique_TSP()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }


        [TestMethod]
        public void Test_selection()
        {
            // test de la sélection d'un individu suivant un rang
            TSP.FichierNoms = @"rs_tests/noms.csv";
            TSP.FichierVilles = @"rs_tests/villes.tsp";
            Console.WriteLine(TSP.FichierNoms);
            EvolutionaryProcess algo = new EvolutionaryProcess(null, "TSP");
            Assert.IsNotNull(algo.Selection());
            
        }
    }
}
