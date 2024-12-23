using System.Diagnostics;

namespace ConsoleSideScroller
{
    public class Stage
    {
        private const int FLOOR_Y = 20;
        private const int MAX_OBSTACLE_COUNT = 2;

        private Player CurrentPlayer;
        private List<Obstacle> Obstacles = new List<Obstacle>();
        private List<Obstacle> TempDeleteObstacles = new List<Obstacle>();
        private Stopwatch ObstacleStopWatch = new Stopwatch();
        private int GenObstacleCount = 0;
        private TimeSpan RandomResponeTime;



        public Stage()
        {
            CurrentPlayer = new Player(20, FLOOR_Y);

            ObstacleStopWatch.Start();
            ResetRandomResponeTime();
        }



        public bool Run(ConsoleKey key)
        {
            if (GenObstacleCount < MAX_OBSTACLE_COUNT 
                && ObstacleStopWatch.Elapsed > RandomResponeTime)
            {
                GenObstacleCount++;

                Obstacles.Add(new Obstacle(100, FLOOR_Y));
                ObstacleStopWatch.Restart();
                ResetRandomResponeTime();
            }

            switch (key)
            {
                case ConsoleKey.Escape:
                    return false;
                default:
                    break;
            }

            Console.Clear();

            // Obstacle
            foreach (var obstacle in Obstacles)
            {
                if (!obstacle.RenderObstacle(FLOOR_Y))
                    TempDeleteObstacles.Add(obstacle);
            }

            foreach (var delObstacle in TempDeleteObstacles)
                Obstacles.Remove(delObstacle);

            TempDeleteObstacles.Clear();

            // Player
            CurrentPlayer.Run(key);
            CurrentPlayer.RenderPlayer(20, FLOOR_Y);

            // Floor
            RenderFloor();

            // Check Collision
            foreach (var obstacle in Obstacles)
            {
                if (CurrentPlayer.IsHit(obstacle))
                {
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game Over...");

                    Obstacles.Clear();

                    Thread.Sleep(3000);

                    return false;
                }
            }

            // Check Clear
            if (GenObstacleCount >= MAX_OBSTACLE_COUNT && Obstacles.Count <= 0)
            {
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Stage Clear!");
                Thread.Sleep(3000);
                return false;
            }

            return true;
        }



        private void RenderFloor()
        {
            var floor = new string('━', Console.WindowWidth);

            Console.SetCursorPosition(0, FLOOR_Y);
            Console.WriteLine(floor);
        }

        private void ResetRandomResponeTime()
        {
            RandomResponeTime = TimeSpan.FromSeconds(Random.Shared.Next(2, 5));
        }
    }
}
