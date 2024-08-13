using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedGameMode : ModFreemodeGamemode
{
    public static ModdedGameMode Instance;

    protected override void ModAwake()
    {
        base.ModAwake();

        Instance = this;
    }
}
