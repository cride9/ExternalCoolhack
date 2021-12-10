using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace CoolHack {
    internal class fov {
        public static void FovChanger() {

            while (true) {

                if (!menu.MainMenu[3].ElementState)
                    continue;

                if (CheatMain.scoped == 0) {

                    //m_zoomlevel == 1 ; 40
                    //m_zoomlevel == 2 ; 15

                    CheatMain.Fov(menu.MainMenu[3].ElementState ? 110 : 90);
                }
            }
        }
    }
}
