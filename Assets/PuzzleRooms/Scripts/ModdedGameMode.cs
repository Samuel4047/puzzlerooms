using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UMod;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModdedGameMode : ModFreemodeGamemode
{
    public static ModdedGameMode Instance;

    public SceneField[] floors;

    [HideInInspector]
    public List<ModPlayerController> playerProgress_Keys = new List<ModPlayerController>();

    [HideInInspector]
    public List<PartManager> playerProgress_Values = new List<PartManager>();


    protected override void ModAwake()
    {
        base.ModAwake();

        Instance = this;

        foreach (var scene in floors)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    protected override void OnSpawnedPlayerCharacter(ModPlayerController playerController, ModPlayerCharacter playerCharacter)
    {
        base.OnSpawnedPlayerCharacter(playerController, playerCharacter);

        if (!playerProgress_Keys.Contains(playerCharacter.GetPlayerController()))
        {
            StartCoroutine(SetPlayerProgressStart(playerCharacter));
        }
        else
        {
            var partManager = playerProgress_Values[playerProgress_Keys.IndexOf(playerCharacter.GetPlayerController())];
            partManager.TeleportPlayerToThisFloor(playerCharacter);
        }
    }

    private IEnumerator SetPlayerProgressStart(ModPlayerCharacter playerCharacter)
    {
        var floor0 = SceneManager.GetSceneByName(floors[0]);

        for(int i = 0; i < 60; i++)
        {
            if (floor0.GetRootGameObjects().Length == 0)
                yield return null;
            else
                break;
        }

        var partManager = PartManager.GetPartManagerOfFloor(floor0);

        if (partManager == null) throw new System.Exception("Could not find part manager in floor with index 0");

        playerProgress_Keys.Add(playerCharacter.GetPlayerController());
        playerProgress_Values.Add(partManager);

        partManager.TeleportPlayerToThisFloor(playerCharacter);
    }

    public override ModPlayerCharacterSpawnPoint GetPlayerSpawnPoint(ModPlayerController playerController)
    {
        if(playerProgress_Keys.Count != 0)
            return playerProgress_Values[playerProgress_Keys.IndexOf(playerController)].startPosition;
        else
            return base.GetPlayerSpawnPoint(playerController);
    }
}
