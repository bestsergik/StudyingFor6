using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingFor6.Models
{
    class Fifteen_Model
    {
        Random random = new Random();
        int[] fifteen;
        int[,] groupsFifteen = new int[4, 4];
        int numberRowSixteen;
        int numberColumnSixteen;
        int numberRowPressedButton;
        int numberColumnPressedButton;
        List<int> favorableNumbers = new List<int>();
        int numberPressedButton;
        int[,] originalFifteen = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        internal int[] GetNamesButtons()
        {
            int repeatNumber = 0;
            int randomNumber = 0;
            fifteen = new int[16];
            for (int i = 0; i < fifteen.Length; i++)
            {
                randomNumber = random.Next(1, 17);
                foreach (var number in fifteen)
                {
                    if (number == randomNumber)
                    {
                        repeatNumber = randomNumber;
                    }
                }
                if (repeatNumber == randomNumber) i--;
                else fifteen[i] = randomNumber;
            }
            MakeGroups(fifteen);
            return fifteen;
        }

        private void MakeGroups(int[] fifteen)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    groupsFifteen[i, j] = fifteen[counter];
                    counter++;
                }
            }
            GetPositionButton(16);
            DefineFavorableNumbers();
        }

        public bool CheckMoveButton(int numberButton)
        {
            numberPressedButton = numberButton;
            GetPositionButton(numberButton);
            DefineFavorableNumbers();
            return ComparePressedButtonAndFavorableNumbers();
        }

        private bool ComparePressedButtonAndFavorableNumbers()
        {
            bool isFavorableButton = false;
            for (int i = 0; i < favorableNumbers.Count; i++)
            {
                if (favorableNumbers[i] == numberPressedButton)
                {
                    isFavorableButton = true;
                    SwapPosition();
                    break;
                }
                else isFavorableButton = false;
            }
            return isFavorableButton;
        }

        public bool CompareFifteens()
        {
            bool _isEqual = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (groupsFifteen[i, j] != originalFifteen[i, j])
                    {
                        return _isEqual = false;
                    }
                    else _isEqual = true;
                }
            }
            return _isEqual;
        }

        void SwapPosition()
        {
            groupsFifteen[numberRowSixteen, numberColumnSixteen] = numberPressedButton;
            groupsFifteen[numberRowPressedButton, numberColumnPressedButton] = 16;
            numberRowSixteen = numberRowPressedButton;
            numberColumnSixteen = numberColumnPressedButton;
        }



        void DefineFavorableNumbers()
        {
            favorableNumbers.Clear();
            if (numberRowSixteen == 0)
            {
                if (numberColumnSixteen != 0 && numberColumnSixteen != 3)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);
                }
                else if (numberColumnSixteen == 0)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);
                }
                else
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);
                }
            }
            if (numberRowSixteen == 1 || numberRowSixteen == 2)
            {
                if (numberColumnSixteen != 0 && numberColumnSixteen != 3)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                }
                else if (numberColumnSixteen == 0)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);

                }
                else
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen + 1, numberColumnSixteen]);
                }
            }
            if (numberRowSixteen == 3)
            {
                if (numberColumnSixteen != 0 && numberColumnSixteen != 3)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                }
                else if (numberColumnSixteen == 0)
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen + 1]);
                }
                else
                {
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen, numberColumnSixteen - 1]);
                    favorableNumbers.Add(groupsFifteen[numberRowSixteen - 1, numberColumnSixteen]);
                }
            }
        }


        void GetPositionButton(int number)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (groupsFifteen[i, j] == number)
                    {
                        if (number == 16)
                        {
                            numberRowSixteen = i;
                            numberColumnSixteen = j;
                        }
                        else
                        {
                            numberRowPressedButton = i;
                            numberColumnPressedButton = j;
                        }
                    }
                }
            }
        }
    }
}
