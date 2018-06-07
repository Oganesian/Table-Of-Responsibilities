using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;

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
                MessageBox.Show("Ошибка: {0}", ex.ToString());
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (begin.Text != "" && end.Text != "")
            {
                DateTime beginDate = begin.SelectedDate.Value;
                DateTime endDate = end.SelectedDate.Value;

                int offset_1;
                int offset_2;

                List<DateTime> dates = new List<DateTime>();

                while (beginDate.DayOfWeek != DayOfWeek.Monday && beginDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    beginDate = beginDate.AddDays(1);
                }
                if (beginDate.DayOfWeek == DayOfWeek.Monday)
                {
                    offset_1 = 5;
                    offset_2 = 2;
                }
                else
                {
                    offset_1 = 2;
                    offset_2 = 5;
                }

                dates.Add(beginDate);

                while (true)
                {
                    beginDate = beginDate.AddDays(offset_1);
                    if (beginDate > endDate) break;
                    dates.Add(beginDate);
                    beginDate = beginDate.AddDays(offset_2);
                    if (beginDate > endDate) break;
                    dates.Add(beginDate);
                }

                List<Steward> stewards = new List<Steward>();

                List<Steward> managerCandidates = new List<Steward>();
                List<Steward> panelCandidates = new List<Steward>();
                List<Steward> microphoneCandidates = new List<Steward>();

                List<List<Steward>> weeks = new List<List<Steward>>();

                int index = 0;
                try
                {
                    string[] dirs = Directory.GetFiles("Stewards/", "*.cstw");
                    foreach (string dir in dirs)
                    {
                        stewards.Add(new Steward(dir));
                        if (stewards[index].CanBeTheManager) managerCandidates.Add(stewards[index]);
                        if (stewards[index].CanUseTheControlPanel) panelCandidates.Add(stewards[index]);
                        if (stewards[index].CanServeWithAMicrophone) microphoneCandidates.Add(stewards[index]);
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.ToString());
                }
                int managersIndex = 0;
                int panelersIndex = 0;
                int microphonersIndex = 0;
                var rnd = new Random();
                managerCandidates = managerCandidates.OrderBy(item => rnd.Next()).ToList();
                panelCandidates = panelCandidates.OrderBy(item => rnd.Next()).ToList();
                microphoneCandidates = microphoneCandidates.OrderBy(item => rnd.Next()).ToList();
                for (int i = 0; i < 9; i++)
                {
                    List<Steward> week = new List<Steward>();
                    // Managers
                    for (int j = 0; j < 2; j++)
                    {
                        if (managersIndex >= managerCandidates.Count - 1) managersIndex = 0;
                        if (week.IndexOf(managerCandidates[managersIndex]) == -1)
                        {
                            week.Add(managerCandidates[managersIndex++]);
                        }
                        else
                        {
                            while (week.IndexOf(managerCandidates[managersIndex]) > -1)
                            {
                                managersIndex++;
                                if (managersIndex >= managerCandidates.Count - 1) managersIndex = 0;
                            }
                            week.Add(managerCandidates[managersIndex++]);
                        }
                    }
                    // Panelers
                    if (panelersIndex >= panelCandidates.Count - 1) panelersIndex = 0;
                    if (week.IndexOf(panelCandidates[panelersIndex]) == -1)
                    {
                        week.Add(panelCandidates[panelersIndex++]);
                    }
                    else
                    {
                        while (week.IndexOf(panelCandidates[panelersIndex]) > -1)
                        {
                            panelersIndex++;
                            if (managersIndex >= panelCandidates.Count - 1) panelersIndex = 0;
                        }
                        week.Add(panelCandidates[panelersIndex++]);
                    }

                    // Microphoners
                    for (int j = 0; j < 3; j++)
                    {
                        if (microphonersIndex >= microphoneCandidates.Count - 1) microphonersIndex = 0;
                        if (week.IndexOf(microphoneCandidates[microphonersIndex]) == -1)
                        {
                            week.Add(microphoneCandidates[microphonersIndex++]);
                        }
                        else
                        {
                            while (week.IndexOf(microphoneCandidates[microphonersIndex]) > -1)
                            {
                                microphonersIndex++;
                                if (microphonersIndex >= microphoneCandidates.Count - 1) microphonersIndex = 0;
                            }
                            week.Add(microphoneCandidates[microphonersIndex++]);
                        }
                    }

                    weeks.Add(week);
                }
                foreach (List<Steward> list in weeks)
                {
                    foreach (Steward s in list)
                    {
                        Console.Write(s.Surname + " " + s.Name + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                MessageBox.Show("Установите дату начала и конца срока");
            }
        }
    }
}
