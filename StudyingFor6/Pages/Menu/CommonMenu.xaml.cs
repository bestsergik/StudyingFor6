using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace StudyingFor6.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для CommonMenu.xaml
    /// </summary>
    public partial class CommonMenu : Page
    {
        public CommonMenu()
        {
            InitializeComponent();
        }

        private void btnMathematics_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MathematicsMenu());
        }

        private void btnGames_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GamesMenu());

        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TasksMenu());

        }

        private void btnRus_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RussionMenu());

        }

        private void btnEng_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EnglishMenu());

        }
    }
}
