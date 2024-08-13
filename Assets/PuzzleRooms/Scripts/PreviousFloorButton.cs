using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousFloorButton : MonoBehaviour
{
    private PartManager partManager;
    private ModTouchButton button;

    private void Awake()
    {
        partManager = PartManager.GetPartManagerOfFloor(gameObject.scene);
        button = GetComponent<ModTouchButton>();
        button.isAllowedToPress += PreviousFloor;
    }

    bool PreviousFloor(ModTouchButton touchButton, ModPlayerCharacter character, ModRagdollHandJoint handJoint)
    {
        if (touchButton != null && button != null && touchButton == button)
        {
            partManager.TeleportPlayerToPreviousFloor(character);
        }

        return true;
    }
}
