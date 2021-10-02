using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class CaloriesExpensesServices
    {
        public int BurnedCalories(int distance, int time, int weight, int hight, string exercise)
        {
            int calories = 0;
            double speed = (double)distance / ((double)time * 60);
            switch (exercise)
            {
                case "Бег":
                    calories = weight * distance / 1000;
                    break;
                case "Ходьба":
                    calories = time * (int)(0.035 * weight + Math.Pow(speed, 2) / ((double)hight / 100) * 0.029 * weight);
                    break;
                case "Скандинавская ходьба":
                    calories = (int)(time * 1.5 * (0.035 * weight + Math.Pow(speed, 2) / ((double)hight / 100) * 0.029 * weight));
                    break;
                case "Велосипед":
                    double kof = 0;
                    if (speed * 3.6 < 15)
                    {
                        kof = 3.3;
                    }
                    else if (speed * 3.6 > 15 && speed * 3.6 < 20)
                    {
                        kof = 2.7;
                    }
                    else if (speed * 3.6 > 20 && speed * 3.6 < 25)
                    {
                        kof = 2.5;
                    }
                    else if (speed * 3.6 > 25)
                    {
                        kof = 2.3;
                    }
                    calories = (int)((double)distance / 1000 * weight / kof);
                    break;
                case "Катание на роликах":
                    calories = (int)((double)weight * time * 0.2);
                    break;
            }
            return calories;
        }
    }
}
