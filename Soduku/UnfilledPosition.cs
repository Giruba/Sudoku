using System;
using System.Collections.Generic;
using System.Text;

namespace Soduku
{
    class UnfilledPosition
    {
        int rowPosition;
        int columnPosition;

        public UnfilledPosition(int row, int col) {
            rowPosition = row;
            columnPosition = col;
        }

        public void SetRowPosition(int rowPosition) {
            this.rowPosition = rowPosition;
        }

        public void SetColumnPosition(int columnPosition) {
            this.columnPosition = columnPosition;
        }

        public int GetRowPosition() {
            return rowPosition;
        }

        public int GetColumnPosition() {
            return columnPosition;
        }
    }
}
