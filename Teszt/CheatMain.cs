using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace CoolHack {

    internal class CheatMain {

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vkey);

        public static string ReadHex(Int32 value) {

            return "0x" + value.ToString("X");
        }


        public static int local;
        public static int localhealth;
        public static int chokedpackets;
        public static int scoped;

        public static Mem Memory = new Mem();
        static void Main(string[] args) {

            int PID = Memory.GetProcIdFromName("csgo");

            Thread Main = new Thread(menu.InitializeCheat);
            Main.Start();

            if (PID != 0) {
                Memory.OpenProcess(PID);

                Thread Variables = new Thread(() => ReadVariables()) { IsBackground = true };
                Variables.Start();

                Thread Bunnyhop = new Thread(() => bhop.Bhop()) { IsBackground = true };
                Bunnyhop.Start();

                Thread Triggerbot = new Thread(() => triggerbot.DoTrigger()) { IsBackground = true };
                Triggerbot.Start();

                Thread Glow = new Thread(() => glow.DoGlow()) { IsBackground = true };
                Glow.Start();

                Thread Fov = new Thread(() => fov.FovChanger()) { IsBackground = true };
                Fov.Start();

                Thread Fakelag = new Thread(() => fakelag.DoFakelag()) { IsBackground = true };
                Fakelag.Start();

                Thread NoFlash = new Thread(() => noflash.RemoveFlash()) { IsBackground = true };
                NoFlash.Start();

                Thread ThirdPerson = new Thread(() => thirdperson.ThirdPerson()) { IsBackground = true };
                ThirdPerson.Start();

                //Thread Radar = new Thread(() => radar.Radar()) { IsBackground = true };
                //Radar.Start();

                //Thread ConfigSave = new Thread(() => config.SaveConfig()) { IsBackground = true };
                //ConfigSave.Start();

                //Thread ConfigLoad = new Thread(() => config.LoadConfig()) { IsBackground = true };
                //ConfigLoad.Start();

                //Thread SkinChanger = new Thread(() => skinchanger.ChangeSkin()) { IsBackground = true };
                //SkinChanger.Start();
            }
            else {
                Console.Clear();
                Console.WriteLine("Process not found (csgo.exe)");
                Thread.Sleep(5000);
                return;
            }
        }

        public static void ReadVariables() {
            while (true) {

                local = Memory.ReadInt($"client.dll+{ReadHex(hazedumper.signatures.dwLocalPlayer)}");
                localhealth = Memory.ReadInt($"{ReadHex(local)}+{ReadHex(hazedumper.netvars.m_iHealth)}");
                if (local != 0 && localhealth > 1) {
                    chokedpackets = Memory.ReadByte($"engine.dll+{ReadHex(hazedumper.signatures.dwClientState)},{ReadHex(hazedumper.signatures.clientstate_choked_commands)}");
                    scoped = Memory.ReadInt($"{ReadHex(local)}+{ReadHex(hazedumper.netvars.m_bIsScoped)}");
                }
            }
        }
        public static int GetEntitybyIndex(int index) {

            return Memory.ReadInt($"client.dll+{ReadHex(hazedumper.signatures.dwEntityList + index * 0x10)}");
        }
        public static void bSendPacket(bool input) {

            Memory.WriteMemory($"engine.dll+{ReadHex(hazedumper.signatures.dwbSendPackets)}", "byte", input ? "1" : "0");
        }

        public static void Fov(int input) {
            Memory.WriteMemory($"{ReadHex(local)}+{ReadHex(hazedumper.netvars.m_iFOV)}", "int", input.ToString());
        }
    }
}
