using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartManager : MonoBehaviour
{
    [Header("This Floor")]
    public ModPlayerCharacterSpawnPoint startPosition;

    [Header("Floors")]
    public SceneField nextFloor;
    public SceneField previousFloor;

    public void TeleportPlayerToNextFloor(ModPlayerCharacter character)
    {
        if(nextFloor != null || nextFloor != "")
        {
            var nextManager = GetPartManagerOfFloor(SceneManager.GetSceneByName(nextFloor));
            ModdedGameMode.Instance.playerProgress_Values[ModdedGameMode.Instance.playerProgress_Keys.IndexOf(character.GetPlayerController())] = nextManager;
            TeleportPlayerToFloor(nextManager, character);
        }
    }

    public void TeleportPlayerToPreviousFloor(ModPlayerCharacter character)
    {
        if(previousFloor != null || previousFloor != "")
        {
            var manager = GetPartManagerOfFloor(SceneManager.GetSceneByName(previousFloor));
            TeleportPlayerToFloor(manager, character);
        }
    }

    public static PartManager GetPartManagerOfFloor(Scene scene)
    {
        var nextRoomObjects = scene.GetRootGameObjects();

        PartManager partManager = null;
        foreach (var obj in nextRoomObjects)
        {
            if (obj.TryGetComponent(out partManager)) break;
        }

        return partManager;
    }

    public void TeleportPlayerToThisFloor(ModPlayerCharacter character)
    {
        ModdedGameMode.Instance.playerProgress_Values[ModdedGameMode.Instance.playerProgress_Keys.IndexOf(character.GetPlayerController())] = this;
        character.Kill();
    }

    public static PartManager TeleportPlayerToFloor(PartManager partManager, ModPlayerCharacter character)
    {
        ModdedGameMode.Instance.playerProgress_Values[ModdedGameMode.Instance.playerProgress_Keys.IndexOf(character.GetPlayerController())] = partManager;
        character.Kill();
        return partManager;
    }
}
