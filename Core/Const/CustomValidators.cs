using System.ComponentModel.DataAnnotations;

namespace Core.Const
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            if (value.GetType() != typeof(bool))
            {
                return false;
            }

            return (bool)value == true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be checked.";
        }
    }

}
