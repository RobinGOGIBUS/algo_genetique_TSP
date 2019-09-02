using algo_genetique_TSP_métier;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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
            InitParamValues();
        }

        public void InitParamValues()
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

            crossRate.Text = Parameters.CrossoverRate.ToString(CultureInfo.InvariantCulture);
            mutsRate.Text = Parameters.MutationsRate.ToString(CultureInfo.InvariantCulture);
            mutAddRate.Text = Parameters.MutationAddRate.ToString(CultureInfo.InvariantCulture);
            mutDeleteRate.Text = Parameters.MutationDeleteRate.ToString(CultureInfo.InvariantCulture);
            minfit.Text = Parameters.MinFitness.ToString();
            nbMaxGen.Text = Parameters.GenerationMaxNb.ToString();

        }

        public async void Run()
        {
            VerificationParams();
            result.Items.Clear();
            result.Items.Add((string) Application.Current.Resources["gen_enCours"]);
            run.IsEnabled = false;
            try
            {
                WriteFile.getInstance().Init();
                await Task.Run(() => {
                    EvolutionaryProcess geneticAlgoTSP = new EvolutionaryProcess(this, "TSP");
                    geneticAlgoTSP.Run();

                });
                MessageBox.Show((string) Application.Current.Resources["gen_terminee"], "", MessageBoxButton.OK, MessageBoxImage.Information);
                result.Items.Add((string)Application.Current.Resources["gen_reussi"]);
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
            result.Items.Add((string)Application.Current.Resources["gen_echec"]);
        }
    }
}
