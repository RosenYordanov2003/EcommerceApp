namespace EcommerceApp.Core.Models.TimeDifference
{
    public class MonthTimeCalculator : DateTimeCalculator
    {
        public const decimal SecondsInMonth = 2629743.83m;
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if (seconds / SecondsInMonth > 1)
            {
                string timeResultUnit = seconds / SecondsInMonth > 1 ? "months ago" : "month ago";
                return $"{seconds / SecondsInMonth} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
