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

                if (menu.MainMenu[4].ElementState) {

                    if (CheatMain.local == 0 || CheatMain.localhealth < 1) {
                        CheatMain.bSendPacket(true);
                        continue;
                    }

                    if (CheatMain.chokedpackets < 4)
                        CheatMain.bSendPacket(false);
                    else
                        CheatMain.bSendPacket(true);
                }
                else
                    CheatMain.bSendPacket(true);
            }
        }
    }
}
