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
using StudyingFor6.Models;
using StudyingFor6.UserControls;

namespace StudyingFor6.Pages.Games
{
    /// <summary>
    /// Логика взаимодействия для FifteenPage.xaml
    /// </summary>
    public partial class FifteenPage : Page
    {
        bool isFirstStep = true;
        int counterSteps = 0;
        int bestResult = Int32.MaxValue;
        long bestTime = Int32.MaxValue;

        TimerControl timerControl = new TimerControl();
        Fifteen_Model fifteen_model = new Fifteen_Model();
        public FifteenPage()
        {
            InitializeComponent();
            FillRandomNumbers();
            Timer.NavigationService.Navigate(timerControl);
        }

        void FillRandomNumbers()
        {
            int counter = 0;
            int[] namesButtons = new int[16];
            namesButtons = fifteen_model.GetNamesButtons();
            List<Button> buttons = new List<Button>();
            foreach (var button in FieldFifteen.Children)
            {
                ((Button)button).Visibility = Visibility.Visible;
                ((Button)button).Content = namesButtons[counter];
                counter++;
                if (((Button)button).Content.ToString() == "16")
                    ((Button)button).Visibility = Visibility.Hidden;
            }
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstStep)
            {
                timerControl.RefreshTimer();
                isFirstStep = false;
            }

            int pressedButton = (int)((Button)e.OriginalSource).Content;
            if (fifteen_model.CheckMoveButton(pressedButton))
            {
                //   ((Button)e.OriginalSource).Content = pressedButton;
                ((Button)e.OriginalSource).Visibility = Visibility.Hidden;
                foreach (var button in FieldFifteen.Children)
                {
                    if (((Button)button).Content.ToString() == "16")
                    {
                        ((Button)button).Visibility = Visibility.Visible;
                        ((Button)button).Content = pressedButton;
                    }
                }
                ((Button)e.OriginalSource).Content = "16";
                counterSteps++;
                Steps.Content = counterSteps.ToString();
            }
            if (fifteen_model.CompareFifteens())
            {
                if (counterSteps < bestResult)
                {
                    bestResult = counterSteps;
                    Result.Content = counterSteps;
                }
                if (timerControl.GetCurrentCounterTime() < bestTime)
                {
                    qwd = 0;
                    bestTime = timerControl.GetCurrentCounterTime();
                    Time.Content = timerControl.GetCurrentTime().ToString("mm\\:ss");
                }
                   
                StopGame();
                MessageBox.Show("Ура! Победа");
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Steps.Content = 0;
            StopGame();
            timerControl.ResetTimer();
            FillRandomNumbers();
        }

        private void StopGame()
        {
            counterSteps = 0;
            timerControl.StopTimer();
            isFirstStep = true;
        }
    }
}
