using Terraria.ModLoader;

namespace CheatSheet;

public class CheatModSystem: ModSystem
{
    public override void ModifyTimeRate(ref double timeRate, ref double tileUpdateRate, ref double eventUpdateRate)
    {
        timeRate = CheatConfig.TimeRate;
    }
}