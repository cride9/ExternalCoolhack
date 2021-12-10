using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHack {
	internal class skinchanger {

		static int WEAPON_KNIFE = 42;
		static int WEAPON_KNIFE_T = 59;
		static int WEAPON_KNIFE_BAYONET = 500;         // 0
		static int WEAPON_KNIFE_FLIP = 505;            // 1
		static int WEAPON_KNIFE_GUT = 506;             // 2
		static int WEAPON_KNIFE_KARAMBIT = 507;        // 3
		static int WEAPON_KNIFE_M9_BAYONET = 508;      // 4
		static int WEAPON_KNIFE_TACTICAL = 509;        // 5
		static int WEAPON_KNIFE_FALCHION = 512;        // 6
		static int WEAPON_KNIFE_SURVIVAL_BOWIE = 514;  // 7
		static int WEAPON_KNIFE_BUTTERFLY = 515;       // 8
		static int WEAPON_KNIFE_PUSH = 516;            // 9
		static int WEAPON_KNIFE_URSUS = 519;           // 10
		static int WEAPON_KNIFE_GYPSY_JACKKNIFE = 520; // 11
		static int WEAPON_KNIFE_STILETTO = 522;        // 12
		static int WEAPON_KNIFE_WIDOWMAKER = 523;       // 13

		static int precache_bayonet_ct = 87;
		static int precache_bayonet_t = 63;

		public static void ChangeSkin() {


			int[] knifeIDs = {
				WEAPON_KNIFE_BAYONET,
				WEAPON_KNIFE_FLIP,
				WEAPON_KNIFE_GUT,
				WEAPON_KNIFE_KARAMBIT,
				WEAPON_KNIFE_M9_BAYONET,
				WEAPON_KNIFE_TACTICAL,
				WEAPON_KNIFE_FALCHION,
				WEAPON_KNIFE_SURVIVAL_BOWIE,
				WEAPON_KNIFE_BUTTERFLY,
				WEAPON_KNIFE_PUSH,
				WEAPON_KNIFE_URSUS,
				WEAPON_KNIFE_GYPSY_JACKKNIFE,
				WEAPON_KNIFE_STILETTO,
				WEAPON_KNIFE_WIDOWMAKER
			};

			while (true) {
				Skins(1, WEAPON_KNIFE_BAYONET, 558);
			}
		}

		static void Skins(int knifeID, int itemDef, int paintKit) {

			const int itemIDHigh = -1;
			const int entityQuality = 3;
			const float fallbackWear = 0.0001f;

			int knifeIDOffset = knifeID < 10 ? 0 : 1; /* precache offset id by 1 for new knives */

			int cachedPlayer = 0;
			int modelIndex = 0;

			while (true) {
				int localPlayer = CheatMain.local;
				if (localPlayer == 0) /* localplayer is not connected to any server (unreliable method) */
				{
					modelIndex = 0;
					continue;
				}
				else if (localPlayer != cachedPlayer) /* localplayer changed by server switch / demo record */
				{
					modelIndex = 0;
					cachedPlayer = localPlayer;
				}

				if (paintKit > 0 && modelIndex > 0) {
					for (int i = 0; i < 8; i++) {
						/* handle to weapon entity in the current slot */
						int currentWeapon = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(localPlayer)}+{CheatMain.ReadHex(hazedumper.netvars.m_hMyWeapons + i * 0x4)}") & 0xfff;
						currentWeapon = CheatMain.Memory.ReadInt($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwEntityList + (currentWeapon - 1) * 0x10)}");
						if (currentWeapon == 0) { continue; }

						/* id of the weapon in the current slot */
						int wepid = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemDefinitionIndex)}");

						int fallbackPaint = paintKit;
						if (wepid == 1) { fallbackPaint = 37; } /* Desert Eagle | Blaze */
						else if (wepid == 4) { fallbackPaint = 38; } /* Glock-18 | Fade */
						else if (wepid == 7) { fallbackPaint = 180; } /* AK-47 | Fire Serpent */
						else if (wepid == 9) { fallbackPaint = 344; } /* AWP | Dragon Lore */
						else if (wepid == 60) { fallbackPaint = 445; } /* M4A1-S | Hot Rod */
						else if (wepid == 61) { fallbackPaint = 653; } /* USP-S | Neo-Noir */
						else if (wepid != WEAPON_KNIFE && wepid != WEAPON_KNIFE_T && wepid != itemDef) { continue; }
						else {
							/* knife-specific memory writes */

							CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemDefinitionIndex)}", "int", itemDef.ToString());
							CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_nModelIndex)}", "int", modelIndex.ToString());
							CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_nViewModelIndex)}", "int", modelIndex.ToString());
							CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_iEntityQuality)}", "int", entityQuality.ToString());
						}
						/* memory writes necessary for both knives and other weapons in slots */
						CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemIDHigh)}", "int", itemIDHigh.ToString());
						CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_nFallbackPaintKit)}", "int", fallbackPaint.ToString());
						CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(currentWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_flFallbackWear)}", "int", fallbackWear.ToString());
					}
				}

				/* handle to weapon entity we are currently holding in hands */
				int activeWeapon = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(localPlayer)}+{CheatMain.ReadHex(hazedumper.netvars.m_hActiveWeapon)}") & 0xfff;
				activeWeapon = CheatMain.Memory.ReadInt($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwEntityList + (activeWeapon - 1) * 0x10)}");
				if (activeWeapon == 0) { continue; }

				/* id of weapon we are currently holding in hands */
				int weaponID = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(activeWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_iItemDefinitionIndex)}");

				/* viewmodel id of the weapon in our hands (default ct knife should usually be around 300) */
				int weaponViewModelID = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(activeWeapon)}+{CheatMain.ReadHex(hazedumper.netvars.m_nViewModelIndex)}");

				/* calculate the correct modelindex using the index of default knives and the precache list */
				if (weaponID == WEAPON_KNIFE && weaponViewModelID > 0) {
					modelIndex = weaponViewModelID + precache_bayonet_ct + 3 * knifeID + knifeIDOffset;
				}
				else if (weaponID == WEAPON_KNIFE_T && weaponViewModelID > 0) {
					modelIndex = weaponViewModelID + precache_bayonet_t + 3 * knifeID + knifeIDOffset;
				}
				else if (weaponID != itemDef || modelIndex == 0) { continue; }

				/* handle to viewmodel entity we will use to change the knife viewmodel index */
				int knifeViewModel = CheatMain.Memory.ReadInt($"{CheatMain.ReadHex(localPlayer)}+{CheatMain.ReadHex(hazedumper.netvars.m_hViewModel)}") & 0xfff;
				knifeViewModel = CheatMain.Memory.ReadInt($"client.dll+{CheatMain.ReadHex(hazedumper.signatures.dwEntityList + (knifeViewModel - 1) * 0x10)}");
				if (knifeViewModel == 0) { continue; }

				/* change our current viewmodel but only if localplayer is holding a knife in hands */
				CheatMain.Memory.WriteMemory($"{CheatMain.ReadHex(knifeViewModel)}+{CheatMain.ReadHex(hazedumper.netvars.m_nModelIndex)}", "int", modelIndex.ToString());

			}
		}
	}
}
