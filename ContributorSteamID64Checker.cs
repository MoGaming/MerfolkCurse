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
    public class ContributorSteamID64Checker //Thx to dardon for code
    {
        private List<string> SteamId64List;
        private static ContributorSteamID64Checker instance;
        private static string CurrentSteamID64;

        public static ContributorSteamID64Checker getInstance()
        {
            if (instance == null)
            {
                instance = new ContributorSteamID64Checker();
            }

            return instance;
        }

        private ContributorSteamID64Checker()
        {
            SteamId64List = new List<string>();

            PropertyInfo SteamID64Info = typeof(ModLoader).GetProperty("SteamID64", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo SteamID64 = SteamID64Info.GetAccessors(true)[0];
            CurrentSteamID64 = (string)SteamID64.Invoke(null, new object[] { });

            SteamId64List.Add("76561198197795198"); //APlayer_, jelly blobs
            SteamId64List.Add("76561198087994542"); //PootisTweet, Casmir things
            SteamId64List.Add("76561198128534975"); //Hayato, fuck if i know
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