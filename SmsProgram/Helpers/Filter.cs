using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;

namespace SmsProgram
{
    public static class Filter
    {
        public static string Encode(string tableName, string filterName, string expression)
        {
            if (tableName.Trim() != "")
                return (tableName.Trim() + "." + filterName.Trim()  + "| " + expression.Trim()).Trim();
            else if (filterName.Trim() != "")
                return (filterName.Trim() + "| " + expression.Trim()).Trim();
            else
                return expression.Trim();
        }

        public static string Encode(string filterName, string expression)
        {
            return Encode("", filterName, expression);
        }

        public static string RemoveTable(string filter)
        {
            return Encode(DecodeShortName(filter), DecodeExpression(filter));
        }

        public static string InsertTable(string filter, string tableName)
        {
            return Encode(tableName, DecodeShortName(filter), DecodeExpression(filter));
        }

        public static string DecodeTableName(string filter)
        {
            string name = DecodeFullName(filter);
            if (name.IndexOf(".") >= 0)
                return name.Substring(0, name.IndexOf(".")).Trim();
            else
                return "";
        }

        public static string DecodeShortName(string filter)
        {
            string name = DecodeFullName(filter);
            if (name.IndexOf(".") >= 0)
                return name.Remove(0, name.IndexOf(".") + 1).Trim();
            else
                return name.Trim();
        }

        public static string DecodeFullName(string filter)
        {
            if (filter.Trim() == "")
                return "";
            else if (filter.IndexOf("|") >= 0)
            {
                string name = filter.Trim();
                if (name.IndexOf("|") < 0)
                    throw new Exception(String.Format(Messages.ErrorBadFilter, filter));
                else
                    return name.Substring(0, name.IndexOf("|")).Trim();
            }
            else
                return "";
        }

        public static string DecodeExpression(string filter)
        {
            if (filter.Trim() == "")
                return "";
            else if (filter.IndexOf("|") >= 0)
            {
                string value = filter.Trim();
                if (value.IndexOf("|") < 0)
                    throw new Exception(String.Format(Messages.ErrorBadFilter, filter));
                else
                    return value.Remove(0, value.IndexOf("|") + 1).Trim();
            }
            else
                return filter.Trim();
        }

        public static void ToListBox(string repository, DataTable table, 
            ListBox.ObjectCollection collection)
        {
            collection.Clear();
            foreach (string filter in ToList(repository, table))
                collection.Add(Templater.ToCaptions(table.Columns, RemoveTable(filter)));
        }

        public static void ToAutoComplete(string repository, DataTable table, 
            AutoCompleteStringCollection collection)
        {
            collection.Clear();
            foreach (string filter in ToList(repository, table))
                collection.Add(Templater.ToCaptions(table.Columns, RemoveTable(filter)));
        }

        public static List<string> ToList(string repository, DataTable table)
        {
            List<string> list = new List<string>();
            foreach (string filter in ToList(repository))
                if (DecodeTableName(filter) == table.TableName)
                    list.Add(filter);
            return list;
        }

        public static List<string> ToList(string repository)
        {
            List<string> list = new List<string>();
            foreach (string line in
                repository.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                list.Add(line);
            return list;
        }

        public static string ToString(List<string> repository)
        {
            StringBuilder str = new StringBuilder();
            foreach(string line in repository)
                if (line.Trim() != "")
                    str.AppendLine(line.Trim());
            return str.ToString();
        }

        public static void Delete(string filter, List<string> repository)
        {
            for (int index = 0; index < repository.Count; index++)
                if (DecodeFullName(filter) == DecodeFullName(repository[index]))
                    repository[index] = "";
        }

        public static string Delete(string filter, string repository)
        {
            List<string> list = ToList(repository);
            Delete(filter, list);
            return ToString(list);
        }

        public static void Update(string filter, List<string> repository)
        {
            bool found = false;
            for (int index = 0; index < repository.Count; index++)
                if (DecodeFullName(filter) == DecodeFullName(repository[index]))
                {
                    repository[index] = filter;
                    found = true;
                }
            if (found == false)
                repository.Add(filter);
        }

        public static string Get(string filter, List<string> repository)
        {
            for (int index = 0; index < repository.Count; index++)
                if (DecodeFullName(filter) == DecodeFullName(repository[index]))
                    return repository[index];
            return "";
        }

        public static string Get(string filter, string repository)
        {
            return Get(filter, ToList(repository));
        }

        public static string Update(string filter, string repository)
        {
            List<string> list = ToList(repository);
            Update(filter, list);
            return ToString(list);
        }

        public static string Add(string sourceFilter, string filterExpression, bool or)
        {
            string filter = Filter.DecodeExpression(sourceFilter);
            try
            {
                if (or)
                {
                    if (filter != "")
                        filter = String.Format("({0}) OR ({1})", filter,
                            Filter.DecodeExpression(filterExpression));
                    else
                        filter = Filter.DecodeExpression(filterExpression);
                }
                else
                {
                    if (filter != "")
                        filter = String.Format("{0} AND {1}", filter, 
                            Filter.DecodeExpression(filterExpression));
                    else
                        filter = Filter.DecodeExpression(filterExpression);
                }
                return filter;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(Messages.ErrorBadFilter, filter) + ex.Message);
            }
        }

    }
}
