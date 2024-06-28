using System.Windows;

namespace PROG6221Part3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnAdd.Content = "Add";
            btnDisplay.Content = "Display";
            btnScale.Content = "Scale";
            btnFilter.Content = "Filter";
            btnExit.Content = "Exit";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new AddRecipe());
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new DisplayRecipe());
        }

        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Scale());
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Filter());
        }
    }
}