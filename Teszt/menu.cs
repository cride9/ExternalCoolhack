using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
    internal class menu {

        public static List<Menu> MainMenu = new List<Menu>();
        static int input = 0;
        static bool change = false;

        private static void MenuRender() {

            Console.Clear();

            for (int i = 0; i < MainMenu.Count; i++) {

                if (input == i) {
                    if (change) {
                        MainMenu[i].ElementState = !MainMenu[i].ElementState;
                        change = false;
                    }
                    Console.WriteLine($"<{MainMenu[i]}>");

                }
                else
                    Console.WriteLine(" " + MainMenu[i] + " ");
            }
            Console.WriteLine("\n\nSave config: F1");
            Console.WriteLine("Load config: F2");
        }

        private static void InitializeMenu() {

            MainMenu.Add(new Menu() { ElementName = "Bhop", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "Glow", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "Triggerbot (E)", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "Fov", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "Fakelag (4t)", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "No Flash", ElementState = false });
            MainMenu.Add(new Menu() { ElementName = "Thirdperson (Q)", ElementState = false });
            //MainMenu.Add(new Menu() { ElementName = "Radar", ElementState = false });
        }

        public static void InitializeCheat() {


            InitializeMenu();
            MenuRender();

        Start:
            switch (Console.ReadKey().Key) {

                case ConsoleKey.DownArrow: {
                        if (input + 1 < MainMenu.Count)
                            input++;
                        MenuRender();
                    }
                    break;

                case ConsoleKey.UpArrow: {
                        if (input > 0)
                            input--;
                        MenuRender();
                    }
                    break;

                case ConsoleKey.Enter: {
                        change = true;
                        MenuRender();
                    }
                    break;

                case ConsoleKey.F1: {
                        config.SaveConfig();
                    }
                    break;
                case ConsoleKey.F2: {
                        config.LoadConfig();
                        MenuRender();
                    }
                    break;
            }
            goto Start;
        }
    }

    class Menu {

        public string ElementName;
        public bool ElementState;

        public override string ToString() {

            string ONOFF = ElementState ? "ON" : "OFF";

            return $"{ElementName,-15}: {ONOFF,-3}";

        }
    }

}
