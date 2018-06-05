namespace Table_Of_Responsibilities
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
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
    }
}
