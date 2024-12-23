namespace ConsoleSideScroller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Define.WindowMode selectedWindow = Define.WindowMode.MainMenu;

            var mainMenu = new MainMenu();
            var inputKey = ConsoleKey.None;
            Stage stage = null;

            // 초기 메뉴 렌더
            mainMenu.Run(ConsoleKey.None);

            while (true)
            {
                inputKey = ConsoleKey.None;

                if (Console.KeyAvailable)
                    inputKey = Console.ReadKey(true).Key;

                switch (selectedWindow)
                {
                    case Define.WindowMode.MainMenu:
                        if (inputKey != ConsoleKey.None)
                        {
                            // MainMenu에 키 전달
                            mainMenu.Run(inputKey);

                            // 엔터 입력 -> 선택된 메뉴 실행
                            if (inputKey == ConsoleKey.Enter)
                            {
                                switch (mainMenu.SelectedMenuItem)
                                {
                                    case Define.MenuItem.Start:
                                        selectedWindow = Define.WindowMode.Game;
                                        stage = new Stage();
                                        Console.Clear();
                                        break;
                                    case Define.MenuItem.Exit:
                                        return;
                                }
                            }
                        }
                        break;
                    case Define.WindowMode.Game:
                        if (!stage?.Run(inputKey) ?? false)
                        {
                            selectedWindow = Define.WindowMode.MainMenu;
                            mainMenu.Run(ConsoleKey.None);
                        }

                        break;
                    default:
                        break;
                }

                Thread.Sleep(50);
            }
        }   
    }
}
