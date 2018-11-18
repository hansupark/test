using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazeProject_v2
{
    class NoEffExplore : ExploreMaze
    {

        Maze maze; //사용자의 미로에 대해 정보를 가지는 maze
        int[,] userMaze; //사용자의 해당 미로를 저장하는 2차원 배열
        private static NoEffExplore explore = new NoEffExplore();

        Stack<location2D> visit = null;
        Stack<location2D> cango = null;

        private NoEffExplore()
        {
            visit = new Stack<location2D>();
            cango = new Stack<location2D>();
        }

        public static NoEffExplore getInstance()
        {
            return explore;
        }

        public override void Explore(ref Maze maze)
        {
            this.maze = maze;
            userMaze = maze.getMaze();
            go(maze.Start);
        }

        public void search(ref location2D current) //시게방향으로 검사(up->right->down->left)
        {
            int n = 0;
            //배열의 길이에 따라 search의 행동이 달라짐
            //분기점을 만날때만 cango에 넣어야함
            if (isvisitable(current.getRow(), current.getColumn() - 1)) //왼쪽 검사
            {
                n++;
            }
            if (isvisitable(current.getRow() + 1, current.getColumn())) //아래쪽 검사
            {
                n++;
            }
            if (isvisitable(current.getRow(), current.getColumn() + 1)) //오른쪽 검사
            {
                n++;
            }
            if (isvisitable(current.getRow() - 1, current.getColumn())) //위쪽 검사
            {
                n++;
            }
            //printf("방문 노드 갯수 : %d\n", n);
            if (n == 0)
            {
                while (true)
                {
                    userMaze[visit.Peek().getRow(),visit.Peek().getColumn()] = 3;
                    if ((visit.Pop()).isSame(cango.Peek()))
                    {
                        cango.Pop();
                        break;
                    }
                }
                go((cango.Peek()));
            }

            else if (n == 1)
            { // 방문 가능 노드 갯수가 1개인 경우에는 cango에 넣은 것을 바로 뺴서 그곳으로 방문한다.
                go((cango.Pop()));
            }

            else
            {
                //cout << "분기점 도달" << "\n";
                maze.ShowMaze();
                go(cango.Peek());
            }
        }

        private bool isvisitable(int row, int column)
        {
            
            if ((row >= 0 && maze.Row > row) && (column >= 0 && maze.Column > column))
            {
                if (userMaze[row,column] == 0)
                {
                    //printf("row :%d , column : %d 방문가능\n", row, column);
                    cango.Push((new location2D(row, column)));
                    return true;
                }
                //else
                //printf("row :%d , column : %d 방문불가(방문가능 노드 지역이 아님)\n", row, column);
            }
            //else
            //printf("row :%d , column : %d 방문불가(미로범위가 아님)\n", row, column);
            return false;
        }

        private void go(location2D l)
        {
            if (userMaze[l.getRow(),l.getColumn()] == 0) //처음 방문할때
            {
                visit.Push(l);
                maze.changeMaze(2, l.getRow(), l.getColumn());
                if (l.isSame(maze.End))
                {
                    visit.Push(l);
                    //cout << "출구 도착 !" << "\n";
                    maze.ShowMaze();
                }
                else
                    search(ref l);
            }
            else if (userMaze[l.getRow(),l.getColumn()] == 2) //방문했던 노드일때
                search(ref l);
            else //길이 아닌걸로 확정난 노드일때
            {
                cango.Pop();
                go(cango.Peek());
            }
            
        }
    }
}
