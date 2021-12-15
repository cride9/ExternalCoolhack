using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Memory;

namespace CoolHack {
    internal class fov {
        public static void FovChanger() {

            Entity pLocal = new Entity() { ID = CheatMain.local};

            while (true) {
                Thread.Sleep(1);

                if (!pLocal.m_bIsScoped()) {

                    //m_zoomlevel == 1 ; 40
                    //m_zoomlevel == 2 ; 15

                    CheatMain.Fov(menu.MainMenu[3].ElementState ? 110 : 90);
                }
            }
        }
    }
}
