namespace EcommerceApp.Core.Models.TimeDifference
{
    public class YearTimeCalculator : DateTimeCalculator
    {
        private const int SecondsInYear = 31556926;
        public override string CalculateTimeDifeerence(DateTime date)
        {
            DateTime todayDate = DateTime.UtcNow;
            TimeSpan result = todayDate - date;
            int seconds = (int)Math.Floor(result.TotalSeconds);

            if(seconds / SecondsInYear >= 1)
            {
                string timeResultUnit = seconds / SecondsInYear > 1 ? "years ago" : "year ago";
                return $"{seconds / SecondsInYear} {timeResultUnit}";
            }
            return nextDateTimeCalculator.CalculateTimeDifeerence(date);
        }
    }
}
