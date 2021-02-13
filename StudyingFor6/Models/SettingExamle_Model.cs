using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudyingFor6.Models
{
    class SettingExamle_Model
    {
        Random random = new Random();
        bool[] CheckBoxResult;
        int countChecks = 0;
        int[] numbersAndActions = new int[7];
        string[] returnedNumbersAndActions = new string[7];
        public SettingExamle_Model()
        {
            CheckBoxResult = new bool[8];
            for (int i = 0; i < CheckBoxResult.Length; i++)
            {
                CheckBoxResult[i] = true;
            }
            numbersAndActions[0] = 0;
            numbersAndActions[1] = 0;
            numbersAndActions[2] = 0;
            numbersAndActions[3] = 0;
            numbersAndActions[4] = 0;
            numbersAndActions[5] = 0;
            numbersAndActions[6] = 0;
        }
        public int ChangeQuantiteAction(int action, int value)
        {
            switch (action)
            {
                case 0:
                    if (value == 1) return value;
                    else return --value;
                case 1:
                    if (value == 3) return value;
                    else return ++value;
            }
            return value;
        }

        public int ChangePossibleResult(int action, int result, bool isNegativeValues)
        {
            switch (action)
            {
                case 0:
                    result -= 3;
                    if (result < 0 && isNegativeValues == false) return 0;
                    else return result;
                case 1:
                    result += 3;
                    return result;
            }
            return result;
        }

        internal int ChangePossibleResult(bool isNegative, int result)
        {
            if (!isNegative && result < 0)
            {
                result = 30;
            }
            return result;
        }

        internal Visibility[] GetNumbersAndActionsVisible(int quantityActions)
        {
            Visibility[] result = new Visibility[4];
            for (int i = 0; i < 4; i++)
            {
                if (quantityActions == 1)
                    result[i] = Visibility.Hidden;
                else if (quantityActions == 2)
                {
                    if (i < 2)
                        result[i] = Visibility.Visible;
                    else result[i] = Visibility.Hidden;
                }
                else result[i] = Visibility.Visible;
            }
            return result;
        }

        internal int CheckUserInput(string userInput, int finalResult)
        {
            if (userInput == finalResult.ToString())
                return 1;
            else if (userInput.Length >= finalResult.ToString().Length)
                return 0;
            else return 999;
        }

        internal bool PreCheck(int quantityActions, bool[] checkBoxes)
        {
            int trueFlags = 0;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i] == true)
                    trueFlags++;
            }
            if (trueFlags < quantityActions) return false;
            else return true;
        }

        internal int GetRandomQuantityActions()
        {
            int randomQuantityActions = random.Next(1, 4);
            return randomQuantityActions;
        }

        internal bool[] SetRandomFlags(int quantityActions)
        {
            if (quantityActions == 3)
                Console.WriteLine();
            int counterTrueFlag = 0;
            int randomFlag;
            bool[] randomFlags = new bool[4];

            while (counterTrueFlag < quantityActions)
            {
                for (int i = 0; i < randomFlags.Length; i++)
                {
                    if (i < 2) randomFlag = random.Next(0, 4);
                    else randomFlag = random.Next(0, 5);
                    if (randomFlag < 2 && !randomFlags[i])
                        randomFlags[i] = false;
                    else
                    {
                        if (!randomFlags[i])
                        {
                            randomFlags[i] = true;
                            counterTrueFlag++;
                        }
                    }
                    if (counterTrueFlag >= quantityActions) break;
                }
            }
            if (quantityActions == 3)
                Console.WriteLine();
            return randomFlags;
        }


        internal bool[] SettingChecks(int quantityActions, bool[] checkBoxes)
        {
            if (CheckTrueFlags(checkBoxes) == true)
            {
                switch (quantityActions)
                {
                    case 1:
                        BlockAllOtherCheckBoxes(checkBoxes);
                        break;
                    case 2:
                        SetOrTakeOffCheck(checkBoxes, 2);
                        break;
                    case 3:
                        SetOrTakeOffCheck(checkBoxes, 3);
                        break;
                }
                return CheckBoxResult;
            }
            return GetEmptyCheckBoxResult();

        }


        public bool[] GetEmptyCheckBoxResult()
        {
            countChecks = 0;
            for (int i = 0; i < CheckBoxResult.Length; i++)
            {
                CheckBoxResult[i] = true;
            }
            return CheckBoxResult;
        }

        private bool CheckTrueFlags(bool[] checkBoxes)
        {
            int trueFlags = 0;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i] == true)
                    trueFlags++;

            }
            if (trueFlags == 0) return false;
            else return true;
        }

        private void SetOrTakeOffCheck(bool[] checkBoxes, int quantityActins)
        {

            countChecks++;
            if (countChecks == quantityActins)
            {
                int quantityTrueBool = 0;

                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    if (checkBoxes[i] == true)
                    {
                        CheckBoxResult[i] = true;
                        quantityTrueBool++;
                    }
                    else CheckBoxResult[i] = false;


                }
                if (quantityActins == 3 && quantityTrueBool < 3)
                    for (int j = 0; j < CheckBoxResult.Length; j++)
                    {
                        CheckBoxResult[j] = true;
                    }
            }
            else if (countChecks > quantityActins)
            {
                countChecks -= 2;
                for (int i = 0; i < checkBoxes.Length; i++)
                {
                    CheckBoxResult[i] = true;
                }
            }
        }

        private void BlockAllOtherCheckBoxes(bool[] checkBoxes)
        {
            int quantityTrueBool = 0;
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i] == true)
                {
                    CheckBoxResult[i] = true;
                    quantityTrueBool++;
                }
                else CheckBoxResult[i] = false;
            }
            if (quantityTrueBool == 0)
                for (int i = 0; i < CheckBoxResult.Length; i++)
                {
                    CheckBoxResult[i] = true;
                }
        }
    }
}
