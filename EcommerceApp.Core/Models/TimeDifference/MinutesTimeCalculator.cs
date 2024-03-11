namespace EcommerceApp.Core.Models.TimeDifference
{
    public class MinutesTimeCalculator : DateTimeCalculator
    {
        public const int SecondsInMinute = 60;
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if (seconds / SecondsInMinute > 1)
            {
                string timeResultUnit = seconds / SecondsInMinute > 1 ? "minutes ago" : "minute ago";
                return $"{seconds / SecondsInMinute} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
