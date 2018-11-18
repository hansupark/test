using System;

namespace MazeProject_v2
{
    public class location2D
    {
        int x;
        int y;

        public location2D()
        {
            x = 0;
            y = 0;
        }

        public location2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal void setlocation(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int getRow()
        {
            return x;
        }

        internal int getColumn()
        {
            return y;
        }

        internal bool isSame(location2D l)
        {
            return x == l.getRow() && y == l.getColumn();
        }
    }
}