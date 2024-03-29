﻿using System;
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
using StudyingFor6.Pages.Tasks;

namespace StudyingFor6.Pages.Menu
{
    /// <summary>
    /// Логика взаимодействия для TasksMenu.xaml
    /// </summary>
    public partial class TasksMenu : Page
    {
        public TasksMenu()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void btnMathematicsTasks_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MathematicsTasksPage());
        }
    }
}
