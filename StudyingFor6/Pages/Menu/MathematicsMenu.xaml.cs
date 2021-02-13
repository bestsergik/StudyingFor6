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
using StudyingFor6.Pages.Mathematics;

namespace StudyingFor6.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для MathematicsMenu.xaml
    /// </summary>
    public partial class MathematicsMenu : Page
    {
        public MathematicsMenu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnStudyingNumbers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StudyingNumbersPage());
        }
    }
}
