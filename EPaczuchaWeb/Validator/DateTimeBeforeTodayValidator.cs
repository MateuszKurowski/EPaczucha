using System;
using System.ComponentModel.DataAnnotations;

namespace EPaczuchaWeb.Validator
{
    public static class DateTimeBeforeTodayValidator
    {
        public static ValidationResult ValidateEndTimeRange(DateTime endTime)
        {

            if (endTime < DateTime.Now || endTime > DateTime.Now.AddDays(1))
            {
                return new ValidationResult("Nie można przesłać .");
            }

            return ValidationResult.Success;
        }
    }
}