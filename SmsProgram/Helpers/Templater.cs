using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

namespace SmsProgram
{
    public static class Templater
    {
        public static string ToCaptions(DataColumnCollection columns, string message)
        {
            foreach (DataColumn column in columns)
                message = ToValue(message, column.ColumnName, "[" + column.Caption + "]");
            return message;
        }

        public static string ToNames(DataColumnCollection columns, string message)
        {
            foreach (DataColumn column in columns)
                message = ToValue(message, column.Caption, "[" + column.ColumnName + "]");
            return message;
        }

        public static string ToValues(DataRow row, string message)
        {
            message = ToNames(row.Table.Columns, message);
            foreach (DataColumn column in row.Table.Columns)
                message = ToValue(message, column.ColumnName, row[column].ToString());
            return message;
        }

        public static string ToValue(string message, string columnName, object value)
        {
            message = ToValue(message, columnName, "[", "]", value);
            message = ToValue(message, columnName, "'", "'", value);
            return message;
        }

        public static string ToValue(string message, string columnName, string prefix, string postfix, object value)
        {
            int pos = message.IndexOf(prefix); 
            while(pos >= 0 && pos < message.Length)
            {
                int startPos = pos;
                pos = message.IndexOf(postfix, pos + 1);
                if (pos >= 0)
                {
                    if (pos - startPos - 1 > 0)
                    {
                        string[] current = message.Substring(startPos + 1, pos - startPos - 1).Split(':');
                        if (String.Compare(current[0].Trim(), columnName.Trim(), true) == 0)
                        {
                            message = message.Remove(startPos, pos - startPos + 1);
                            if (current.Length < 2)
                                message = message.Insert(startPos, value.ToString());
                            else if (value.GetType() == typeof(byte))
                                message = message.Insert(startPos, ((byte)value).ToString(current[1]));
                            else if (value.GetType() == typeof(sbyte))
                                message = message.Insert(startPos, ((sbyte)value).ToString(current[1]));
                            else if (value.GetType() == typeof(short))
                                message = message.Insert(startPos, ((short)value).ToString(current[1]));
                            else if (value.GetType() == typeof(ushort))
                                message = message.Insert(startPos, ((ushort)value).ToString(current[1]));
                            else if (value.GetType() == typeof(int))
                                message = message.Insert(startPos, ((int)value).ToString(current[1]));
                            else if (value.GetType() == typeof(uint))
                                message = message.Insert(startPos, ((uint)value).ToString(current[1]));
                            else if (value.GetType() == typeof(long))
                                message = message.Insert(startPos, ((long)value).ToString(current[1]));
                            else if (value.GetType() == typeof(ulong))
                                message = message.Insert(startPos, ((ulong)value).ToString(current[1]));
                            else if (value.GetType() == typeof(float))
                                message = message.Insert(startPos, ((float)value).ToString(current[1]));
                            else if (value.GetType() == typeof(double))
                                message = message.Insert(startPos, ((double)value).ToString(current[1]));
                            else if (value.GetType() == typeof(decimal))
                                message = message.Insert(startPos, ((decimal)value).ToString(current[1]));
                            else if (value.GetType() == typeof(DateTime))
                                message = message.Insert(startPos, ((DateTime)value).ToString(current[1]));
                            else
                                message = message.Insert(startPos, value.ToString());
                            pos = message.IndexOf(prefix, startPos + 1);
                        }
                        else
                            pos = message.IndexOf(prefix, pos + 1);
                    }
                    else
                        pos = message.IndexOf(prefix, pos + 1);
                }
            }
            return message;
        }
    }
}