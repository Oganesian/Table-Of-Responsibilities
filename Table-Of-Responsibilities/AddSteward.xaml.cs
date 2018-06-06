using System;
using System.Windows;

namespace Table_Of_Responsibilities
{
    /// <summary>
    /// Логика взаимодействия для AddSteward.xaml
    /// </summary>
    public partial class AddSteward
    {
        public AddSteward()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string surnameAndName = StewardName.Text;
            if (surnameAndName != "" && surnameAndName != null && surnameAndName.Contains(" "))
            {
                string[] split = surnameAndName.Split(' ');
                string surname = split[0];
                string name = split[1];
                bool canBeTheManager = manager.IsChecked ?? false;
                bool canUseTheControlPanel = panel.IsChecked ?? false;
                bool canServeWithAMicrophone = microphone.IsChecked ?? false;
                Steward steward = 
                    new Steward(surname, name, canBeTheManager, canUseTheControlPanel, canServeWithAMicrophone);
                steward.saveToFile();
                StewardName.Text = "";
                manager.IsChecked = false;
                panel.IsChecked = false;
                microphone.IsChecked = false;
            }
            else
            {
                MessageBox.Show("Неверный ввод фамилии и имени. Образец: Иванов Иван");
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Activate();
            MainWindow ow = (MainWindow)Owner;
            ow.UpdateStewards();
        }
    }
}
