using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Table_Of_Responsibilities
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        bool[,] properties;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddSteward window = new AddSteward();
            window.Owner = this;
            window.Show();
        }

        public void UpdateStewards()
        {
            try
            {
                string[] dirs = Directory.GetFiles("Stewards/", "*.cstw");
                if (dirs.Length > 0) SaveButton.IsEnabled = true;
                int index = 0;
                properties = new bool[dirs.Length, 3];
                List<ComboData> ListData = new List<ComboData>();
                foreach (string dir in dirs)
                {
                    string surnameAndName = dir.Replace("Stewards/", "").Replace(".cstw", "");
                    string[] split = surnameAndName.Split(' ');
                    string surname = split[0];
                    string name = split[1];
                    Steward temp = new Steward(dir);
                    properties[index, 0] = temp.CanBeTheManager;
                    properties[index, 1] = temp.CanUseTheControlPanel;
                    properties[index, 2] = temp.CanServeWithAMicrophone;
                    ListData.Add(new ComboData { Id = index, Value = surnameAndName });
                    index++;
                }
                StewardBox.ItemsSource = ListData;
                StewardBox.DisplayMemberPath = "Value";
                StewardBox.SelectedValuePath = "Id";
                StewardBox.SelectedIndex = 0;
                manager.IsChecked = properties[0, 0];
                panel.IsChecked = properties[0, 1];
                microphone.IsChecked = properties[0, 2];
            }
            catch (Exception ex)
            {
                MessageBox.Show("The process failed: {0}", ex.ToString());
            }
        }

        private void MetroWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateStewards();
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private void StewardBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(StewardBox.SelectedIndex >= 0)
            {
                manager.IsChecked = properties[StewardBox.SelectedIndex, 0];
                panel.IsChecked = properties[StewardBox.SelectedIndex, 1];
                microphone.IsChecked = properties[StewardBox.SelectedIndex, 2];
            }
            else
            {
                manager.IsChecked = panel.IsChecked = microphone.IsChecked = false;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StewardBox.SelectedIndex >= 0)
            {
                string surnameAndName = StewardBox.Text;
                string[] split = surnameAndName.Split(' ');
                string surname = split[0];
                string name = split[1];
                int index = StewardBox.SelectedIndex;
                bool m = manager.IsChecked ?? false;
                bool p = panel.IsChecked ?? false;
                bool mic = microphone.IsChecked ?? false;
                properties[index, 0] = m;
                properties[index, 1] = p;
                properties[index, 2] = mic;
                Steward temp = new Steward(surname, name, m, p, mic);
                temp.saveToFile();
            }
            else
            {
                manager.IsChecked = panel.IsChecked = microphone.IsChecked = false;
            }
        }
    }
}
