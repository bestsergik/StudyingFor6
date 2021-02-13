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
using StudyingFor6.Pages.Menu;

namespace StudyingFor6.Pages.Other
{
    /// <summary>
    /// Логика взаимодействия для LogoPage.xaml
    /// </summary>
    public partial class LogoPage : Page
    {
        public LogoPage()
        {
            InitializeComponent();
        }

        private void btnEntry_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CommonMenu());
        }
    }
}
