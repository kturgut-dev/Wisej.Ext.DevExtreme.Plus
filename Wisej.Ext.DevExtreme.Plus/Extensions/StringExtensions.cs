using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisej.Ext.DevExtreme.Plus.Extensions
{
    public static class StringExtensions
    {
        public static string AddSpacesToSentence(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        public static string GetValue(this DataRow row, string fieldName, string defaultValue = "")
        {
            if (row.Table.Columns.Contains(fieldName))
                return row[fieldName] != null && row[fieldName] != DBNull.Value ? row[fieldName].ToString()
                .IsNullOrEmpty(defaultValue) : defaultValue;
            else
                return defaultValue;
        }

        public static DateTime? GetValueToDateTime(this DataRow row, string fieldName, DateTime? defaultValue = null)
        {
            try
            {
                string value = row.GetValue(fieldName);
                if (value.IsNullOrEmpty())
                    return defaultValue;
                else
                {
                    double doubleCellValue = 0;
                    DateTime convertedDate = DateTime.Today;

                    if (DateTime.TryParse(value, out convertedDate))
                        convertedDate = Convert.ToDateTime(value);
                    else if (double.TryParse(value, out doubleCellValue))
                        convertedDate = DateTime.FromOADate(doubleCellValue);

                    return convertedDate;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string ReplaceAll(this string text, string newValue, params string[] oldVals)
        {
            foreach (string val in oldVals)
            {
                text.Replace(val, newValue);
            }

            return text;
        }

        public static string ToLowerFirstChar(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToLower(input[0]) + input.Substring(1);
        }

        public static TModel ToCast<TModel>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TModel>(json);
        }

        public static TModel PopulateObject<TModel>(this string json, TModel defaultData)
        {
            Newtonsoft.Json.JsonConvert.PopulateObject(json, defaultData);
            return defaultData;
        }

        public static string GetAlphatecChar(this int index)
        {
            const string letters = "ABCDEFGHIİJKLMNOPQRSTUVWXYZ";

            string value = "";

            if (index >= letters.Length)
                value += letters[index / letters.Length - 1];

            value += letters[index];

            return value;
        }

        public static bool DoesPropertyExist(dynamic settings, string name)
        {
            if (settings is ExpandoObject)
                return ((IDictionary<string, object>)settings).ContainsKey(name);

            return settings.GetType().GetProperty(name) != null;
        }

        public static string FirstCharToUpper(this string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
                return input[0].ToString().ToUpper() + input.Substring(1).ToLower();
            else
                return input;
        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static string IsNullOrEmpty(this string text, string defaultVal)
        {
            return string.IsNullOrWhiteSpace(text) ? defaultVal : text;
        }

        public static DateTime? ToDateTime(this string text)
        {
            try
            {
                return Convert.ToDateTime(text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static long? ToLong(this object text)
        {
            try
            {
                return Convert.ToInt64(text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int? ToInt(this string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static double? ToDouble(this string text)
        {
            try
            {
                if (text.Contains(".") && !text.Contains(","))
                    text = text.Replace(".", ",");
                else if (text.Contains(".") && text.Contains(","))
                    text = text.Replace(".", "");

                //text = text.Replace('.', ',');
                //return Convert.ToDouble(text.Replace(',', '.'));
                return double.Parse(text.Trim(), CultureInfo.GetCultureInfo("tr-TR"));
            }
            catch (Exception ex)
            {
                return (double?)null;
            }
        }
    }
}
