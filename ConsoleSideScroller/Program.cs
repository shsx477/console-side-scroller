using System.Runtime.Versioning;

namespace ConsoleSideScroller
{
    internal class Program
    {
        private static MainMenu Menu = new MainMenu();
        private static GameStage Stage = null;



        [SupportedOSPlatform("windows")]
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
            Console.SetBufferSize(100, 40);

            Define.WindowMode selectedWindow = Define.WindowMode.MainMenu;

            var inputKey = ConsoleKey.None;

            // 초기 메뉴 렌더
            Menu.Run(ConsoleKey.None);

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
                            Menu.Run(inputKey);

                            // 엔터 입력 -> 선택된 메뉴 실행
                            if (inputKey == ConsoleKey.Enter)
                            {
                                switch (Menu.SelectedMenuItem)
                                {
                                    case Define.MenuItem.Start:
                                        selectedWindow = Define.WindowMode.Game;
                                        Stage = new GameStage();
                                        Util.ClearConsole();
                                        break;
                                    case Define.MenuItem.Exit:
                                        return;
                                }
                            }
                        }
                        break;
                    case Define.WindowMode.Game:
                        if (!Stage?.Run(inputKey) ?? false)
                        {
                            selectedWindow = Define.WindowMode.MainMenu;
                            Menu.Run(ConsoleKey.None);
                        }

                        break;
                    default:
                        break;
                }

                Thread.Sleep(10);
            }
        }   
    }
}
