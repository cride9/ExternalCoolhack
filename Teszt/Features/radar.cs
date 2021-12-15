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

                    Entity pEnt = CheatMain.GetEntitybyIndex(i);

                    if (pEnt.ID == 0)
                        continue;

                    if (pEnt.m_iHealth() < 1)
                        continue;

                    if (pEnt.m_bDormant())
                        continue;

                }
            }
        }
    }
}
