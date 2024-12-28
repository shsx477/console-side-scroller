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
        ________   __                             ___________                 
        ______  | / /_____ _______ ___ ______     ______  __ \____  _________ 
        _____   |/ / _  _ \__  __ `__ \_  __ \    _____  /_/ /_  / / /__  __ \
        ____  /|  /  /  __/_  / / / / // /_/ /    ____  _, _/ / /_/ / _  / / /
        ___/_/ |_/   \___/ /_/ /_/ /_/ \____/     ___/_/ |_|  \__,_/  /_/ /_/ 
");
            Console.WriteLine();

            for (int i = 0; i < MenuItemTexts.Count; i++)
            {
                string arrow = (i == (int)SelectedMenuItem) ? "▶ " : "   ";
                Console.WriteLine("        " + arrow + MenuItemTexts[i]);
            }
        }
    }
}
