using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CheatSheet
{
    public class CheatSheet : Mod
    {
    }

    public class CheatGlobalWall : GlobalWall
    {
        public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }
    }

    public class CheatModSystem : ModSystem
    {
        public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
        {
            timeRate = CheatConfig.timeRate;
        }
    }

    public class CheatGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
            if (entity.axe > 0 || entity.pick > 0 || entity.hammer > 0 || entity.createTile > 0 ||
                entity.createWall > 0)
                entity.useTime = 1;
        }
    }

    public class CheatModPlayer : ModPlayer
    {
        public override void PostUpdateEquips()
        {
            Player.tileRangeX = 200;
            Player.tileRangeY = 200;
            Player.defaultItemGrabRange = 1000;
        }

        public override void ModifyLuck(ref float luck)
        {
            luck = 1f;
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Player.respawnTimer = 120;
        }
    }
}