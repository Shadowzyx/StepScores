using System.Windows;
using DAO;
using System.Collections.Generic;

namespace StepScores
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DBAccess.InitiateDB();
            InitializeComponent();
            this.ScoresList.ItemsSource = DBAccess.GetAllScores();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.ScoresList.ItemsSource = DBAccess.GetFilterScore(search.Text);
        }
    }
}
