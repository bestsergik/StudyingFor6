using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyingFor6.Models
{
    class StudyingNumbers_Model
    {
        Random random = new Random();

        internal int GetRandomNumber(string currentRange)
        {
            int randomNumber = 1;
            switch (currentRange)
            {
                case "10":
                    randomNumber = random.Next(0, 11);
                    break;
                case "19":
                    randomNumber = random.Next(11, 20);
                    break;
                case "99":
                    randomNumber = random.Next(20, 100);
                    break;
                case "999":
                    randomNumber = random.Next(100, 1000);
                    break;
                case "9999":
                    randomNumber = random.Next(1000, 10000);
                    break;
                default:
                    randomNumber = random.Next(0, 101); ;
                    break;
            }
            return randomNumber;
        }
    }
}
