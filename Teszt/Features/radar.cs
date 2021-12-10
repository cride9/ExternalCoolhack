using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
    internal class radar {

        public static void Radar() {

            while (true) {

                if (!menu.MainMenu[7].ElementState)
                    continue;

                for (int i = 0; i < 64; i++) {

                    var Entity = CheatMain.GetEntitybyIndex(i);

                    if (Entity == 0)
                        continue;

                    if (CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(Entity)}+{CheatMain.ReadHex(hazedumper.netvars.m_iHealth)}") < 1)
                        continue;

                    if (CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(Entity)}+{CheatMain.ReadHex(hazedumper.signatures.m_bDormant)}") == 1)
                        continue;

                    CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(Entity)}+{CheatMain.ReadHex(hazedumper.netvars.m_bSpotted)}", "int", "0");

                }
            }
        }
    }
}
