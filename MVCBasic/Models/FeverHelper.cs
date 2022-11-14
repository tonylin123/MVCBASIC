using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCBasic.Models
{
    public class FeverHelper
    {
        public static string Diagnose(string temp)
        {
            float temperature = float.Parse(temp);

            if (temperature > 37.6)
            {
                return "You have a fever!";
            }
            if (temperature < 34.5)
            {
                return "You have a hypothermia!";
            }
            else
            {
                return "You are good!";
            }
        }
    }
}
