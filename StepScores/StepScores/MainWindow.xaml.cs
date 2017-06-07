using System.Windows;
using DAO;

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
    }
}
