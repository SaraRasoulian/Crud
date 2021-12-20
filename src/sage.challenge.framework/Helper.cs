using System;
namespace sage.challenge.framework
{
    public class Helper
    {
        /// <summary>
        /// Calculate Age By DateOfBirth
        /// </summary>
        /// <param name="DateOfBirth"></param>
        /// <returns></returns>
        public sbyte CalculateAgeByDateOfBirth(DateTime DateOfBirth)
        {
            try
            {
                DateTime CurrentDate = DateTime.Today;
                float DaysOfYear = 365.25f;

                TimeSpan difference = CurrentDate.Subtract(DateOfBirth);
                sbyte age = Convert.ToSByte(difference.TotalDays / DaysOfYear);
                return age;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// check minimum legal age for registration
        /// </summary>
        /// <param name="DateOfBirth"></param>
        /// <returns></returns>
        public bool IsAgeLegal(DateTime DateOfBirth)
        {
            sbyte legalAge = 18;
            sbyte age = CalculateAgeByDateOfBirth(DateOfBirth);
            if (age < legalAge)
                return false;
            return true;
        }
    }
}
