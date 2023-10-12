using Terraria.ModLoader;

namespace CheatSheet;

public class CheatGlobalWall : GlobalWall
{
    public override void ModifyLight(int i, int j, int type, ref float r, ref float g, ref float b)
    {
        r = 1f;
        g = 1f;
        b = 1f;
    }
}