using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
    internal class Entity {

        public int ID;

        public int m_iHealth() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_iHealth)}");
        }
        public bool m_bDormant() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.signatures.m_bDormant)}") == 1 ? true : false;
        }
        public int m_iTeamNum() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_iTeamNum)}");
        }
        public int m_iGlowIndex() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_iGlowIndex)}");
        }
        public int m_fFlags() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_fFlags)}");
        }
        public bool m_bGunGameImmunity() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_bGunGameImmunity)}") == 1 ? true : false;
        }
        public bool m_bIsScoped() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_bIsScoped)}") == 1 ? true : false;
        }
        public bool m_bSpotted() {

            return CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_bSpotted)}") == 1 ? true : false;
        }
        public bool m_bSpotted(bool value) {

            return CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(ID)}+{CheatMain.ReadHex(hazedumper.netvars.m_bSpotted)}", "int", $"{(value ? 1 : 0)}");
        }

    }
}
