using System.ComponentModel.DataAnnotations;

namespace Education.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;

        public DateInFutureAttribute() : this(() => DateTime.Now) { }

        public DateInFutureAttribute(Func<DateTime> dateTimeNowProvider)
        {
            _datetimeNowProvider = dateTimeNowProvider;
            ErrorMessage = "Date must be from future";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _datetimeNowProvider();
            }
            return isValid; 
        }
    }
}
