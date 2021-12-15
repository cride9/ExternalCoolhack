using Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CoolHack {

    internal class glow {

        static Mem m = CheatMain.Memory;

        static string Client = "client.dll+";
        static string GlowObjectManager = Client + CheatMain.ReadHex(hazedumper.signatures.dwGlowObjectManager) + ",";

        public static void DoGlow() {

            while (true) {

                Thread.Sleep(1);

                if (menu.MainMenu[1].ElementState) {

                    for (int i = 0; i < 32; i++) {

                        Entity BaseEntity = CheatMain.GetEntitybyIndex(i);
                        Entity Local = new Entity() { ID = CheatMain.local };

                        if (BaseEntity.ID == 0) 
                            continue;

                        if (BaseEntity.m_bDormant()|| BaseEntity.m_iHealth() < 1)
                            continue;

                        if (Local.m_iTeamNum() != BaseEntity.m_iTeamNum()) {

                            Draw(BaseEntity.m_iGlowIndex(), 115, 118, 201, 160);
                        }
                    }
                }
            }
        }

        static void Draw(int index, float R, float G, float B, float A) {

            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x8), "float", (R / 255).ToString());   // Red
            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0xC), "float", (G / 255).ToString());   // Green
            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x10), "float", (B / 255).ToString());  // Blue
            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x14), "float", (A / 255).ToString());  // Alpha

            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x28), "int", "1");
            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x29), "int", "1");
            m.WriteMemory(GlowObjectManager + CheatMain.ReadHex(index * 0x38 + 0x2D), "int", "2");
        }
    }
}
