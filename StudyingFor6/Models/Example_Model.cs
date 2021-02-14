using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingFor6.Models
{
    class Example_Model
    {
        Random random = new Random();

        string[] example;
        int?[] numbers;
        int?[] resultBlock;
        int?[] resultBlocks;
        bool[] originalOperations = new bool[4];
        string[] operations;
        int? storedOperation;

        int?[] randomPositions;
        bool tryAgain;
        int countDifferentOperations;

        bool isZero;
        bool[] incomingOperations = new bool[4];
        int quantityOperations;
        int minPossibleResult;
        int maxPossibleResult;
        int typeOperation = 3;

        internal string[] GetExample(int QuantityOperations, bool[] Operations, int MinPossibleResult, int MaxPossibleResult, bool IsZero)
        {
            FillOriginalOperations(Operations);
            SetDefault();
            FillIncomingData(QuantityOperations, MinPossibleResult, MaxPossibleResult, IsZero);
            SetPositionOperation();
            SelectionValues();
            ConstructBlocks();
            ConvertToString();
            return example;
        }

        void FillOriginalOperations(bool[] Operations)
        {
            for (int i = 0; i < originalOperations.Length; i++)
            {
                originalOperations[i] = Operations[i];
            }
        }

        private void SetDefault()
        {
            resultBlock = new int?[3];
            numbers = new int?[4];
            resultBlocks = new int?[2];
            operations = new string[3];
            countDifferentOperations = 0;
            storedOperation = null;
            example = new string[8];
            typeOperation = 3;
        }

        private void FillIncomingData(int QuantityOperations, int MinPossibleResult, int MaxPossibleResult, bool IsZero)
        {
            isZero = IsZero;
            quantityOperations = QuantityOperations;
            minPossibleResult = MinPossibleResult;
            maxPossibleResult = MaxPossibleResult;
            for (int i = 0; i < incomingOperations.Length; i++)
            {
                incomingOperations[i] = originalOperations[i];
                if (incomingOperations[i] == true)
                    countDifferentOperations++;
            }
        }

        private void FillIncomingData()
        {
            for (int i = 0; i < incomingOperations.Length; i++)
            {
                incomingOperations[i] = originalOperations[i];
                if (incomingOperations[i] == true)
                    countDifferentOperations++;
            }
        }

        private void SetPositionOperation()
        {
            randomPositions = new int?[3];
            if (quantityOperations == 3 && countDifferentOperations == 2)
            {
                storedOperation = random.Next(0, 2);
            }
            if (countDifferentOperations == 1 || (!originalOperations[2] && !originalOperations[3]))
            {
                for (int i = 0; i < randomPositions.Length; i++)
                {
                    randomPositions[i] = i;
                }
            }

            else
            {
                SetRandomPositionOperation();
            }

        }

        private void SetRandomPositionOperation()
        {
            randomPositions = new int?[3];
            int randomPosition;

            for (int i = 0; i < randomPositions.Length; i++)
            {
                if (randomPositions[i] == null)
                {
                    randomPosition = random.Next(0, 3);
                    if (randomPositions[0] != randomPosition && randomPositions[1] != randomPosition && randomPositions[2] != randomPosition) randomPositions[i] = randomPosition;
                    else i--;
                }
            }
            CheckPositions();
        }

        private void CheckPositions()
        {
            if (randomPositions[0] == 2 && randomPositions[1] == 1 && randomPositions[2] == 0)
                SetRandomPositionOperation();
            else if (incomingOperations[2] && incomingOperations[3] && countDifferentOperations != 3)
            {
                if (quantityOperations == 3) storedOperation = random.Next(2, 4);

                if (randomPositions[0] == 1 && randomPositions[1] == 0 && randomPositions[2] == 2)
                    SetRandomPositionOperation();
            }
            else if (incomingOperations[2] || incomingOperations[3])
            {
                if (quantityOperations == 3 && countDifferentOperations == 2)
                {
                    int firstTrueOperation;
                    int secondTrueOperation;
                    if (incomingOperations[0]) firstTrueOperation = 0; else firstTrueOperation = 1;
                    if (incomingOperations[2]) secondTrueOperation = 2; else secondTrueOperation = 3;
                    if (SetRandomOperation(firstTrueOperation, secondTrueOperation)) SetRandomPositionOperation();
                }

                if ((randomPositions[0] == 0 && randomPositions[1] == 2 && randomPositions[2] == 1) || (randomPositions[0] == 1 && randomPositions[1] == 2 && randomPositions[2] == 0))
                    SetRandomPositionOperation();

                if (quantityOperations == 2 && (randomPositions[0] == 2 || randomPositions[1] == 2))
                    SetRandomPositionOperation();
            }
            if (quantityOperations == 2 && (randomPositions[0] == 2 || randomPositions[1] == 2))
                SetRandomPositionOperation();
        }

        private bool SetRandomOperation(int firstOperation, int secondOperation)
        {

            int randomOperation = random.Next(0, 2);
            if (randomOperation == 0)
            {
                storedOperation = firstOperation;
                return false;
            }
            else
            {
                storedOperation = secondOperation;
                if (randomPositions[0] == 1 && randomPositions[1] == 0 && randomPositions[2] == 2) return true;
                else return false;
            }
        }

        private void ConstructBlocks()
        {
            int numberPosition = 0;


            int counterOperations = quantityOperations;
            while (counterOperations > 0)
            {
                typeOperation = SetTakeOffFlag(counterOperations);
                RandomNumbers(typeOperation, numberPosition);
                SetOperation((int)randomPositions[numberPosition], typeOperation);
                numberPosition++;
                counterOperations--;

                if (tryAgain == true) counterOperations = 0;
            }
            if (tryAgain == true) TryAgain();
            CheckResult();
        }

        private int SetTakeOffFlag(int counterOperations)
        {

            if (incomingOperations[typeOperation] == true)

            {
                if (countDifferentOperations > 1)
                {
                    incomingOperations[typeOperation] = false;
                }
            }
            else if (counterOperations == 2 && (storedOperation == 2 || storedOperation == 3))

            {
                typeOperation = (int)storedOperation;
                storedOperation = null;
            }

            else if (storedOperation != null && counterOperations == 1)
            {
                typeOperation = (int)storedOperation;
                storedOperation = null;
            }

            else
            {
                typeOperation--;
                SetTakeOffFlag(counterOperations);
            }
            return typeOperation;
        }

        private void SetOperation(int position, int operation)
        {
            switch (operation)
            {
                case 0:
                    operations[position] = "+";
                    break;
                case 1:
                    operations[position] = "-";
                    break;
                case 2:
                    operations[position] = "*";
                    break;
                case 3:
                    operations[position] = ":";
                    break;
            }
        }

        void RandomNumbers(int typeOperation, int numberPosition)
        {
            int number1 = 0;
            int number2 = 0;
            if (numbers[(int)randomPositions[numberPosition]] == null)
            {
                number1 = (int)(numbers[(int)randomPositions[numberPosition]] = GetRandomNumber());
            }
            if (numbers[(int)randomPositions[numberPosition] + 1] == null)
            {
                number2 = (int)(numbers[(int)randomPositions[numberPosition] + 1] = GetRandomNumber());
            }
            CalculateLogic(number1, number2, (int)randomPositions[numberPosition], typeOperation);
        }

        void CalculateLogic(int number1, int number2, int numberPosition, int operation)
        {
            switch (quantityOperations)
            {
                case 1:
                    example[7] = CalculateOperation(number1, number2, operation).ToString();
                    break;
                case 2:
                    if (resultBlock[0] == null && resultBlock[1] == null)
                    {
                        resultBlock[numberPosition] = CalculateOperation(number1, number2, operation);
                    }
                    else if (resultBlock[0] == null)
                    {
                        example[7] = CalculateOperation(number1, (int)resultBlock[1], operation).ToString();
                    }
                    else
                    {
                        example[7] = CalculateOperation((int)resultBlock[0], number2, operation).ToString();
                    }
                    break;
                case 3:

                    if (randomPositions[0] == 1 && randomPositions[1] == 0 && randomPositions[2] == 2)
                    {
                        Console.WriteLine(storedOperation);
                    }

                    if (resultBlock[0] == null && resultBlock[1] == null && resultBlock[2] == null)
                    {
                        resultBlock[numberPosition] = CalculateOperation(number1, number2, operation);
                    }
                    else if (resultBlock[0] == null && resultBlock[1] == null && numberPosition == 0)
                    {
                        if (resultBlocks[1] < 0 && operation == 1) resultBlocks[1] = Math.Abs((int)resultBlocks[1]);
                        {
                            if (resultBlocks[1] == null)
                            {
                                resultBlock[0] = CalculateOperation(number1, number2, operation);
                            }
                            else
                            {
                                example[7] = CalculateOperation(number1, (int)resultBlocks[1], operation).ToString();
                            }
                        }
                    }
                    else if (resultBlock[1] == null && resultBlock[2] == null && numberPosition == 1)
                        resultBlocks[0] = CalculateOperation((int)resultBlock[0], number2, operation);

                    else if (resultBlock[1] == null && resultBlock[2] == null && numberPosition == 2)
                    {
                        if (resultBlocks[0] == null)
                        {
                            resultBlock[2] = CalculateOperation(number1, number2, operation);
                        }
                        else
                        {
                            example[7] = CalculateOperation((int)resultBlocks[0], number2, operation).ToString();
                        }
                    }

                    else if (resultBlock[0] == null && resultBlock[2] == null && numberPosition == 0)
                    {
                        if (resultBlocks[0] == null && resultBlocks[1] == null)
                        {
                            resultBlocks[0] = CalculateOperation(number1, (int)resultBlock[1], operation);
                        }
                        else
                        {
                            example[7] = CalculateOperation(number1, (int)resultBlocks[1], operation).ToString();
                        }
                    }

                    else if (resultBlock[0] == null && resultBlock[2] == null && numberPosition == 2)
                    {
                        if (resultBlocks[0] == null && resultBlocks[1] == null)
                        {
                            resultBlocks[1] = CalculateOperation((int)resultBlock[1], number2, operation);
                        }
                        else
                        {
                            example[7] = CalculateOperation((int)resultBlocks[0], number2, operation).ToString();
                        }
                    }

                    else if (resultBlock[1] == null && numberPosition == 1)
                    {
                        example[7] = CalculateOperation((int)resultBlock[0], (int)resultBlock[2], operation).ToString();
                    }
                    break;

            }
            CheckNegativePreResult();
        }

        private void CheckNegativePreResult()
        {
            if (minPossibleResult >= 0 && quantityOperations > 1)
            {
                for (int i = 0; i < resultBlock.Length; i++)
                {
                    if (resultBlock[i] != null && resultBlock[i] < 0)
                        tryAgain = true;
                    if (i < 2 && resultBlocks[i] != null && resultBlocks[i] < 0)
                        tryAgain = true;
                }

            }
        }

        public int CalculateOperation(int number1, int number2, int operation)
        {
            switch (operation)
            {
                case 0: return number1 + number2;

                case 1: return number1 - number2;

                case 2: return number1 * number2;

                case 3:
                    if (number2 == 0 || number1 % number2 != 0)
                    {
                        tryAgain = true;
                        return 1;
                    }
                    else return number1 / number2;

                default: return number1 + number2;
            }
        }
        private void SelectionValues()
        {
            if (maxPossibleResult == 0) maxPossibleResult = 5;
            if (maxPossibleResult > 100)
                maxPossibleResult /= 4;
            else if (maxPossibleResult > 50 && maxPossibleResult < 101)
                maxPossibleResult /= 2;
        }

        private void CheckResult()
        {
            if (Convert.ToInt32(example[7]) < minPossibleResult || Convert.ToInt32(example[7]) > maxPossibleResult)
            {
                TryAgain();
            }
        }

        void TryAgain()
        {
            tryAgain = false;
            SetDefault();
            FillIncomingData();
            SetPositionOperation();
            ConstructBlocks();
        }

        private int GetRandomNumber()
        {
            int randomNumber;
            if (minPossibleResult < 0 && isZero) randomNumber = random.Next(1, maxPossibleResult);
            else if (minPossibleResult < 0) randomNumber = random.Next(0, maxPossibleResult);
            else randomNumber = random.Next(minPossibleResult, maxPossibleResult);
            if (isZero && randomNumber == 0) randomNumber += maxPossibleResult / 2;
            return randomNumber;
        }

        private void ConvertToString()
        {
            for (int i = 0; i < 7; i++)
            {
                if (i < 4)
                {
                    if (numbers[i] < 0) numbers[i] = Math.Abs((int)numbers[i]);
                    example[i] = numbers[i].ToString();
                }
                else example[i] = operations[i - 4];
            }
        }
    }
}
