using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StudyingFor6.Models;

namespace StudyingFor6.ViewModels
{


    class Example_VM : INotifyPropertyChanged
    {
        #region Data
        Example_Model exampleBuilding = new Example_Model();
        SettingExamle_Model example = new SettingExamle_Model();
        Player player = new Player();

        bool[] CheckBoxes = new bool[4];
        bool[] RandonCheckBoxes = new bool[4];
        bool[] CheckBoxesEnable = new bool[4];
        string[] numbersAndActions = new string[8];
        Visibility[] NumbersAndActionsVisible = new Visibility[4];

        public ICommand ReduceQuantityActions { get; set; }
        public ICommand IncreaseQuantityActions { get; set; }
        public ICommand ReduceMaxPossibleResult { get; set; }
        public ICommand IncreaseMaxPossibleResult { get; set; }
        public ICommand ChangeSetting { get; set; }
        public ICommand NextExample { get; set; }

        private string _number1;
        private string _number2;
        private string _number3;
        private string _number4;

        private string _action1;
        private string _action2;
        private string _action3;

        private int _maxPossibleResult = 9;
        private int _minPossibleResult = 0;
        private int _quantityActions;
        private int _quantityCorrectAnswer = 0;
        private int _quantityInCorrectAnswer = 0;
        private int _quantitySkipExample = 0;
        private int _positionEqual;
        private int _positionResult;

        private string _userInput;


        private Visibility _isVisibleSecondAction;
        private Visibility _isVisibleThirdNumber;
        private Visibility _isVisibleThirdAction;
        private Visibility _isVisibleFourthNumber;


        private bool _isAddition;
        private bool _isSubtraction;
        private bool _isMultiplication;
        private bool _isDivision;

        private bool _isNegativeResult;
        private bool _isRandomFlags = true;
        private bool _isZero;

        private bool _isSkipExample = true;

        private bool _isEnableAddition = true;
        private bool _isEnableSubtraction = true;
        private bool _isEnableMultiplication = true;
        private bool _isEnableDivision = true;
        private bool _isEnableRandomFlags;

        #endregion

        #region Сlass instance
        public Example_VM()
        {
          ReduceQuantityActions = new RelayCommand(new Action<object>(ReduceAction));
          IncreaseQuantityActions = new RelayCommand(new Action<object>(IncreaseAction));
          ReduceMaxPossibleResult = new RelayCommand(new Action<object>(ReduceResult));
          IncreaseMaxPossibleResult = new RelayCommand(new Action<object>(IncreaseResult));
          ChangeSetting = new RelayCommand(new Action<object>(ApplySetting));
          NextExample = new RelayCommand(new Action<object>(FollowingExample));
          GetNextExample();
        }

        private void FollowingExample(object obj)
        {
            if (IsRandomFlags) GetRandomExample();
            else GetNextExample();
            QuantitySkipExample += 1;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Inserting numbers and actions in view model
        /// </summary>


        void GetExample()
        {
            //CheckFlags();
            numbersAndActions = exampleBuilding.GetExample(QuantityActions, CheckBoxes, MinPossibleResult, MaxPossibleResult, IsZero);
            CheckVisibleNumbersAndActions();
            FillExample();
        }

        private void CheckFlags()
        {



        }

        private void FillExample()
        {
            Number1 = numbersAndActions[0];
            Number2 = numbersAndActions[1];
            Number3 = numbersAndActions[2];
            Number4 = numbersAndActions[3];
            Action1 = numbersAndActions[4];
            Action2 = numbersAndActions[5];
            Action3 = numbersAndActions[6];
        }

        private void SettingNegativeResult()
        {
            if (IsNegativeResult)
            {
                MaxPossibleResult = 7;
                MinPossibleResult = -7;
            }
            else
            {
                MaxPossibleResult = 5;
                MinPossibleResult = 0;
            }
            // MaxPossibleResult = example.NegativeResult(IsNegativeResult, MaxPossibleResult);
        }


        private void CheckUserInput()
        {
            int result = example.CheckUserInput(UserInput, Convert.ToInt32(numbersAndActions[7]));
            if (result == 0)
            {
                UserInput = "";
                player.PlayTune("bad", "song");
                QuantityInCorrectAnswer += 1;
            }
            else if (result == 1)
            {
                UserInput = "";
                player.PlayTune("good", "song");
                GetNextExample();
                QuantityCorrectAnswer += 1;
            }
        }

        private void SetPositionPartExampe()
        {
            switch (QuantityActions)
            {
                case 1:
                    PositionEqual = 4;
                    PositionResult = 5;
                    break;
                case 2:
                    PositionEqual = 6;
                    PositionResult = 7;
                    break;
                case 3:
                    PositionEqual = 8;
                    PositionResult = 9;
                    break;
            }
        }


        void GetNextExample()
        {
            if (IsRandomFlags || (CheckBoxes[0] == false && CheckBoxes[1] == false && CheckBoxes[2] == false && CheckBoxes[3] == false)) GetRandomExample();
            else
            {
                GetExample();
            }
        }

        void GetRandomExample()
        {
            IsRandomFlags = true;
            GetExample();

        }

        /// <summary>
        /// Setting of visibility at numbers and actions
        /// </summary>
        private void CheckVisibleNumbersAndActions()
        {
            NumbersAndActionsVisible = example.GetNumbersAndActionsVisible(QuantityActions);
            SubstitutionVisiblilityNumbersAndActions();
        }

        /// <summary>
        /// Apply setting visibility for numbers and actions
        /// </summary>
        private void SubstitutionVisiblilityNumbersAndActions()
        {
            IsVisibleSecondAction = NumbersAndActionsVisible[0];
            IsVisibleThirdNumber = NumbersAndActionsVisible[1];
            IsVisibleThirdAction = NumbersAndActionsVisible[2];
            IsVisibleFourthNumber = NumbersAndActionsVisible[3];
        }

        /// <summary>
        /// Set status flags by default
        /// </summary>
        private void ClearCheckboxes()
        {
            IsAddition = false;
            IsSubtraction = false;
            IsDivision = false;
            IsMultiplication = false;

            IsEnableAddition = true;
            IsEnableSubtraction = true;
            IsEnableDivision = true;
            IsEnableMultiplication = true;
        }

        /// <summary>
        /// Setting chekcBoxes when state one of them changed 
        /// </summary>
        private void SettingCheckBoxes()
        {
            SubstitutionBoolInChecboxes();
            CheckBoxesEnable = example.SettingChecks(QuantityActions, CheckBoxes);
            SubstitutionEnableChecboxes();
        }

        private void GetRandomQuantityActionsAndFlags()
        {
            QuantityActions = example.GetRandomQuantityActions();
            RandonCheckBoxes = example.SetRandomFlags(QuantityActions);
            SubstitutionRandomFlagsChecboxes();
        }

        void SubstitutionBoolInChecboxes()
        {
            CheckBoxes[0] = IsAddition;
            CheckBoxes[1] = IsSubtraction;
            CheckBoxes[2] = IsDivision;
            CheckBoxes[3] = IsMultiplication;

        }

        /// <summary>
        /// Change flags
        /// </summary>
        private void SubstitutionRandomFlagsChecboxes()
        {
            if (RandonCheckBoxes[0] == true) IsAddition = RandonCheckBoxes[0];
            if (RandonCheckBoxes[0] == false && IsAddition == true) IsAddition = RandonCheckBoxes[0];
            if (RandonCheckBoxes[1] == true) IsSubtraction = RandonCheckBoxes[1];
            if (RandonCheckBoxes[1] == false && IsSubtraction == true) IsSubtraction = RandonCheckBoxes[1];
            if (RandonCheckBoxes[2] == true) IsDivision = RandonCheckBoxes[2];
            if (RandonCheckBoxes[2] == false && IsDivision == true) IsDivision = RandonCheckBoxes[2];
            if (RandonCheckBoxes[3] == true) IsMultiplication = RandonCheckBoxes[3];
            if (RandonCheckBoxes[3] == false && IsMultiplication == true) IsMultiplication = RandonCheckBoxes[3];
        }

        void SubstitutionEnableChecboxes()
        {
            IsEnableAddition = CheckBoxesEnable[0];
            IsEnableSubtraction = CheckBoxesEnable[1];
            IsEnableDivision = CheckBoxesEnable[2];
            IsEnableMultiplication = CheckBoxesEnable[3];
        }

        #endregion


        #region Actions Fields
        public string Action1
        {
            get { return _action1; }
            set
            {
                _action1 = value;
                OnPropertyChanged("Action1");
            }
        }
        public string Action2
        {
            get { return _action2; }
            set
            {
                _action2 = value;
                OnPropertyChanged("Action2");
            }
        }
        public string Action3
        {
            get { return _action3; }
            set
            {
                _action3 = value;
                OnPropertyChanged("Action3");
            }
        }
        #endregion


        #region Flags Fields

        public bool IsRandomFlags
        {
            get { return _isRandomFlags; }
            set
            {
                _isRandomFlags = value;
                OnPropertyChanged("IsRandomFlags");
                if (IsRandomFlags)
                {
                    GetRandomQuantityActionsAndFlags();
                }
                else ClearCheckboxes();
            }
        }

        public bool IsZero
        {
            get { return _isZero; }
            set
            {
                _isZero = value;
                OnPropertyChanged("IsZero");
                if (IsZero && MinPossibleResult == 0) MinPossibleResult = 1;
            }
        }


        public bool IsSkipExample
        {
            get { return _isSkipExample; }
            set
            {
                _isSkipExample = value;
                OnPropertyChanged("IsSkipExample");
            }
        }

        public int QuantitySkipExample
        {
            get { return _quantitySkipExample; }
            set
            {
                _quantitySkipExample = value;
                OnPropertyChanged("QuantitySkipExample");
            }
        }

        public int QuantityCorrectAnswer
        {
            get { return _quantityCorrectAnswer; }
            set
            {
                _quantityCorrectAnswer = value;
                OnPropertyChanged("QuantityCorrectAnswer");
            }
        }

        public int QuantityInCorrectAnswer
        {
            get { return _quantityInCorrectAnswer; }
            set
            {
                _quantityInCorrectAnswer = value;
                OnPropertyChanged("QuantityInCorrectAnswer");
            }
        }

        public bool IsNegativeResult
        {
            get { return _isNegativeResult; }
            set
            {
                _isNegativeResult = value;
                OnPropertyChanged("IsNegativeResult");
                IsZero = false;
                SettingNegativeResult();
            }
        }

        public bool IsMultiplication
        {
            get { return _isMultiplication; }
            set
            {
                _isMultiplication = value;
                OnPropertyChanged("IsMultiplication");
                SettingCheckBoxes();
            }
        }
        public bool IsAddition
        {
            get { return _isAddition; }
            set
            {
                _isAddition = value;
                OnPropertyChanged("IsAddition");
                SettingCheckBoxes();
            }
        }

        public bool IsSubtraction
        {
            get { return _isSubtraction; }
            set
            {
                _isSubtraction = value;
                OnPropertyChanged("IsSubtraction");
                SettingCheckBoxes();
            }
        }

        public bool IsDivision
        {
            get { return _isDivision; }
            set
            {
                _isDivision = value;
                OnPropertyChanged("IsDivision");
                SettingCheckBoxes();
            }
        }

        #endregion


        #region Flags EnableCheck Fields

        public bool IsEnableRandomFlags
        {
            get { return _isEnableRandomFlags; }
            set
            {
                _isEnableRandomFlags = value;
                OnPropertyChanged("IsEnableRandomFlags");
            }
        }

        public bool IsEnableMultiplication
        {
            get { return _isEnableMultiplication; }
            set
            {
                _isEnableMultiplication = value;
                OnPropertyChanged("IsEnableMultiplication");
            }
        }
        public bool IsEnableAddition
        {
            get { return _isEnableAddition; }
            set
            {

                _isEnableAddition = value;
                OnPropertyChanged("IsEnableAddition");
            }
        }


        public bool IsEnableSubtraction
        {
            get { return _isEnableSubtraction; }
            set
            {
                _isEnableSubtraction = value;
                OnPropertyChanged("IsEnableSubtraction");
            }
        }


        public bool IsEnableDivision
        {
            get { return _isEnableDivision; }
            set
            {

                _isEnableDivision = value;
                OnPropertyChanged("IsEnableDivision");
            }
        }

        #endregion


        #region Flags Visible Fields

        public Visibility IsVisibleSecondAction
        {
            get { return _isVisibleSecondAction; }
            set
            {
                _isVisibleSecondAction = value;
                OnPropertyChanged("IsVisibleSecondAction");
            }
        }


        public Visibility IsVisibleThirdNumber
        {
            get { return _isVisibleThirdNumber; }
            set
            {
                _isVisibleThirdNumber = value;
                OnPropertyChanged("IsVisibleThirdNumber");
            }
        }

        public Visibility IsVisibleThirdAction
        {
            get { return _isVisibleThirdAction; }
            set
            {
                _isVisibleThirdAction = value;
                OnPropertyChanged("IsVisibleThirdAction");
            }
        }


        public Visibility IsVisibleFourthNumber
        {
            get { return _isVisibleFourthNumber; }
            set
            {
                _isVisibleFourthNumber = value;
                OnPropertyChanged("IsVisibleFourthNumber");
            }
        }

        #endregion


        #region Data fields

        public string UserInput
        {
            get { return _userInput; }
            set
            {
                _userInput = value;
                OnPropertyChanged("UserInput");
                CheckUserInput();
            }
        }

        public int MaxPossibleResult
        {
            get { return _maxPossibleResult; }
            set
            {
                _maxPossibleResult = value;
                OnPropertyChanged("MaxPossibleResult");
            }
        }



        public int PositionEqual
        {
            get { return _positionEqual; }
            set
            {
                _positionEqual = value;
                OnPropertyChanged("PositionEqual");
            }
        }



        public int PositionResult
        {
            get { return _positionResult; }
            set
            {
                _positionResult = value;
                OnPropertyChanged("PositionResult");
            }
        }


        public int MinPossibleResult
        {
            get { return _minPossibleResult; }
            set
            {
                _minPossibleResult = value;
                OnPropertyChanged("MinPossibleResult");
            }
        }

        public int QuantityActions
        {
            get { return _quantityActions; }
            set
            {
                _quantityActions = value;
                OnPropertyChanged("QuantityActions");
                if (QuantityActions == 0) IsNegativeResult = false;
                SetPositionPartExampe();
            }
        }

        public string Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                OnPropertyChanged("Number1");
            }
        }

        public string Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                OnPropertyChanged("Number2");
            }
        }

        public string Number3
        {
            get { return _number3; }
            set
            {
                _number3 = value;
                OnPropertyChanged("Number3");
            }
        }

        public string Number4
        {
            get { return _number4; }
            set
            {
                _number4 = value;
                OnPropertyChanged("Number4");
            }
        }


        #endregion


        #region Commands

        private void ApplySetting(object obj)
        {
            GetNextExample();
        }

        private void IncreaseResult(object obj)
        {

            SettingResult(1);
        }

        private void SettingResult(int action)
        {
            MaxPossibleResult = example.ChangePossibleResult(action, MaxPossibleResult, IsNegativeResult);
            if (MaxPossibleResult == 0) MaxPossibleResult = 1;
            if (IsNegativeResult) MinPossibleResult = -MaxPossibleResult;
            if (IsNegativeResult && MaxPossibleResult == 1)
            {
                IsNegativeResult = false;
                MaxPossibleResult = 1;
            }
            if (MinPossibleResult >= 0 && MaxPossibleResult < 4) MaxPossibleResult = 5;
        }

        private void ReduceResult(object obj)
        {
            SettingResult(0);
        }

        private void IncreaseAction(object obj)
        {
            QuantityActions = example.ChangeQuantiteAction(1, _quantityActions);
            ClearCheckboxes();
            IsRandomFlags = false;
        }



        private void ReduceAction(object sender)
        {
            QuantityActions = example.ChangeQuantiteAction(0, _quantityActions);
            ClearCheckboxes();
            IsRandomFlags = false;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
