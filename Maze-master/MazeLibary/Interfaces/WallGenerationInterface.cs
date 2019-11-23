using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary.Interfaces
{
    public interface WallGenerationInterface
    {
        List<BaseCell> GenerateMaze(int height, int width);
    }
}
