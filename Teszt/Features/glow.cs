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
        static int GlowIndex;
        static int BaseEntity;
        static int EntityTeam;
        static int EntityHP;
        static int Dormant;
        static int LocalTeam;

        public static void DoGlow() {

            while (true) {

                Thread.Sleep(1);

                if (menu.MainMenu[1].ElementState) {

                    for (int i = 0; i < 32; i++) {

                        //SetupPlayer(i);

                        BaseEntity = CheatMain.GetEntitybyIndex(i);

                        if (BaseEntity == 0) 
                            continue;

                        EntityHP = m.ReadInt($"{CheatMain.ReadHex(BaseEntity)}+{CheatMain.ReadHex(hazedumper.netvars.m_iHealth)}");
                        Dormant = m.ReadInt($"{CheatMain.ReadHex(BaseEntity)}+{CheatMain.ReadHex(hazedumper.signatures.m_bDormant)}");

                        if (Dormant == 1 || EntityHP < 1)
                            continue;

                        EntityTeam = m.ReadInt($"{CheatMain.ReadHex(BaseEntity)}+{CheatMain.ReadHex(hazedumper.netvars.m_iTeamNum)}");
                        LocalTeam = m.ReadInt($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_iTeamNum)}");

                        if (LocalTeam != EntityTeam) {
                            GlowIndex = m.ReadInt($"{CheatMain.ReadHex(BaseEntity)}+{CheatMain.ReadHex(hazedumper.netvars.m_iGlowIndex)}");
                            Draw(GlowIndex, 115, 118, 201, 160);
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
