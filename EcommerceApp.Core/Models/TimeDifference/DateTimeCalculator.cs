namespace EcommerceApp.Core.Models.TimeDifference
{
    public abstract class DateTimeCalculator
    {
        protected DateTimeCalculator nextDateTimeCalculator;

        public void SetNextDateTimeCalculator(DateTimeCalculator dateTimeCalculator)
        {
            nextDateTimeCalculator = dateTimeCalculator;
        }
        public abstract string CalculateTimeDifeerence(DateTime date);
    }
}
