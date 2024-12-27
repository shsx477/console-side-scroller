namespace ConsoleSideScroller
{
    public static class Util
    {
        private static int CONSOLE_WIDTH_BUFF = Console.BufferWidth;
        private static int CONSOLE_HEIGHT_BUFF = Console.BufferHeight;

        public static void ClearConsole()
        {
            int height = CONSOLE_HEIGHT_BUFF;

            while (height-- > 0)
            {
                Console.SetCursorPosition(0, height);
                Console.Write(new string(' ', CONSOLE_WIDTH_BUFF));
            }
        }
    }

    //public static void ClearConsole()
    //{
    //    //int curTop = Console.CursorTop;
    //    //int curLeft = Console.CursorLeft;
    //    int height = CONSOLE_HEIGHT_BUFF;

    //    while (height-- > 0)
    //    {
    //        Console.SetCursorPosition(0, height);
    //        Console.Write(new string(' ', CONSOLE_WIDTH_BUFF));
    //    }

    //    //Console.SetCursorPosition(curLeft, curTop);
    //}
}
