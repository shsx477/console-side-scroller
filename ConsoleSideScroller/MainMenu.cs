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
            Console.WriteLine(@"
        _____   __                                ________                 
        ___  | / /_____ _______ ___ ______        ___  __ \____  _________ 
        __   |/ / _  _ \__  __ `__ \_  __ \       __  /_/ /_  / / /__  __ \
        _  /|  /  /  __/_  / / / / // /_/ /       _  _, _/ / /_/ / _  / / /
        /_/ |_/   \___/ /_/ /_/ /_/ \____/        /_/ |_|  \__,_/  /_/ /_/ 
");
            Console.WriteLine();

            for (int i = 0; i < MenuItemTexts.Count; i++)
            {
                string arrow = (i == (int)SelectedMenuItem) ? "▶ " : "   ";
                Console.WriteLine(arrow + MenuItemTexts[i]);
            }
        }
    }
}
