using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        
        public static bool IsNameOk(string firstName, string lastName)
        {
            return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
        }

        public static bool IsEmailOk(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }

        public static int GetRealAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month <= dateOfBirth.Month && now.Day < dateOfBirth.Day) age--;
            return age;
        }
    }
}