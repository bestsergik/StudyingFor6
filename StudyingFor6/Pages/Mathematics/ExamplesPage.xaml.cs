using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для Examples.xaml
    /// </summary>
    public partial class ExamplesPage : Page
    {
        private SoundPlayer player;
        public ExamplesPage()
        {
            InitializeComponent();
            player = new SoundPlayer();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingExamplePage());
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.Focus(TextBoxInputResultExamples);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxInputResultExamples.Focus();
        }
    }
}
