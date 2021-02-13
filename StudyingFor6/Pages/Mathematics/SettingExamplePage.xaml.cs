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

namespace StudyingFor6.Pages.Mathematics
{
    /// <summary>
    /// Логика взаимодействия для SettingExamplePage.xaml
    /// </summary>
    public partial class SettingExamplePage : Page
    {
        public SettingExamplePage()
        {
            InitializeComponent();
        }

        private void btnApplyChangeFinalResult_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCancelChangeFinalResult_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
