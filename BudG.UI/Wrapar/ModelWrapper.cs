using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BudG.UI.Wrapar
{
    public class ModelWrapper<T>:NotifayDataErrorBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public T Model { get; set; }
        private string HashSomeText(string TextwantEncrypt)
        {
            byte[] data = new byte[8];
            data = Encoding.ASCII.GetBytes(TextwantEncrypt);
            string result;

            System.Security.Cryptography.SHA512 shaM = new System.Security.Cryptography.SHA512Managed();
            result = Encoding.ASCII.GetString(shaM.ComputeHash(data));
            return result;
        }

        protected virtual TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }
        protected virtual void SetValue<TValue>(TValue value,
            [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value);
        }

        protected virtual void SetValueForPassword<TValue>(TValue value,
         [CallerMemberName] string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, HashSomeText(value.ToString()));
            OnPropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value);
        }

        private void ValidatePropertyInternal(string propertyName, object currentValue)
        {
            ClearError(propertyName);

            ValidateDataAnnoutation(propertyName, currentValue);

            ValidateCustomeErrors(propertyName);
        }

        private void ValidateDataAnnoutation(string propertyName, object currentValue)
        {
            var context = new ValidationContext(Model) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(currentValue, context, results);
            foreach (var result in results)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }

        private void ValidateCustomeErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }

    }
}
