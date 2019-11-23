namespace MazeLibrary.Cells
{
    public class Exit : BaseCell
    {
        public Exit(Coordinates coordinates) : base(coordinates, 'E')
        {
        }

        public Exit(int x, int y) : base(x, y, 'E')
        {
        }

        public override bool TryToStep()
        {
            return true;
        }
    }
}