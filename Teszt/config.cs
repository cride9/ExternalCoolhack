using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CoolHack {
    internal class config {

        public static void SaveConfig() {

            // Made like this bcs StreamWriter CANNOT DELETE FREAKING LINES thanks!

            File.WriteAllText("C:\\config.txt", $"{menu.MainMenu[0].ElementState}\n" +
                                                $"{menu.MainMenu[1].ElementState}\n" +
                                                $"{menu.MainMenu[2].ElementState}\n" +
                                                $"{menu.MainMenu[3].ElementState}\n" +
                                                $"{menu.MainMenu[4].ElementState}\n" +
                                                $"{menu.MainMenu[5].ElementState}\n" +
                                                $"{menu.MainMenu[6].ElementState}\n");
        }
        public static void LoadConfig() {

            StreamReader reader = new StreamReader("C:\\config.txt");

            for (int i = 0; i < menu.MainMenu.Count; i++) {
                if (!reader.EndOfStream) {
                    menu.MainMenu[i].ElementState = bool.Parse(reader.ReadLine());
                }
            }
            reader.Close();
        }
    }
}
