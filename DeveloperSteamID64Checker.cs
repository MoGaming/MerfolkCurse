using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace MerfolkCurse
{
    public class DeveloperSteamID64Checker //Thx to dardon for code
    {
        private List<string> SteamId64List;
        private static DeveloperSteamID64Checker instance;
        private static string CurrentSteamID64;

        public static DeveloperSteamID64Checker getInstance()
        {
            if (instance == null)
            {
                instance = new DeveloperSteamID64Checker();
            }

            return instance;
        }

        private DeveloperSteamID64Checker()
        {
            SteamId64List = new List<string>();

            PropertyInfo SteamID64Info = typeof(ModLoader).GetProperty("SteamID64", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo SteamID64 = SteamID64Info.GetAccessors(true)[0];
            CurrentSteamID64 = (string)SteamID64.Invoke(null, new object[] { });

            SteamId64List.Add("76561198123701463"); //MoGaming
        }

        public bool verifyID()
        { 
            return SteamId64List.Contains(CurrentSteamID64);
        }

        /*public void CopyIDToClipboard()
        {
            Thread thread = new Thread(() => Clipboard.SetText(CurrentSteamID64));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }*/
    }
}