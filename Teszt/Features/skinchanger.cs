using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
	enum KnifeIDs {

		WEAPON_KNIFE_T = 59,
		WEAPON_KNIFE_CT = 42,
		WEAPON_KNIFE_KARAM = 507,
		WEAPON_KNIFE_BAYONET = 500,
		WEAPON_KNIFE_CLASSIC = 503,
		WEAPON_KNIFE_FLIP = 505,
		WEAPON_KNIFE_GUT = 506,
		WEAPON_KNIFE_M9 = 508,
		WEAPON_KNIFE_HUNTSMAN = 509,
		WEAPON_KNIFE_FALCHION = 512,
		WEAPON_KNIFE_BOWIE = 514,
		WEAPON_KNIFE_BUTTERFLY = 515,
		WEAPON_KNIFE_DAGGERS = 516,
		WEAPON_KNIFE_PARACORD = 517,
		WEAPON_KNIFE_SURVIVAL = 518,
		WEAPON_KNIFE_URSUS = 519,
		WEAPON_KNIFE_NAVAJA = 520,
		WEAPON_KNIFE_NOMAD = 521,
		WEAPON_KNIFE_STILETTO = 522,
		WEAPON_KNIFE_TALON = 523,
		WEAPON_KNIFE_SKELETON = 525,
	}
	enum WeaponIDs {
		WEAPON_NONE,
		WEAPON_DEAGLE,
		WEAPON_ELITE,
		WEAPON_FIVESEVEN,
		WEAPON_GLOCK,
		WEAPON_P228,
		WEAPON_USP,
		WEAPON_AK47,
		WEAPON_AUG,
		WEAPON_AWP,
		WEAPON_FAMAS,
		WEAPON_G3SG1,
		WEAPON_GALIL,
		WEAPON_GALILAR,
		WEAPON_M249,
		WEAPON_M3,
		WEAPON_M4A1,
		WEAPON_MAC10,
		WEAPON_MP5NAVY,
		WEAPON_P90,
		WEAPON_SCOUT,
		WEAPON_SG550,
		WEAPON_SG552,
		WEAPON_TMP,
		WEAPON_UMP45,
		WEAPON_XM1014,
		WEAPON_BIZON,
		WEAPON_MAG7,
		WEAPON_NEGEV,
		WEAPON_SAWEDOFF,
		WEAPON_TEC9,
		WEAPON_TASER,
		WEAPON_HKP2000,
		WEAPON_MP7,
		WEAPON_MP9,
		WEAPON_NOVA,
		WEAPON_P250,
		WEAPON_SCAR17,
		WEAPON_SCAR20,
		WEAPON_SG556,
		WEAPON_SSG08,
		WEAPON_KNIFEGG,
		WEAPON_KNIFE,
		WEAPON_FLASHBANG,
		WEAPON_HEGRENADE,
		WEAPON_SMOKEGRENADE,
		WEAPON_MOLOTOV,
		WEAPON_DECOY,
		WEAPON_INCGRENADE,
		WEAPON_C4
	}

	internal class skinchanger {

		static int WeaponIndex;
		static int EntityList;
		static int CurrentWeaponID;

		private static void GetSkin(int WeaponID) {

			switch (WeaponID) {
				case (int)WeaponIDs.WEAPON_DEAGLE:
					SetSkin(328);
					break;
				case (int)WeaponIDs.WEAPON_ELITE:
					SetSkin(491);
					break;
				case (int)WeaponIDs.WEAPON_FIVESEVEN:
					SetSkin(660);
					break;
				case (int)WeaponIDs.WEAPON_GLOCK:
					SetSkin(586);
					break;
				case (int)WeaponIDs.WEAPON_USP:
					SetSkin(504);
					break;
				case (int)WeaponIDs.WEAPON_AK47:
					SetSkin(302);
					break;
				case (int)WeaponIDs.WEAPON_AUG:
					SetSkin(305);
					break;
				case (int)WeaponIDs.WEAPON_AWP:
					SetSkin(279);
					break;
				case (int)WeaponIDs.WEAPON_FAMAS:
					SetSkin(178);
					break;
				case (int)WeaponIDs.WEAPON_G3SG1:
					SetSkin(493);
					break;
				case (int)WeaponIDs.WEAPON_GALIL:
					SetSkin(379);
					break;
				case (int)WeaponIDs.WEAPON_GALILAR:
					SetSkin(379);
					break;
				case (int)WeaponIDs.WEAPON_M249:
					SetSkin(648);
					break;
				case (int)WeaponIDs.WEAPON_M3:
					SetSkin(648);
					break;
				case (int)WeaponIDs.WEAPON_M4A1:
					SetSkin(309);
					break;
				case (int)WeaponIDs.WEAPON_MAC10:
					SetSkin(433);
					break;
				case (int)WeaponIDs.WEAPON_MP5NAVY:
					SetSkin(433);
					break;
				case (int)WeaponIDs.WEAPON_P90:
					SetSkin(359);
					break;
				case (int)WeaponIDs.WEAPON_SCOUT:
					SetSkin(624);
					break;
				case (int)WeaponIDs.WEAPON_SG550:
					SetSkin(624);
					break;
				case (int)WeaponIDs.WEAPON_SG552:
					SetSkin(624);
					break;
				case (int)WeaponIDs.WEAPON_TMP:
					SetSkin(624);
					break;
				case (int)WeaponIDs.WEAPON_UMP45:
					SetSkin(556);
					break;
				case (int)WeaponIDs.WEAPON_XM1014:
					SetSkin(320);
					break;
				case (int)WeaponIDs.WEAPON_BIZON:
					SetSkin(236);
					break;
				case (int)WeaponIDs.WEAPON_MAG7:
					SetSkin(703);
					break;
				case (int)WeaponIDs.WEAPON_NEGEV:
					SetSkin(432);
					break;
				case (int)WeaponIDs.WEAPON_SAWEDOFF:
					SetSkin(517);
					break;
				case (int)WeaponIDs.WEAPON_TEC9:
					SetSkin(614);
					break;
				case (int)WeaponIDs.WEAPON_HKP2000:
					SetSkin(287);
					break;
				case (int)WeaponIDs.WEAPON_MP7:
					SetSkin(696);
					break;
				case (int)WeaponIDs.WEAPON_MP9:
					SetSkin(482);
					break;
				case (int)WeaponIDs.WEAPON_NOVA:
					SetSkin(537);
					break;
				case (int)WeaponIDs.WEAPON_P250:
					SetSkin(551);
					break;
				case (int)WeaponIDs.WEAPON_SCAR17:
					SetSkin(597);
					break;
				case (int)WeaponIDs.WEAPON_SCAR20:
					SetSkin(597);
					break;
				case (int)WeaponIDs.WEAPON_SG556:
					SetSkin(598);
					break;
				case (int)WeaponIDs.WEAPON_SSG08:
					SetSkin(624);
					break;
				case 61: // usp-s
					SetSkin(504);
					break;
				case 63: // cz-auto
					SetSkin(687);
					break;
				case 60: // m4a1-s
					SetSkin(644);
					break;
				default:
					SetSkin(0);
					break;

			}
		}

		public static void SkinChanger() {

			while (true) {

				Entity pLocal = new Entity() { ID = CheatMain.local };

				if (pLocal.ID == 0 || pLocal.m_iHealth() < 1)
					continue;

				for (int i = 0; i < 3; i++) {

					// Shadow Daggers: 516
					// Karambit: 507

					WeaponIndex = CheatMain.Memory.Read2Byte($"{CheatMain.ReadHex(CheatMain.local)}+{CheatMain.ReadHex(hazedumper.netvars.m_hMyWeapons + i * 0x4)}") & 0xfff;
					EntityList = CheatMain.Memory.ReadInt($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwEntityList + (WeaponIndex - 1) * 0x10)}");
					CurrentWeaponID = CheatMain.Memory.Read2Byte($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemDefinitionIndex)}");

					// Im pretty sure it's outdated but here you go
					// Skin ID list: https://steamcommunity.com/sharedfiles/filedetails/?id=880595913

					GetSkin(CurrentWeaponID);

				}
			}
        }
		private static void SetSkin(int skinid) {

			int CurrentSkin = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_nFallbackPaintKit)}");

			if (CurrentSkin != skinid) {

				CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemIDHigh)}", "int", $"{-1}");
				if (skinid == 279)
					CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_flFallbackWear)}", "float", $"{0.9999f}");
				else
					CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_flFallbackWear)}", "float", $"{0.0001f}");
				CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(EntityList)}+{CheatMain.ReadHex(hazedumper.netvars.m_nFallbackPaintKit)}", "int", $"{skinid}");

				CheatMain.Memory.WriteMemory($"engine.dll+{CheatMain.ReadHex(hazedumper.signatures.dwClientState)},{CheatMain.ReadHex(hazedumper.signatures.clientstate_delta_ticks)}", "int", "-1");
			}
		}
	}
}
