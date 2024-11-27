using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class Question1
    {
        static void Main()
        {
            
            Console.Write("enter no. of matches : ");
            int match = int.Parse(Console.ReadLine());
            CricketTeam c = new CricketTeam();
            c.PointsCalculation(match);
            Console.ReadLine();

        }
        public  class CricketTeam
        {
            
            public void PointsCalculation(int no_of_matches)
            {
                List<int> scores = new List<int>();
                for (int i = 0; i < no_of_matches; i++)
                {
                    Console.Write($"Enter the score {i + 1} : ");
                    int score = int.Parse(Console.ReadLine());
                    scores.Add(score);
                }
                
                Console.WriteLine("Sum: {0} ", scores.Sum());
                Console.WriteLine("Average : {0}", scores.Average());
            }

        }
        
    }
}

