using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace CoolHack {
    internal class bhop {

        static Mem m = CheatMain.Memory;

        public static void Bhop() {

            int Jumping;

            while (true) {

                if (menu.MainMenu[0].ElementState) {

                    if (CheatMain.GetAsyncKeyState(Keys.Space) < 0) { // while pressing the space

                        if (CheatMain.local == 0 || CheatMain.localhealth < 1)
                            continue;

                        Jumping = m.ReadInt($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_fFlags)}");

                        if (Jumping == 257 || Jumping == 263) { // on ground

                            // 4 - not jumping
                            // 5 - jumping
                            m.WriteMemory($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwForceJump)}", "int", "5");
                            Thread.Sleep(20);
                            m.WriteMemory($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwForceJump)}", "int", "4");
                        }
                    }
                }
            }
        }
    }
}
