using System;
using System.Drawing;

namespace Database.Models
{
    public class MatrixRegion : IEquatable<MatrixRegion>
    {
        private int? toRow;
        private int? toColumn;

        public MatrixRegion() { }

        public MatrixRegion(int fromRow, int fromColumn) : this(fromRow, fromColumn, fromRow, fromColumn) { }

        public MatrixRegion(int fromRow, int fromColumn, int toRow, int toColumn)
        {
            FromRow = fromRow;
            FromColumn = fromColumn;
            ToRow = toRow;
            ToColumn = toColumn;
        }

        public int FromRow { get; set; }

        public int FromColumn { get; set; }

        public int ToRow
        {
            get => toRow ?? FromRow;
            set => toRow = value;
        }

        public int ToColumn
        {
            get => toColumn ?? FromColumn;
            set => toColumn = value;
        }

        public bool IsOrigo => FromRow == 0 && FromColumn == 0;

        public bool IsCombined => FromRow != ToRow || FromColumn != ToColumn;

        public int RowSpan => ToRow - FromRow + 1;

        public int ColumnSpan => ToColumn - FromColumn + 1;

        public bool IsInRange(MatrixRegion other)
        {
            if (other == null)
            {
                return false;
            }

            return FromRow >= other.FromRow &&
                   ToRow <= other.ToRow &&
                   FromColumn >= other.FromColumn &&
                   ToColumn <= other.ToColumn;
        }

        public override bool Equals(object obj)
        {
            if (obj is MatrixRegion matrixRegion)
            {
                return Equals(matrixRegion);
            }
            return false;
        }

        public bool Equals(MatrixRegion other)
        {
            return FromRow == other.FromRow &&
                FromColumn == other.FromColumn &&
                ToRow == other.ToRow &&
                ToColumn == other.ToColumn;
        }

        public override int GetHashCode()
        {
            return FromRow + FromColumn;
        }

        public static bool operator ==(MatrixRegion left, MatrixRegion right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(MatrixRegion left, MatrixRegion right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            if (FromRow != ToRow || FromColumn != ToColumn)
            {
                return $"{FromRow}_{FromColumn}-{ToRow}_{ToColumn}";
            }
            return $"{FromRow}_{FromColumn}";
        }

        public Rectangle GetDrawDimensions(Size size)
        {
            var leftTopCoordinate = new Point(FromColumn * size.Width, FromRow * size.Height);
            var rightBottomCoordinate = new Point((ToColumn + 1) * size.Width, (ToRow + 1) * size.Height);
            return new Rectangle(leftTopCoordinate, new Size(rightBottomCoordinate.X - leftTopCoordinate.X, rightBottomCoordinate.Y - leftTopCoordinate.Y));
        }
    }
}
