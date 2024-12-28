namespace ConsoleSideScroller
{
    public class Player
    {
        private const char PLAYER_CHARACTER = '▣';
        private const int BEEP_INCRESE_UNIT = 30;
        
        private int CurrentPosX;
        private int CurrentPosY;
        private int MaxJumpPower = 10;
        private int YOffset = 0;
        private bool IsGround = true;
        private bool IsJumpUp = false;
        private int StartBeep = 200;



        public Player(int x, int floorY)
        {
            CurrentPosX = x;
            CurrentPosY = floorY - 1;
        }



        public void Run(ConsoleKey inputKey)
        {
            switch (inputKey)
            {
                case ConsoleKey.Spacebar:
                    if (IsGround)
                    {
                        IsGround = false;
                        IsJumpUp = true;
                        YOffset = 1;

                        Task.Run(() =>
                        {
                            Console.Beep(StartBeep, 250);
                            StartBeep += BEEP_INCRESE_UNIT;
                        });
                    }
                    break;
                default:
                    break;
            }

            if (!IsGround)
            {
                if (IsJumpUp)
                {
                    if (YOffset == MaxJumpPower)
                    {
                        IsJumpUp = false;
                        YOffset--;
                    }
                    else
                    {
                        YOffset++;
                    }
                }
                else
                {
                    if (YOffset == 0)
                    {
                        IsGround = true;
                        YOffset = 0;
                    }
                    else
                    {
                        YOffset--;
                    }
                }
            }
        }

        public void RenderPlayer(int x, int floorY)
        {
            CurrentPosY = floorY - 1 - YOffset;

            Console.SetCursorPosition(x, CurrentPosY);
            Console.WriteLine(PLAYER_CHARACTER);
        }

        public bool IsHit(Obstacle obstacle)
        {
            return obstacle.IsHit(CurrentPosX, CurrentPosY);
        }
    }
}
