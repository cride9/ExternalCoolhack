using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
    internal class noflash {
        public static void RemoveFlash() {

            while (true) {

                if (CheatMain.local == 0)
                    continue;

                if (menu.MainMenu[5].ElementState) {

                    CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_flFlashMaxAlpha)}", "float", "51");
                }
                else {
                    CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_flFlashMaxAlpha)}", "float", "255");
                }
            }
        }
    }
}
