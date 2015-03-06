using System.Windows;
using System.Windows.Automation;
using White.Core.InputDevices;
using White.Core.UIItems.Finders;
using White.Core.UIItems.TableItems;
using White.Core.UIItems.WindowItems;

namespace SampleAppPlus.Tests.Framework.Elements
{
    public class MainGrid
    {
        private Table table;
        public MainGrid(Window window)
        {
            table = window.Get<Table>(SearchCriteria.ByControlType(ControlType.Table));
        }

        public string GetHeaderText()
        {
            TableColumns columns = table.Header.Columns;
            string value = columns[0].Name;
            return value;
        }

        public string GetCellText(int index)
        {
            TableCell cell = GetCell(index);
            string value = cell.Value as string;
            return value;
        }

        public int GetRowsCount()
        {
            return table.Rows.Count;
        }

        public void ClickAtRow(int row)
        {
            TableCell cell = GetCell(row);
            Point topLeft = cell.Bounds.TopLeft;
            topLeft.X += 5;
            topLeft.Y += 5;
            Mouse.instance.Click(topLeft);
        }

        private TableCell GetCell(int index)
        {
            TableRows rows = table.Rows;
            TableCells cells = rows[index - 1].Cells;
            return cells[0];
        }
    }
}
