using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

namespace MyHub.Notification.Domain.SeedWork
{
    public class BaseValidator
    {
        #region properties     
        public List<ValidationFailure> Errors { get; private set; }
        #endregion

        #region constructors
        public BaseValidator()
        {
            Errors = new List<ValidationFailure>();
        }

        #endregion

        private List<ValidationFailure> getValidation<T>(T obj)
        {
            List<ValidationFailure> list = new List<ValidationFailure> { };

            if (obj == null)
                return list;

            var properties = obj.GetType().GetProperties(BindingFlags.Public |
            BindingFlags.Instance).Where(o => o != null).ToList();

            properties.ForEach(p =>
            {
                if (p.PropertyType == typeof(ValidationFailure))
                {
                    list.AddRange(obj as List<ValidationFailure>);
                }
                else if (p.PropertyType.IsClass && p.PropertyType.Namespace != "System")
                    list.AddRange(getValidation(p.GetValue(obj, null)));
            });

            return list;
        }
        private void setValidation(ValidationResult failures)
        {
            Errors.AddRange(failures.Errors);
        }

        public void ValidateNow<T>(AbstractValidator<T> validator, T instance)
        {
            var falhaValidacao = validator.Validate(instance);
            setValidation(falhaValidacao);
        }

        public bool IsValid()
        {
            var errors = getValidation(this);
            if (errors.Count > 0)
            {
                Errors.Clear();
                Errors.AddRange(errors);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
