namespace EcommerceApp.Core.Models.Utilities
{
    using TimeDifference;
    public static class GetTimeDifference
    {
        public static string GetTimeFormat(DateTime date)
        {
            YearTimeCalculator yearTimeCalculator = new YearTimeCalculator();
            MonthTimeCalculator monthTimeCalculator = new MonthTimeCalculator();
            WeekTimeCalculator weekTimeCalculator = new WeekTimeCalculator();
            DayTimeCalculator dayTimeCalculator = new DayTimeCalculator();
            HourTimeCalculator hourTimeCalculator = new HourTimeCalculator();
            MinutesTimeCalculator minutesTimeCalculator = new MinutesTimeCalculator();

            yearTimeCalculator.SetNextDateTimeCalculator(monthTimeCalculator);
            monthTimeCalculator.SetNextDateTimeCalculator(weekTimeCalculator);
            weekTimeCalculator.SetNextDateTimeCalculator(dayTimeCalculator);
            dayTimeCalculator.SetNextDateTimeCalculator(hourTimeCalculator);
            hourTimeCalculator.SetNextDateTimeCalculator(minutesTimeCalculator);
            minutesTimeCalculator.SetNextDateTimeCalculator(new SecondsTimeCalculator());

            return yearTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
