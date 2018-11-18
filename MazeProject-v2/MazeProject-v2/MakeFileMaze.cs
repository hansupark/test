using System.IO;
using System;
namespace MazeProject_v2
{
    public class MakeFileMaze : MakeMaze
    {
        int row = 0;
        int column = 0;
        StreamReader sr = null;

        private static MakeFileMaze method = new MakeFileMaze();

        private MakeFileMaze()
        {
                
        }

        public static MakeFileMaze getInstance()
        {
            return method;
        }
        private void OpenFile()
        {
            sr = new StreamReader("maze.txt");
        }

        private void mesuareMaze()
        {
            string str;
            OpenFile();
            while ((str = sr.ReadLine()) != null)
            {
                if (column != 0 && column != str.Length)
                    break;
                column = str.Length;
                row++;
            }
            sr.Close();
        }

        public override void make(ref int[,] maze)
        {
            mesuareMaze();
            OpenFile();
            Console.WriteLine($"row  : {row} column : {column}");
            maze = new int[row,column];      
                for (int x = 0; x < row; x++)
                {
                    for (int y = 0; y < column; y++)
                    {
                        int ch = sr.Read();
                        while (ch != '1' && ch != '0') //해당 원소가 1이나 0일경우에만 받음
                        {
                            ch = sr.Read();
                        }
                        maze[x, y] = ch - '0';
                    }               
                }         
            sr.Close();
        }
    }
}