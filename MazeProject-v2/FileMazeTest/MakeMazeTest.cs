using System;
using MazeProject_v2;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FileMazeTest
{
    [TestClass]
    public class MakeMazeTest
    {
        [TestMethod]
        public void TestMazeInf() //파일에서 입력되는 미로의 각 값들을 테스트
        {
            //준비
            MakeFileMaze maze = new MakeFileMaze();
            maze.mesuareMaze();
            int[,] test = null;
            //실행
            maze.make(test);
            //결과
            
        }
    }
}
