using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeProject_v2
{
    public class Maze //현재 미로에 대한 정보를 저장하는 클래스.
    {
        private static Maze maze = new Maze();

        public static Maze getInstance()
        {
            return maze;
        }

        int[,] myMaze = null;
        location2D start = null;
        location2D end = null;
        int row = 0;
        int column = 0;

        
        public location2D Start
        {
            get
            {
                return start;
            }          
        }

        public location2D End
        {
            get
            {
                return end;
            }
        }

        public int Row
        {
            get
            {
                return row;
            }         
        }
        public int Column
        {
            get
            {
                return column;
            }         
        }

        private Maze()
        {
            start = new location2D();
            end = new location2D();
        }

        public void ShowMaze()
        {
            for (int x = 0; x < myMaze.GetLength(0); x++) //1차원 배열의 길이를 구함 -> 행의길이
            {
                for (int y = 0; y < myMaze.GetLength(1); y++) //2차원 배열의 길이를 구함 -> 열의 길이
                {
                    if(myMaze[x,y] == 0)
                        Console.Write("□");
                    else if(myMaze[x,y] == 1)
                        Console.Write("■");
                    else if(myMaze[x,y] == 2)
                        Console.Write("▨");
                    else
                        Console.Write("※");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public ref int[,] getMaze()
        {
            return ref myMaze;
        }

        public void changeMaze(int i, int row, int column)
        {
            int temp = myMaze[row, column];
            myMaze[row, column] = i;
        }
        public void Find()
        {
            row = myMaze.GetLength(0);
            column = myMaze.GetLength(1);

            for (int i = 1; i < column; i++)
            {
                if (myMaze[0,i] == 0)
                    start.setlocation(0, i);
                if (myMaze[row - 1,i] == 0)
                    end.setlocation(row - 1, i);
            }
            for (int i = 1; i < row; i++)
            {
                if (myMaze[i,0] == 0)
                    start.setlocation(i, 0);
                if (myMaze[i,column - 1] == 0)
                    end.setlocation(i, column - 1);
            }
            Console.WriteLine("입구 위치 : ({0},{1}),출구 위치 : ({2},{3})\n", start.getRow(), start.getColumn()
            , end.getRow(), end.getColumn());
            //printf("입구 위치 : (%d,%d),출구 위치 : (%d,%d)\n", start.getRow(), start.getColumn()
            //    , end.getRow(), end.getColumn());
        }

        
    }
}
