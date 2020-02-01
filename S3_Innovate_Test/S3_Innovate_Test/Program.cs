using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Innovate_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable Decleration 
            DateTime startTime, endTime;
            int pulseCountPeakHour = 0, pulseCountOffPeakHour = 0;
            string stTime, edTime;
            bool isCorrectEndTime = false;

            //current datatime
            Console.WriteLine(DateTime.Now.AddSeconds(20));

            //enter start time
            Console.WriteLine("Enter start time: ");
            stTime = Console.ReadLine();
            //convert start time, string to datetime
            startTime = Convert.ToDateTime(stTime);
            //Console.WriteLine(startTime);

            //enter end time
            Console.WriteLine("Enter end time: ");
            edTime = Console.ReadLine();
            //convert end time, string to datetime
            endTime = Convert.ToDateTime(edTime);
            //Console.WriteLine(endTime);


            //if wrong end time given
            while (!isCorrectEndTime)
            {
                if (startTime > endTime)
                {
                    Console.WriteLine("Your end time is lower than start time, please insert end time correctly!");
                    //enter end time
                    Console.WriteLine("Enter end time: ");
                    edTime = Console.ReadLine();
                    //convert end time, string to datetime
                    endTime = Convert.ToDateTime(edTime);
                    Console.WriteLine(endTime);
                }
                else
                {
                    isCorrectEndTime = true;
                }
            }
            



            //calculate with 20 sec pulse. 
            var differenceInSecond = (endTime - startTime).TotalSeconds;
            Console.WriteLine("Total Seconds: {0}",differenceInSecond);

            int pulseCount = Convert.ToInt32(differenceInSecond) / 20;
            int extraSecond = Convert.ToInt32(differenceInSecond) % 20;
            if(extraSecond !=0)
            {
                pulseCount++;
            }

            int tempPulseCount = pulseCount;
            DateTime tempStartTime = new DateTime();
            tempStartTime = startTime;
            while (tempPulseCount > 0)
            {
                int add20sec = 20;
                tempStartTime = tempStartTime.AddSeconds(add20sec);
                //Console.WriteLine("temp start time + 20 sec: {0}", tempStartTime);
                if (tempStartTime.Hour>=9 && tempStartTime.Hour<23)
                {
                    if(tempStartTime.Hour == 22)
                    {
                        pulseCountPeakHour++;
                        tempPulseCount--;
                    }
                    else
                    {
                        pulseCountPeakHour++;
                        tempPulseCount--;
                    }
                    
                }
                else
                {
                    pulseCountOffPeakHour++;
                    tempPulseCount--;
                }
            }

            var billInTaka = 0.0;
            var billInPaisa = 0.0;

            var billPeakHour = pulseCountPeakHour * 30;
            var billOffPeakHour = pulseCountOffPeakHour * 20;
            billInPaisa = (billPeakHour + billOffPeakHour);
            Console.WriteLine("Total bill in paisa: {0}", billInPaisa);
            Console.WriteLine("Total bill in peakHourBill: {0}", billPeakHour);
            Console.WriteLine("Total bill in OffPeakHourBill: {0}", billOffPeakHour);

            billInTaka = billInPaisa / 100;
            Console.WriteLine("Total bill in paisa: {0}", billInTaka);



            //int calculateAmountInPaisa = pulseCount * 20;
            //Console.WriteLine("Total bill in paisa: {0}", calculateAmountInPaisa);
        }
    }
}
