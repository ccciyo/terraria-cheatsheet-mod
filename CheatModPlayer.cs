using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatModPlayer : ModPlayer
{
    public override void Initialize()
    {
        TileID.Sets.CanBeDugByShovel = TileID.Sets.Factory.CreateBoolSet(false);
    }

    public override void PostUpdateEquips()
    {
        Player.tileRangeX = 60;
        Player.tileRangeY = 60;
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

    public override void ResetEffects()
    {
        Player.maxMinions += 2;
        Player.maxTurrets += 2;
    }
}