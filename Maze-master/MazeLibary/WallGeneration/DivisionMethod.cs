using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Interfaces;
using MazeLibrary.Cells;

namespace MazeLibrary.WallGeneration
{
    public class DivisionMethod : WallGenerationInterface
    {
        public List<BaseCell> GenerateMaze(int height, int width)
        {
            Maze maze = new Maze(height, width);
            
            for (int i = 1; i <= maze.Height - 2; i++)
            {
                for (int j = 1; j <= maze.Width - 2; j++)
                {
                    bool corridor = false;
                    while (corridor == false)
                    {
                        Console.WriteLine("y: " + i + "x: " + j);
                        int ChamberWidth = 0;
                        int ChamberHeight = 0;
                        while (maze[j + ChamberWidth + 1, i].TryToStep() == true && (maze[j + ChamberWidth + 1, i - 1].TryToStep() == true || maze[j + ChamberWidth + 1, i + 1].TryToStep() == true))
                        {
                            ChamberWidth++;
                        }
                        while (maze[j, i + ChamberHeight + 1].TryToStep() == true && (maze[j - 1, i + ChamberHeight + 1].TryToStep() == true || maze[j + 1, i + ChamberHeight + 1].TryToStep() == true))
                        {
                            ChamberHeight++;
                        }
                        if (ChamberHeight >= 2 && ChamberWidth >= 2)
                        {
                            if (ChamberHeight > 2 && ChamberWidth > 2) maze = ChamberCreator(maze, j, i, j + ChamberWidth, i + ChamberHeight);
                            else if ((ChamberWidth==2 && (maze[j + 1, i - 1].TryToStep() != true && maze[j + 1, i + ChamberHeight + 1].TryToStep() != true)) && (ChamberHeight==2 && (maze[j - 1, i + 1].TryToStep() != true && maze[j + ChamberWidth + 1, i + 1].TryToStep() != true))) maze = ChamberCreator(maze, j, i, j + ChamberWidth, i + ChamberHeight);
                            else corridor = true;
                        }
                        else corridor = true;

                    }
                }
            }
            bool Exit = false;
            for (int i=1;  i<= maze.Height - 2; i++)
            {
                for (int j = maze.Width - 2; j>=1; j--)
                {  
                    if (maze[j,i].TryToStep()==true)
                    {
                        Console.WriteLine(j+" "+i);
                        if (maze[j - 1, i].TryToStep() == false && maze[j - 1, i - 1].TryToStep() == false && maze[j, i - 1].TryToStep() == false)
                        {
                            maze[j, i] = new Exit(j, i);
                            Exit = true;
                            break;
                        }
                        if (maze[j,i-1].TryToStep() == false && maze[j+1,i-1].TryToStep() == false && maze[j+1, i].TryToStep() == false)
                        {
                            maze[j, i] = new Exit(j, i);
                            Exit = true;
                            break;
                        }
                        if (maze[j, i+1].TryToStep() == false && maze[j + 1, i + 1].TryToStep() == false && maze[j+1, i].TryToStep() == false)
                        {
                            maze[j, i] = new Exit(j, i);
                            Exit = true;
                            break;
                        }
                        if (maze[j - 1, i].TryToStep() == false && maze[j - 1, i + 1].TryToStep() == false && maze[j, i + 1].TryToStep() == false)
                        {
                            maze[j, i] = new Exit(j, i);
                            Exit = true;
                            break;
                        }
                    }
                }
                if (Exit == true) break;
            }


            return maze.Cells;
        }
        public static Maze ChamberCreator(Maze InitialMaze, int ChamberX, int ChamberY, int ChamberWidth, int ChamberHeight)
        {
            Random rnd = new Random();
            bool FreeEntrance = false;
            while (FreeEntrance != true)
            {
                int xVerticalWall = 0, yHorizontalWall = 0;
                while (xVerticalWall <= ChamberX)
                    xVerticalWall = rnd.Next(ChamberX, ChamberWidth);
                while (yHorizontalWall <= ChamberY)
                    yHorizontalWall = rnd.Next(ChamberY, ChamberHeight);
                Console.WriteLine("xVerticalWall:" + xVerticalWall + ";yHorizontalWall:" + yHorizontalWall + "; ChamberX:" + ChamberX + ";ChamberY:" + ChamberY + ";ChamberWidth:" + ChamberWidth + ";ChamberHeight:" + ChamberHeight);
                if (InitialMaze[xVerticalWall, ChamberHeight + 1].TryToStep() == false && InitialMaze[xVerticalWall, ChamberY - 1].TryToStep() == false && InitialMaze[ChamberX - 1, yHorizontalWall].TryToStep() == false && InitialMaze[ChamberWidth + 1, yHorizontalWall].TryToStep() == false)
                {
                    for (int i = ChamberX; i <= ChamberWidth; i++)
                    {
                        InitialMaze[i, yHorizontalWall] = new Wall(i, yHorizontalWall);
                    }
                    for (int i = ChamberY; i <= ChamberHeight; i++)
                    {
                        InitialMaze[xVerticalWall, i] = new Wall(xVerticalWall, i);
                    }
                    int hole = rnd.Next(ChamberX, xVerticalWall - 1);
                    Console.WriteLine("1 Hole: x - " + hole + " y - " + yHorizontalWall);
                    InitialMaze[hole, yHorizontalWall] = new Ground(hole, yHorizontalWall);
                    hole = rnd.Next(xVerticalWall + 1, ChamberWidth);
                    Console.WriteLine("2 Hole: x - " + hole + " y - " + yHorizontalWall);
                    InitialMaze[hole, yHorizontalWall] = new Ground(hole, yHorizontalWall);
                    hole = rnd.Next(yHorizontalWall + 1, ChamberHeight);
                    Console.WriteLine("3 Hole: x - " + xVerticalWall + " y - " + hole);
                    InitialMaze[xVerticalWall, hole] = new Ground(xVerticalWall, hole);
                }
                FreeEntrance = true;
            }
            return InitialMaze;
        }
    }
}