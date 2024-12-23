﻿using System.Diagnostics;

namespace ConsoleSideScroller
{
    public class Stage
    {
        private const int FLOOR_Y = 20;
        private const int MAX_OBSTACLE_COUNT = 5;

        private Player CurrentPlayer;
        private List<Obstacle> Obstacles = new List<Obstacle>();
        private List<Obstacle> TempDeleteObstacles = new List<Obstacle>();
        private Stopwatch ObstacleStopWatch = new Stopwatch();
        private int TotalObstacleCount;
        private DateTime NextSpeedUpdateTime;
        private int GamePlaySpeedOffset = 40;
        private TimeSpan RandomObstacleResponeTime;



        public Stage()
        {
            CurrentPlayer = new Player(20, FLOOR_Y);
            NextSpeedUpdateTime = DateTime.Now.AddSeconds(3);

            ObstacleStopWatch.Start();
            ResetRandomResponeTime();
        }



        public bool Run(ConsoleKey inputKey)
        {
            // 입력된 키 처리
            switch (inputKey)
            {
                case ConsoleKey.Escape:
                    return false;
                default:
                    break;
            }

            CreateObstacleOrNot();

            Console.Clear();

            RenderObstacles();

            // Player
            CurrentPlayer.Run(inputKey);
            CurrentPlayer.RenderPlayer(20, FLOOR_Y);

            RenderFloor();

            if (CheckHit())
                return false;

            if (CheckClear())
                return false;

            UpdateGameSpeed();

            Thread.Sleep(GamePlaySpeedOffset);

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
            RandomObstacleResponeTime = TimeSpan.FromSeconds(Random.Shared.Next(2, 5));
        }

        private void CreateObstacleOrNot()
        {
            if (TotalObstacleCount < MAX_OBSTACLE_COUNT
                && ObstacleStopWatch.Elapsed > RandomObstacleResponeTime)
            {
                TotalObstacleCount++;

                Obstacles.Add(new Obstacle(100, FLOOR_Y));
                ObstacleStopWatch.Restart();
                ResetRandomResponeTime();
            }
        }

        private void RenderObstacles()
        {
            foreach (var obstacle in Obstacles)
            {
                if (!obstacle.RenderObstacle(FLOOR_Y))
                    TempDeleteObstacles.Add(obstacle);
            }

            foreach (var delObstacle in TempDeleteObstacles)
                Obstacles.Remove(delObstacle);

            TempDeleteObstacles.Clear();
        }

        private bool CheckHit()
        {
            foreach (var obstacle in Obstacles)
            {
                if (CurrentPlayer.IsHit(obstacle))
                {
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game Over...");

                    Obstacles.Clear();

                    Thread.Sleep(3000);

                    return true;
                }
            }

            return false;
        }

        private bool CheckClear()
        {
            if (TotalObstacleCount >= MAX_OBSTACLE_COUNT && Obstacles.Count <= 0)
            {
                Console.SetCursorPosition(20, 10);
                Console.WriteLine("Stage Clear!");
                Thread.Sleep(3000);
                return true;
            }

            return false;
        }

        private void UpdateGameSpeed()
        {
            if (NextSpeedUpdateTime < DateTime.Now)
            {
                NextSpeedUpdateTime = DateTime.Now.AddSeconds(Random.Shared.Next(1, 4));
                GamePlaySpeedOffset = Random.Shared.Next(1, 4) * 10;
            }
        }
    }
}