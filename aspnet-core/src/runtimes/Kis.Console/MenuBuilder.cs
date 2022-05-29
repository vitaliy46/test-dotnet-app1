using System;
using System.Diagnostics;

namespace Kis.Console
{
    internal static class MenuBuilder
    {
        internal static void Show(MenuItem[] items, string menuHeader = null, string exitHeader = null, Action exitAction = null, Action<Exception> exceptionHandler = null)
        {
            var exiting = false;
            var defaultColor = System.Console.ForegroundColor;

            var exitMenu = new MenuItem(exitHeader ?? "Закрыть", () => { exitAction?.Invoke(); exiting = true; });

            while (!exiting)
            {
                System.Console.ForegroundColor = ConsoleColor.Cyan;
                if(menuHeader != null) { System.Console.WriteLine(menuHeader);}
                System.Console.WriteLine(@"┌─────┐");
                for (var i = 0; i < items.Length; i++)
                {
                    System.Console.WriteLine($"│ {i + 1,3:##0} │ {items[i].MenuTitle}");
                }
                System.Console.WriteLine(@"├─────┤");
                System.Console.WriteLine($"│ {0,3:##0} │ {exitMenu.MenuTitle}");
                System.Console.WriteLine(@"└─────┘");
                System.Console.ForegroundColor = defaultColor;
                System.Console.WriteLine();
                System.Console.Write(@"Введите номер пункта меню для запуска действия: ");
                while (true)
                {
                    int selectedMenu;
                    if (int.TryParse(System.Console.ReadLine(), out selectedMenu) &&

                        selectedMenu >= 0 && selectedMenu <= items.Length)
                    {
                        try
                        {
                            if (selectedMenu == 0)
                            {
                                exitMenu.MenuAction();
                            }
                            else
                            {
                                items[selectedMenu - 1].MenuAction();
                                System.Console.WriteLine(@"Операция завершена!!!");
                            }
                        }
                        catch (Exception ex) when (!Debugger.IsAttached)
                        {
                            if (exceptionHandler != null) exceptionHandler.Invoke(ex);
                            else { throw; }
                        }

                        System.Console.WriteLine();
                        break;
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine(@"Неверно указан пункт меню. Повторите ввод: ");
                }
            }
        }
    }
}
