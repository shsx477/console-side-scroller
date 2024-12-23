namespace ConsoleSideScroller
{
    public class MainMenu
    {
        public Define.MenuItem SelectedMenuItem { get; private set; }

        private List<string> MenuItemTexts = ["1.Start", "2.Exit"];



        public void Run(ConsoleKey inputKey)
        {
            Console.Clear();

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
            Console.WriteLine();

            for (int i = 0; i < MenuItemTexts.Count; i++)
            {
                string prefix = (i == (int)SelectedMenuItem) ? "▶ " : "   ";
                Console.WriteLine(prefix + MenuItemTexts[i]);
            }
        }
    }
}
