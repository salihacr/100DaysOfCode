using System;

namespace _100DaysOfCode
{
    class Calendar
    {
        static string[] monthNames = {"Jan", "Feb", "Mar", "Apr", "May", "Jun",
                  "Jul","Aug", "Sep", "Oct", "Nov", "Dec"};
        static void Main(string[] args)
        {
            CalendarCal calendar = new CalendarCal();
            int year = 2020;
            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine("\t\t\t{0} - {1} \n", monthNames[i-1], year);
                calendar.printCalendar(year, i);
                Console.WriteLine("\n---------------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
    class CalendarCal
    {
        private int[] month_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private int[] leap_year_month_days = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; //leap year

        // Year is leap or not.
        bool isLeapYear(int year)
        {
            return (year % 4) == 0 && (year % 100) != 0 || (year % 400) == 0;
        }

        public int numberOfLeapYear(int year)
        {
            int count = 0;
            for (int i = 1; i <= year; i++)
            {
                if (isLeapYear(i))
                {
                    count++;
                }
            }
            return count;
        }
        // This function calculate number of days in year (if year is leap "366" else "365")
        public int numberOfDaysInYear(int year, int month_days, int day)
        {
            int count = day;
            if (isLeapYear(year))
            {
                for (int i = 0; i < month_days - 1; i++)
                {
                    count += this.leap_year_month_days[i];
                }
            }
            else
            {
                for (int i = 0; i < month_days - 1; i++)
                {
                    count += this.month_days[i];
                }
            }
            return count;
        }
        // This function, find start day in week.
        public int startDay(int year, int month_days)
        {
            int count = 0;
            int leapYear = numberOfLeapYear(year - 1);
            int NumberOfDaysInYear = numberOfDaysInYear(year, month_days, 1);
            count = (leapYear) * 2 + (year - 1 - leapYear) + NumberOfDaysInYear;
            return count % 7;
        }
        // This function, find last day in week.
        public bool isLastDay(int year, int month_days, int day)
        {
            bool isLast = false;
            if (isLeapYear(year))
            {
                if (day == this.month_days[month_days - 1])
                {
                    isLast = true;
                }
                else
                {
                    if (day == this.leap_year_month_days[month_days - 1])
                    {
                        isLast = true;
                    }
                }
            }
            return isLast;
        }
        // If year is leap, brings the leap month_days of the year. 
        // Else, brings regular months of the year.
        public int getDates(int year, int month_days)
        {
            if (isLeapYear(year))
            {
                return this.leap_year_month_days[month_days - 1];
            }
            else
            {
                return this.month_days[month_days - 1];
            }
        }

        public void printCalendar(int year, int month_days)
        {
            int linecheck = 0;
            string temp = "";
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
            linecheck = startDay(year, month_days);
            //according to start day, match day of the week.
            for (int j = 0; j < linecheck; j++)
            {
                temp += "\t";
            }
            Console.Write(temp);
            int count = getDates(year, month_days);

            for (int i = 1; i <= count; i++)
            {
                Console.Write(i + "\t");
                linecheck++;
                if (linecheck == 7)
                {
                    if (this.isLastDay(year, month_days, i))
                    {
                        return; // if last day, doesn't need to more line.
                    }
                    Console.WriteLine();
                    linecheck = 0;
                }
            }
        }
    }
}