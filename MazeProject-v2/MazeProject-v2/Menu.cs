using System;

namespace MazeProject_v2
{
    internal class Menu //메뉴를 보여줌
    {
        static Maze maze = null; //사용자의 미로를 저장
        static ExploreMaze explore = null;

        internal static void executeMainMenu()
        {
            while (true)
            {
                Console.WriteLine("1. 미로 입력");
                Console.WriteLine("2. 미로 탐색");
                Console.WriteLine("3. 나가기");
                int.TryParse(Console.ReadLine(),out int ch);
                excute(ch);
            }
        }

        private static void excute(int ch)
        {        
            switch (ch)
            {
                case 1:
                    Console.WriteLine("1. 파일 미로 입력");
                    Console.WriteLine("2. 랜덤 미로 생성");
                    Console.WriteLine("3. 나가기");
                    int.TryParse(Console.ReadLine(), out int ch2);
                    selectMakeMazeMethod(ch2);
                    break;
                case 2:
                    if (maze == null)
                    {
                        Console.WriteLine("입력된 미로가 없습니다. 미로를 생성해주세요");
                        break;
                    }
                    Console.WriteLine("1. 미로 탐색");
                    Console.WriteLine("2. 최소 거리 탐색");
                    Console.WriteLine("3. 나가기");
                    int.TryParse(Console.ReadLine(), out int ch3);
                    selectExploreMazeMethod(ch3);
                    break;
                case 3:
                    return;
                    
                default:
                    Console.WriteLine("잘못된 인수를 입력함");
                    break;
            }
        }

        private static void selectMakeMazeMethod(int ch)
        {
            maze = Maze.getInstance();
            MakeMaze mm = null;
            switch (ch)
            {
                case 1:
                    mm = MakeFileMaze.getInstance();
                    mm.make(ref maze.getMaze());
                    break;
                case 2:
                    Console.WriteLine("아직 미구현 입니다");
                    return;
                case 3:
                    return;
                default:
                    Console.WriteLine("잘못된 인수를 입력하셨습니다.");
                    return;

            }
            maze.ShowMaze();
        }

        private static void selectExploreMazeMethod(int ch)
        {           
            switch (ch)
            {
                case 1:
                    maze.Find();
                    explore = NoEffExplore.getInstance();                  
                    break;
                case 2:
                    
                    Console.WriteLine("미구현 입니다.");
                    return;
                case 3:
                    return;
                default:
                    Console.WriteLine("잘못된 인수를 입력했습니다.");
                    break;
            }
            explore.Explore(ref maze);
          
            
        }
    }
}