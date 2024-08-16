using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<ModPlayerCharacter>())
        {
            var character = other.GetComponentInParent<ModPlayerCharacter>();
            ModdedGameMode.Instance.SetPlayerProgress(character.GetPlayerController(), PartManager.GetPartManagerOfFloor(gameObject.scene));
        }
    }
}
