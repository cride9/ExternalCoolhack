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
        public static bool menurender;

        public static Mem Memory = new Mem();

        public static void RunThread(int i) {

            switch (i) {

                case 0:
                    Thread Bhop = new Thread(() => bhop.Bhop()) { IsBackground = true };
                    Bhop.Start();
                    break;

                case 1:
                    Thread Glow = new Thread(() => glow.DoGlow()) { IsBackground = true };
                    Glow.Start();
                    break;

                case 2:
                    Thread Triggerbot = new Thread(() => triggerbot.DoTrigger()) { IsBackground = true };
                    Triggerbot.Start();
                    break;

                case 3:
                    Thread Fov = new Thread(() => fov.FovChanger()) { IsBackground = true };
                    Fov.Start();
                    break;

                case 4:
                    Thread Fakelag = new Thread(() => fakelag.DoFakelag()) { IsBackground = true };
                    Fakelag.Start();
                    break;

                case 5:
                    Thread NoFlash = new Thread(() => noflash.RemoveFlash()) { IsBackground = true };
                    NoFlash.Start();
                    break;

                case 6:
                    Thread ThirdPerson = new Thread(() => thirdperson.ThirdPerson()) { IsBackground = true };
                    ThirdPerson.Start();
                    break;
            }

        }

        static void Main(string[] args) {

            bool LaunchCSGO = false;

            getpid:
            int PID = Memory.GetProcIdFromName("csgo");

            if (PID != 0) {
                Memory.OpenProcess(PID);

                Console.WriteLine("PID found!");
                Thread.Sleep(250);

                Thread Main = new Thread(menu.InitializeCheat);
                Main.Start();

            waitformenu:
                if (menurender) {

                    Thread Variables = new Thread(() => ReadVariables()) { IsBackground = true };
                    Variables.Start();

                    Thread SkinChanger = new Thread(() => skinchanger.SkinChanger()) { IsBackground = true };
                    SkinChanger.Start();
                }
                else
                    goto waitformenu;

            }
            else {
                Console.Clear();
                Console.WriteLine("PID not found!\n");

                Thread.Sleep(250);

                Console.WriteLine("Starting csgo...");

                if (!LaunchCSGO)
                    System.Diagnostics.Process.Start("steam://run/730");

                LaunchCSGO = true;
                Thread.Sleep(30000);

                goto getpid;
            }
        }

        public static void ReadVariables() {

            local = Memory.ReadInt($"client.dll+{ReadHex(hazedumper.signatures.dwLocalPlayer)}");
        }
        public static Entity GetEntitybyIndex(int index) {

            return new Entity() { ID = Memory.ReadInt($"client.dll+{ReadHex(hazedumper.signatures.dwEntityList + index * 0x10)}") };
        }
        public static void bSendPacket(bool input) {

            Memory.WriteMemory($"engine.dll+{ReadHex(hazedumper.signatures.dwbSendPackets)}", "byte", input ? "1" : "0");
        }

        public static void Fov(int input) {
            Memory.WriteMemory($"{ReadHex(local)}+{ReadHex(hazedumper.netvars.m_iFOV)}", "int", input.ToString());
        }
    }
}
