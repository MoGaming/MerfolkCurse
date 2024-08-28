using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using MerfolkCurse.ReflectedDamageClass;

namespace MerfolkCurse.Items.Weapons
{
    public class Gauche : ReflectedDamageItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gauche's Mirror");
        }

        public override void SafeSetDefaults()
        {
            item.damage = 10;
            item.noMelee = true;
            item.magic = true;
            item.channel = true; //Channel so that you can held the weapon [Important]
            item.mana = 5;
            item.rare = 5;
            item.width = 28;
            item.height = 30;
            item.useTime = 13;
            item.UseSound = SoundID.Item13;
            item.useStyle = 5;
            item.shootSpeed = 20f;
            item.useAnimation = 13;
            item.shoot = mod.ProjectileType("MirrorProj");
            item.value = Item.sellPrice(0, 0, 500, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MagicMirror);
            recipe.AddIngredient(ItemID.PocketMirror);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}