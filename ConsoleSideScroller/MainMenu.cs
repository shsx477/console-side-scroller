namespace ConsoleSideScroller
{
    public class MainMenu
    {
        public Define.MenuItem SelectedMenuItem { get; private set; }

        private List<string> MenuItemTexts = ["1.Start", "2.Exit"];



        public void Run(ConsoleKey inputKey)
        {
            Util.ClearConsole();

            switch (inputKey)
            {
                case ConsoleKey.UpArrow:
                    if (SelectedMenuItem > 0)
                        SelectedMenuItem--;
                    break;
                case ConsoleKey.DownArrow:
                    if (SelectedMenuItem != Define.MenuItem.Exit)
                        SelectedMenuItem++;
                    break;
                default:
                    break;
            }

            RenderMenu();
        }



        private void RenderMenu()
        {
            Console.WriteLine("\r\n           ________               \r\n           ___  __ \\___  ________ \r\n           __  /_/ /  / / /_  __ \\\r\n           _  _, _// /_/ /_  / / /\r\n           /_/ |_| \\__,_/ /_/ /_/ \r\n                                  \r\n");
            Console.WriteLine();

            for (int i = 0; i < MenuItemTexts.Count; i++)
            {
                string arrow = (i == (int)SelectedMenuItem) ? "▶ " : "   ";
                Console.WriteLine(arrow + MenuItemTexts[i]);
            }
        }
    }
}
