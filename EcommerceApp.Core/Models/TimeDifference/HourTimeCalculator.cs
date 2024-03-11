namespace EcommerceApp.Core.Models.TimeDifference
{
    public class HourTimeCalculator : DateTimeCalculator
    {
        public const int SecondsInHour = 3600;
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if (seconds / SecondsInHour > 1)
            {
                string timeResultUnit = seconds / SecondsInHour > 1 ? "hours ago" : "hour ago";
                return $"{seconds / SecondsInHour} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
