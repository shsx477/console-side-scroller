namespace ConsoleSideScroller
{
    public class Obstacle
    {
        private const char OBSTACLE_CHARACTER = '■';

        private int X;
        private int Y;
        private int Width;
        private int Height;
        private int FloorY;
        


        public Obstacle(int x, int floorY)
        {
            Width = Random.Shared.Next(1, 3);
            Height = Random.Shared.Next(1, 3);
            X = x;
            Y = floorY - Height;
            FloorY = floorY;
        }



        public bool RenderObstacle(int floorY)
        {
            --X;

            if (X < 0)
                return false;

            var wTemp = new string(OBSTACLE_CHARACTER, Width);
            
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(X, floorY - (i + 1));
                Console.WriteLine(wTemp);
            }

            return true;
        }

        public bool IsHit(int playerPosX, int playerPosY)
        {
            if (playerPosX >= X && playerPosX < X + Width 
                && playerPosY >= Y && playerPosY < FloorY)
            {
                return true;
            }

            return false;
        }
    }
}
