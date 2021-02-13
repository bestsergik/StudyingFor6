using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StudyingFor6.Models;

namespace StudyingFor6.ViewModels
{
    class StudyingNumbers_VM : INotifyPropertyChanged
    {
        Player player = new Player();
        StudyingNumbers_Model studyingNumbers_Model = new StudyingNumbers_Model();

        RelayCommand _playNumberCommand;
        RelayCommand _nextNumberCommand;
        ActionCommand<string> _defineRangeCommand;
        Visibility _isVisibleBtnRange;

        private int _randomNumber;
        string currentRange = "19";

        public ActionCommand<string> DefineRangeCommand
        {
            get
            {
                if (_defineRangeCommand == null)
                {
                    _defineRangeCommand = new ActionCommand<string>(

                        range => this.DefineRange(range));
                }
                return _defineRangeCommand;
            }
        }

        public RelayCommand NextNumberCommand
        {
            get
            {
                if (_nextNumberCommand == null)
                {
                    _nextNumberCommand = new RelayCommand(

                        p => this.NextNumber()); ;
                }
                return _nextNumberCommand;
            }
        }

        private void NextNumber()
        {
            RandomNumber = studyingNumbers_Model.GetRandomNumber(currentRange);
        }

        public RelayCommand PlayNumberCommand
        {
            get
            {
                if (_playNumberCommand == null)
                {
                    _playNumberCommand = new RelayCommand(

                        p => this.PlayNumber()); ;
                }
                return _playNumberCommand;
            }
        }

        private void PlayNumber()
        {
            player.PlayTune(RandomNumber.ToString(), "number");
        }

        private void DefineRange(string range)
        {
            currentRange = range;
            RandomNumber = studyingNumbers_Model.GetRandomNumber(currentRange);
        }

        public StudyingNumbers_VM()
        {
            RandomNumber = studyingNumbers_Model.GetRandomNumber(currentRange);
        }
        public int RandomNumber
        {
            get { return _randomNumber; }
            set
            {
                _randomNumber = value;
                OnPropertyChanged("RandomNumber");
            }
        }

        public Visibility IsVisibleBtnRange
        {
            get { return this._isVisibleBtnRange; }
            set
            {
                this._isVisibleBtnRange = value;
                OnPropertyChanged("IsVisibleBtnRange");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
