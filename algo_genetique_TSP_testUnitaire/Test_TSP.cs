using Microsoft.VisualStudio.TestTools.UnitTesting;
using algo_genetique_TSP_métier;

namespace algo_genetique_TSP_testUnitaire
{
    /// <summary>
    /// Description résumée pour Test_TSP
    /// </summary>
    [TestClass]
    public class Test_TSP
    {
        public Test_TSP()
        {
           
        }       

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestLectureFichierVilles()
        {
            // cas où le fichier 'noms.CSV' n'existe pas ou est invalide
            Assert.AreEqual(false, TSP.Lecture_fichierNoms());
            
        }
    }
}
