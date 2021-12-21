using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolHack {
    internal class triggerbot {

        public static void DoTrigger() {

            int crosshairid;

            while (true) {

                if (!menu.MainMenu[2].ElementState)
                    return;

                Entity pLocal = new Entity() { ID = CheatMain.local };
                Thread.Sleep(1);

                if (CheatMain.GetAsyncKeyState(Keys.E) < 0) {

                    if (pLocal.ID == 0 || pLocal.m_iHealth() < 1)
                        continue;

                    crosshairid = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_iCrosshairId)}");

                    if (crosshairid == 0 || crosshairid > 64)
                        continue;

                    CheatMain.Memory.WriteMemory($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwForceAttack)}", "int", "5");
                    Thread.Sleep(20);
                    CheatMain.Memory.WriteMemory($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwForceAttack)}", "int", "4");
                }
            }
        }
    }
}
