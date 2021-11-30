using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SkillMatrix.Service
{
    public static class Helper
    {
        public static List<KeyValuePair<string, string>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            List<KeyValuePair<string, string>> enumValList = new List<KeyValuePair<string, string>>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new KeyValuePair<string, string>(e.ToString(), (attributes.Length > 0) ? attributes[0].Description : e.ToString()));
            }

            return enumValList;
        }

        public static DateTime GetDateFromMonthString(string monthStr, int year)
        {
            string month = string.Empty;
            var now = DateTime.Now;
            if("january".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 1, 1);
            }
            else if ("february".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 2, 1);
            }
            else if ("march".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 3, 1);
            }
            else if ("april".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 4, 1);
            }
            else if ("may".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 5, 1);
            }
            else if ("june".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 6, 1);
            }
            else if ("july".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 7, 1);

            }
            else if ("august".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 8, 1);
            }
            else if ("september".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 9, 1);
            }
            else if ("october".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 10, 1);
            }
            else if ("november".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 11, 1);
            }
            else if ("december".Contains(monthStr.ToLower().Trim()))
            {
                return new DateTime(year, 12, 1);
            }
            return new DateTime(DateTime.Now.Year, (DateTime.Now.Month-1), 1);
        }
    }
}
