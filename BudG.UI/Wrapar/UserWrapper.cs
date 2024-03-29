using BudG.Domain;
using System;
using System.Collections.Generic;

namespace BudG.UI.Wrapar
{
    public class UserWrapper : ModelWrapper<User>
    {
        public UserWrapper(User model) : base(model)
        {
        }

        public int Id { get { return Model.UserId; } }
        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DateTime DateOfBirth
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string UserName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        
        public byte[] ProfilePicture
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not valid user";
                    }
                    break;
                case nameof(Password):
                    if (string.Equals(Password, "DesNotMatch", StringComparison.OrdinalIgnoreCase))
                    {
                        Password = "";
                        yield return "This Password Deson't Match";
                    }
                    break;
            }

        }
    }
}
