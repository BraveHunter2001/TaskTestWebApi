using System.ComponentModel.DataAnnotations;

namespace Validation;

public class ValidJoinDate : ValidationAttribute
{
    DateTime LowerLimitDate = DateTime.Parse("01.01.2000");
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime dateJoin = Convert.ToDateTime(value);
        
        if (dateJoin.Date > LowerLimitDate.Date && dateJoin.Date < DateTime.Now.Date)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult($"This Date don' join in interval 01.01.2000 - {DateTime.Now}"); 
        }


        
    }
}