using algo_genetique_TSP_métier;
using System;
using System.Collections.Generic;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void switch_lang_fr(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                if (Thread.CurrentThread.CurrentCulture.Name != "fr-FR")
                {
                    ((App)Application.Current).ChangeLangage(new Uri(@"ressources\fr-FR.xaml", UriKind.Relative));
                }
            }
        }

        private void switch_lang_en(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
                {
                    ((App)Application.Current).ChangeLangage(new Uri(@"ressources\en-US.xaml", UriKind.Relative));
                }
            }
        }
    }
}
