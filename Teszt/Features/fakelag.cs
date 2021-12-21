using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoolHack {
    internal class fakelag {
        public static void DoFakelag() {

            while (true) {

                if (!menu.MainMenu[4].ElementState) {
                    CheatMain.bSendPacket(true);
                    return;
                }

                Entity pLocal = new Entity() { ID = CheatMain.local };

                Thread.Sleep(1);

                if (pLocal.ID == 0 || pLocal.m_iHealth() < 1) {
                    CheatMain.bSendPacket(true);
                    continue;
                }

                if (CheatMain.Memory.ReadByte($"engine.dll+{CheatMain.ReadHex(hazedumper.signatures.dwClientState)},{CheatMain.ReadHex(hazedumper.signatures.clientstate_choked_commands)}") < 4)
                    CheatMain.bSendPacket(false);
                else
                    CheatMain.bSendPacket(true);
            }
        }
    }
}
