using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOverlap
{
    /// <summary>
    /// Given a length of time buffer check if any two intervals overlap among a given set of intervals
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Overlapping times !");

            //Overlap input
            //{ { 1, 3 }, { 5, 7 }, { 2, 4 }, { 6, 8 } };

            //Non Overlap input
            //{{1, 3}, {7, 9}, {4, 6}, {10, 13}};

            Tuple<int, int>[] timeSeries = 
                                        //{   Tuple.Create(1, 3),
                                        //    Tuple.Create(5, 7),
                                        //    Tuple.Create(2, 4),
                                        //    Tuple.Create(6, 8)
                                        //};
                                        {
                                            Tuple.Create(1, 3),
                                            Tuple.Create(7, 9),
                                            Tuple.Create(4,6),
                                            Tuple.Create(10, 13)
                                        };

            //1,2,5,6 - start
            //3,4,7,8 - end

            bool isOverlapping = compareTimes(timeSeries);
            string strOverlapStatus = isOverlapping ? "Overlapping" : "Not overlapping";
            Console.WriteLine($"The timelines are : {strOverlapStatus}");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeSeries"></param>
        /// <returns></returns>
        private static bool compareTimes(Tuple<int, int>[] timeSeries)
        {
            //Loop through each item in the tuple pairs
            int overLappingTime = 0;
            bool isOverlapping = false;

            //
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();

            foreach (var item in timeSeries)
            {
                startTimes.Add(item.Item1);
                endTimes.Add(item.Item2);
            }

            startTimes.Sort();
            endTimes.Sort();

            //endtimes greater than start times of next then overlap
            for (int i = 1; i < startTimes.Count; i++)
            {
                if(endTimes[i - 1] > startTimes[i])
                {
                    //overlap
                    overLappingTime += endTimes[i - 1] - startTimes[i];
                    isOverlapping = true;
                }
            }

            return isOverlapping;
        }
    }
}
