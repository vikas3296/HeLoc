//using Heloc.BusinessExpert;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Heloc.Helpers
{
    public static class CommonHelper
    {
        public static string IncludeCenturyDate(this DateTime sourceDate, bool replace)
        {
            var source = String.Format("{0}/{1}", sourceDate.Year / 100 + 1, sourceDate);
            if (replace)
                return Regex.Replace(source, "[^0-9]", "");
            else
                return source;
        }
        public static int? ConvertEBCDICtoInt(string inputString)
        {
            int? returnInt = null;

            if (string.IsNullOrEmpty(inputString))
                return (returnInt);

            StringBuilder strAmount = new StringBuilder(inputString);
            if (inputString.IndexOfAny(new char[] { '}', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R' }) >= 0)
                strAmount.Insert(0, "-");

            strAmount.Replace("{", "0");
            strAmount.Replace("}", "0");
            strAmount.Replace("A", "1");
            strAmount.Replace("J", "1");
            strAmount.Replace("B", "2");
            strAmount.Replace("K", "2");
            strAmount.Replace("C", "3");
            strAmount.Replace("L", "3");
            strAmount.Replace("D", "4");
            strAmount.Replace("M", "4");
            strAmount.Replace("E", "5");
            strAmount.Replace("N", "5");
            strAmount.Replace("F", "6");
            strAmount.Replace("O", "6");
            strAmount.Replace("G", "7");
            strAmount.Replace("P", "7");
            strAmount.Replace("H", "8");
            strAmount.Replace("Q", "8");
            strAmount.Replace("I", "9");
            strAmount.Replace("R", "9");

           
            int n;
            if (int.TryParse(strAmount.ToString(), out n))
                returnInt = n;
            return (returnInt);
        }
        public static DateTime GetDateTime(string dateString)
        {
            string str1;
            string str2;
            string str3;
            switch (dateString.Length)
            {
                case 0:
                case 1:
                    return Convert.ToDateTime("0001/01/01");
                case 6:
                    int result1;
                    int.TryParse(dateString.Substring(0, 2), out result1);
                    str1 = result1 <= 50 ? string.Format("20{0}", (object)dateString.Substring(0, 2)) : string.Format("19{0}", (object)dateString.Substring(0, 2));
                    str2 = dateString.Substring(2, 2);
                    str3 = dateString.Substring(4, 2);
                    break;
                case 7:
                    int result2;
                    int.TryParse(dateString.Substring(0, 1), out result2);
                    str1 = result2 != 0 ? string.Format("19{0}", (object)dateString.Substring(1, 2)) : string.Format("20{0}", (object)dateString.Substring(1, 2));
                    str2 = dateString.Substring(3, 2);
                    str3 = dateString.Substring(5, 2);
                    break;
                case 8:
                    str1 = dateString.Substring(0, 4);
                    str2 = dateString.Substring(4, 2);
                    str3 = dateString.Substring(6, 2);
                    break;
                case 10:
                    str1 = dateString.Substring(0, 4);
                    str2 = dateString.Substring(5, 2);
                    str3 = dateString.Substring(8, 2);
                    break;
                default:

                    return Convert.ToDateTime("0001/01/01");
            }
            return Convert.ToDateTime(string.Format("{0}/{1}/{2}", (object)str2, (object)str3, (object)str1));
        }
        /// <summary>
        /// This method is used to convert string date time to formated date time.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFormatedDateTime(string dateTime)
        {
            try
            {
                var parsedDate = DateTime.ParseExact(dateTime, "yyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var formattedDate = parsedDate.ToString("MM-dd-yy", System.Globalization.CultureInfo.InvariantCulture);
                return Convert.ToDateTime(formattedDate);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// This method will be used to check if the PM account exists in Supplimental and Econcent file
        /// </summary>
        /// <param name="accountToMatch"></param>
        /// <returns></returns>
        //public static bool CheckAccountExistInSupplimentalFile(string accountToMatch)
        //{
        //    bool recordFound = false;
        //    try
        //    {

        //        if (WorkFlowExpert.detModels.Any(df => df.LoanNumber == accountToMatch) || WorkFlowExpert.transModels.Any(df => df.LoanNumber == accountToMatch))
        //        {
        //            recordFound = true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        recordFound = false;
        //    }
        //    return recordFound;
        //}
        public static string GetFormatedDateTimeWithAmPm(DateTime dateTime)
        {
            try
            {
                string dateTimeAmPm = dateTime.ToString("MM/dd/yyyy HH:mm:ss").Replace("PM", "").Replace("AM", "");
                return dateTimeAmPm;
            }
            catch (Exception ex)
            {
                return Convert.ToString(DateTime.MinValue);
            }
        }

        public static string GetDateInDDMMYYFormat(string date)
        {
            try
            {
                var parsedDate = DateTime.ParseExact(date, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var formattedDate = parsedDate.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return formattedDate;
            }
            catch (Exception ex)
            {
                return Convert.ToString(DateTime.MinValue);
            }
        }
        public static string GetConvertDateYYMMDDToDDMMYYFormat(string date)
        {
            try
            {
                var parsedDate = DateTime.ParseExact(date, "yyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                var formattedDate = parsedDate.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                return formattedDate;
            }
            catch (Exception ex)
            {
                return Convert.ToString(DateTime.MinValue);
            }
        }
        /// <summary>
        /// Convert EBSTIC to mecimal. Mainly use for EVAR field.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static decimal ConvertEBCDICtoDecimal(string inputString)
        {
            decimal returnDecimal;
            if (string.IsNullOrEmpty(inputString))
                return (Convert.ToDecimal("0.00"));

            StringBuilder strAmount = new StringBuilder(inputString);
            if (inputString.IndexOfAny(new char[] { '}', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R' }) >= 0)
                strAmount.Insert(0, "-");

            strAmount.Replace("{", "0");
            strAmount.Replace("}", "0");
            strAmount.Replace("A", "1");
            strAmount.Replace("J", "1");
            strAmount.Replace("B", "2");
            strAmount.Replace("K", "2");
            strAmount.Replace("C", "3");
            strAmount.Replace("L", "3");
            strAmount.Replace("D", "4");
            strAmount.Replace("M", "4");
            strAmount.Replace("E", "5");
            strAmount.Replace("N", "5");
            strAmount.Replace("F", "6");
            strAmount.Replace("O", "6");
            strAmount.Replace("G", "7");
            strAmount.Replace("P", "7");
            strAmount.Replace("H", "8");
            strAmount.Replace("Q", "8");
            strAmount.Replace("I", "9");
            strAmount.Replace("R", "9");

            // Convert the amount to a deciaml:
            decimal n;
            if (decimal.TryParse(strAmount.ToString(), out n))
                returnDecimal = n;
            return (Convert.ToDecimal("0.00"));
        }
    }
}
