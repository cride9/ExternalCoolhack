using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoolHack {
    internal class thirdperson {
        public static void ThirdPerson() {

            bool thirdperson = false;

            while (true) {

                if (!menu.MainMenu[6].ElementState)
                    continue;

                if (CheatMain.GetAsyncKeyState(System.Windows.Forms.Keys.Q) < 0) {
                    thirdperson = !thirdperson;
                    Thread.Sleep(100);
                }

                CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_iObserverMode)}", "byte", thirdperson ? "1" : "0");
            }
        }
    }
}
