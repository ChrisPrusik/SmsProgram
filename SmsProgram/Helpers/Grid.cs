using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace SmsProgram
{
    public static class Grid
    {

        public static bool IsDataPropertyName(DataGridViewCell cell1, DataGridViewCell cell2)
        {
            return cell1.OwningColumn.DataPropertyName == cell2.OwningColumn.DataPropertyName;
        }

        public static bool IsDataPropertyName(DataGridViewColumn column1, DataGridViewColumn column2)
        {
            return column1.DataPropertyName == column2.DataPropertyName;
        }

        public static bool IsDataPropertyName(DataGridViewColumn gridColumn, DataColumn column)
        {
            return gridColumn.DataPropertyName == column.ColumnName;
        }

        public static bool IsDataPropertyName(DataGridViewCell cell, DataColumn column)
        {
            return IsDataPropertyName(cell.OwningColumn, column);
        }

        public static bool IsPrimaryKey(DataGridViewCell cell)
        {
            return IsDataPropertyName(cell, GetPrimaryKeyCell(cell.OwningRow));
        }

        public static DataGridViewCell GetPrimaryKeyCell(DataGridViewRow row)
        {
            foreach (DataGridViewCell cell in row.Cells)
                if (cell.OwningColumn.DataPropertyName ==
                    (cell.OwningColumn.DataGridView.DataSource as DataTable).PrimaryKey[0].ColumnName)
                    return cell;
            return null;
        }

        public static DataGridViewCell GetCell(DataGridViewRow row, DataColumn column)
        {
            foreach (DataGridViewCell cell in row.Cells)
                if (IsDataPropertyName(cell, column))
                    return cell;

            return null;
        }

        public static string GetStringValue(DataGridViewCell cell)
        {
            if (cell != null && cell.Value != null)
                return cell.Value.ToString();
            else
                return "";
        }
    }
}
