namespace EcommerceApp.Core.Models.TimeDifference
{
    public class WeekTimeCalculator : DateTimeCalculator
    {
        public const int SecondsInWeek = 604800;

        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if (seconds / SecondsInWeek >= 1)
            {
                string timeResultUnit = seconds / SecondsInWeek > 1 ? "weeks ago" : "week ago";
                return $"{seconds / SecondsInWeek} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
