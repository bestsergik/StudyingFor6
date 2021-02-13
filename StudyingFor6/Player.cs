using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyingFor6
{
    class Player
    {
        private SoundPlayer player;

        string pathToNumbers = @"sound\numbers\";
        string pathToSongs = @"sound\sounds\";

        public void playNumber(string playNum)
        {
            DefineEveryNumber(playNum);
            player = new SoundPlayer(pathToNumbers + playNum + ".wav");
            player.PlaySync();
            player.Stop();
            player.Dispose();
        }

        public void PlayTune(string tune, string typeTune)
        {
            List<string> tunes = new List<string>();
            string pathToTune;
            if (typeTune == "number")
            {
                pathToTune = pathToNumbers;
                tunes = DefineEveryNumber(tune);
            }
            else
            {
                tunes.Add(tune);
                pathToTune = pathToSongs;
            }

            Thread myThread =
                  new Thread(delegate () { Play(tunes, pathToTune); });
            myThread.Start();
        }

        private void Play(List<string> tunes, string pathToTune)
        {
            foreach (var tune in tunes)
            {
                player = new SoundPlayer(pathToTune + tune + ".wav");
                player.PlaySync();
                player.Stop();
                player.Dispose();
            }
        }

        private List<string> DefineEveryNumber(string randomNumber)
        {
            string[] partsNumber = new string[4];
            for (int partNumber = 0; partNumber < partsNumber.Length; partNumber++)
            {
                if (randomNumber.Length > partNumber)

                {
                    partsNumber[partNumber] = randomNumber.Substring(partNumber, 1);
                }
            }
            return ComposeNumbers(partsNumber, randomNumber.Length);

        }

        private List<string> ComposeNumbers(string[] numbers, int lengthNumber)
        {
            List<string> composedNumbers = new List<string>();
            switch (lengthNumber)
            {
                case 1:
                    composedNumbers.Add(numbers[0]);
                    break;
                case 2:
                    if (numbers[0] != "1" && numbers[1] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}0");
                    }
                    else if (numbers[0] != "1")
                    {
                        if (numbers[0] == "!")
                        {
                            composedNumbers.Add($"{numbers[0]}=");
                        }
                        else
                        {
                            composedNumbers.Add($"{numbers[0]}0");
                            composedNumbers.Add($"{numbers[1]}");
                        }

                    }
                    else if (numbers[0] == "1")
                    {
                        composedNumbers.Add($"{numbers[0]}{numbers[1]}");
                    }

                    break;
                case 3:
                    if (numbers[1] == "0" && numbers[2] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}00");
                    }
                    else if (numbers[1] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}00");
                        composedNumbers.Add($"{numbers[2]}");
                    }
                    else if (numbers[1] == "1")
                    {
                        composedNumbers.Add($"{numbers[0]}00");
                        composedNumbers.Add($"{numbers[1]}{numbers[2]}");
                    }
                    else if (numbers[2] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}00");
                        composedNumbers.Add($"{numbers[1]}0");

                    }
                    else
                    {
                        composedNumbers.Add($"{numbers[0]}00");
                        composedNumbers.Add($"{numbers[1]}0");
                        composedNumbers.Add($"{numbers[2]}");
                    }
                    break;
                case 4:
                    if (numbers[1] == "0" && numbers[2] == "0" && numbers[3] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");

                    }
                    else if (numbers[1] == "0" && numbers[2] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[3]}");
                    }
                    else if (numbers[1] == "0" && numbers[2] == "1")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[2]}{numbers[3]}");
                    }
                    else if (numbers[1] == "0" && numbers[3] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[2]}0");

                    }
                    else if (numbers[1] == "0" && numbers[3] != "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[2]}0");
                        composedNumbers.Add($"{numbers[3]}");

                    }
                    else if (numbers[2] == "0" && numbers[3] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                    }
                    else if (numbers[2] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                        composedNumbers.Add($"{numbers[3]}");
                    }
                    else if (numbers[2] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                        composedNumbers.Add($"{numbers[3]}");
                    }
                    else if (numbers[2] == "1")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                        composedNumbers.Add($"{numbers[2]}{numbers[3]}");
                    }
                    else if (numbers[3] == "0")
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                        composedNumbers.Add($"{numbers[2]}0");
                    }
                    else
                    {
                        composedNumbers.Add($"{numbers[0]}000");
                        composedNumbers.Add($"{numbers[1]}00");
                        composedNumbers.Add($"{numbers[2]}0");
                        composedNumbers.Add($"{numbers[3]}");
                    }
                    break;
            }
            return composedNumbers;
        }
    }
}
