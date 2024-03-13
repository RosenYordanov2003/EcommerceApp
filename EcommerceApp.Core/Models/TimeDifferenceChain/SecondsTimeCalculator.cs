namespace EcommerceApp.Core.Models.TimeDifference
{
    public class SecondsTimeCalculator : DateTimeCalculator
    {
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            string timeUnitResult = seconds > 1 ? "seconds ago" : "second ago";

            return $"{seconds} {timeUnitResult}";
        }
    }
}
