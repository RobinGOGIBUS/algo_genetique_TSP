using algo_genetique_TSP_métier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace algo_genetique_TSP
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGUI
    {
        public MainWindow()
        {
            InitializeComponent();
            initParamValues();
        }

        public void initParamValues()
        {
            crossRate.Text = "0.0";
            mutsRate.Text = "0.3";
            mutAddRate.Text = "0.0";
            mutDeleteRate.Text = "0.0";
            minfit.Text = "779";
            nbMaxGen.Text = "500";
        }

        private void Switch_lang_fr(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                if (Thread.CurrentThread.CurrentCulture.Name != "fr-FR")
                {
                    ((App)Application.Current).ChangeLangage(new Uri(@"ressources\fr-FR.xaml", UriKind.Relative));
                }
            }
        }

        private void Switch_lang_en(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
                {
                    ((App)Application.Current).ChangeLangage(new Uri(@"ressources\en-US.xaml", UriKind.Relative));
                }
            }
        }

        private void Run_algo_TSP(object sender, RoutedEventArgs e)
        {
            Run();
        }

        private void VerificationParams()
        {
            double x = 0;
            int y = 0;
            Parameters.CrossoverRate = double.TryParse(crossRate.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out x) && x < 1.0 && x >= 0.0 ? x : 0.0;
            Parameters.MutationsRate = double.TryParse(mutsRate.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out x) && x < 1.0 && x >= 0.0 ? x : 0.3;
            Parameters.MutationAddRate = double.TryParse(mutAddRate.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out x) && x < 1.0 && x >= 0.0 ? x : 0.0;
            Parameters.MutationDeleteRate = double.TryParse(mutDeleteRate.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out x) && x < 1.0 && x >= 0.0 ? x : 0.0;
            Parameters.MinFitness = int.TryParse(minfit.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out y) &&  y > 0 ? y : 779;
            Parameters.GenerationMaxNb = int.TryParse(nbMaxGen.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out y) && y > 0 && y < 100000 ? y : 500;

            crossRate.Text = Parameters.CrossoverRate.ToString();
            mutsRate.Text = Parameters.MutationsRate.ToString();
            mutAddRate.Text = Parameters.MutationAddRate.ToString();
            mutDeleteRate.Text = Parameters.MutationDeleteRate.ToString();
            minfit.Text = Parameters.MinFitness.ToString();
            nbMaxGen.Text = Parameters.GenerationMaxNb.ToString();

        }

        public async void Run()
        {
            VerificationParams();
            result.Items.Clear();
            result.Items.Add("Génération en cours...");
            run.IsEnabled = false;        
            try
            {
                WriteFile.getInstance().Init();
                await Task.Run(() => {
                    EvolutionaryProcess geneticAlgoTSP = new EvolutionaryProcess(this, "TSP");
                    geneticAlgoTSP.Run();

                });
                MessageBox.Show("Génération terminée !", "", MessageBoxButton.OK, MessageBoxImage.Information);
                result.Items.Add("Génération réussi !");
                run.IsEnabled = true;
                WriteFile.getInstance().Open();
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
                run.IsEnabled = true;
            }  
           

        }

        public void PrintBestIndividual(Individual individual, int generation)
        {
            WriteFile.getInstance().Write(individual, generation);
        }

        public void PrintError(string error)
        {
            MessageBox.Show(error, "", MessageBoxButton.OK, MessageBoxImage.Error);
            result.Items.Add("Une erreur est survenue.");
        }
    }
}
