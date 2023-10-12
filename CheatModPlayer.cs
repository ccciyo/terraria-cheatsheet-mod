using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CheatSheet;

public class CheatModPlayer : ModPlayer
{
    public override void PostUpdateEquips()
    {
        Player.tileRangeX = 60;
        Player.tileRangeY = 60;
        Player.defaultItemGrabRange = 200;
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