namespace EcommerceApp.Core.Models.TimeDifference
{
    public class DayTimeCalculator : DateTimeCalculator
    {
        public const int SecondsInDay = 86400;
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if (seconds / SecondsInDay >= 1)
            {
                string timeResultUnit = seconds / SecondsInDay > 1 ? "days ago" : "day ago";
                return $"{seconds / SecondsInDay} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
