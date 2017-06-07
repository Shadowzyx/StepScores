using System.Windows;
using DAO;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Controls;
using System.ComponentModel;

namespace StepScores
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Scores> currentList;

        public MainWindow()
        {
            DBAccess.InitiateDB();
            InitializeComponent();
            this.ScoresList.ItemsSource = DBAccess.GetAllScores();
            this.Type.ItemsSource = new List<string>() { "Jack", "Stamina", "JumpStream", "Stream", "Hammer", "Speed", "Stamina/Jack", "Stamina/JumpStream", "Speed/Stream" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (this.Type.SelectedValue == null)
                this.ScoresList.ItemsSource = DBAccess.GetFilterScore(search.Text);
            else
                this.ScoresList.ItemsSource = DBAccess.GetFilterTypeScore(search.Text, Type.SelectedValue.ToString());
        }

        private void AAChanged(object sender, RoutedEventArgs e)
        {
            if ((bool)this.AA.IsChecked)
            {
                var list = ScoresList.ItemsSource as List<Scores>;
                currentList = list;
                ScoresList.ItemsSource = list.Where(x => x.ScoreDP > 93);
            }
            else
                ScoresList.ItemsSource = currentList;
        }

        private void Type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.search.Text))
                ScoresList.ItemsSource = DBAccess.GetTypeScore(Type.SelectedValue.ToString());
            else
                ScoresList.ItemsSource = DBAccess.GetFilterTypeScore(search.Text, Type.SelectedValue.ToString());
        }

        private void ScoresList_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (ScoresList.SelectedItem == null)
                return;
            if(e.Key == System.Windows.Input.Key.Delete)
            {
                Scores tmp = (Scores)ScoresList.SelectedItem;
                DBAccess.RemoveFromDB(tmp);
                IEditableCollectionView items = ScoresList.Items; //Cast to interface
                if (items.CanRemove)
                {
                    items.Remove(ScoresList.SelectedItem);
                }
            }
        }
    }
}
