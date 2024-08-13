using ModWobblyLife;
using ModWobblyLife.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextFloorButton : MonoBehaviour
{
    private PartManager partManager;
    private ModTouchButton button;

    private void Awake()
    {
        partManager = PartManager.GetPartManagerOfFloor(gameObject.scene);
        button = GetComponent<ModTouchButton>();
        button.isAllowedToPress += NextFloor;
    }

    bool NextFloor(ModTouchButton touchButton, ModPlayerCharacter character, ModRagdollHandJoint handJoint)
    {
        if(touchButton != null && button != null && touchButton == button)
        {
            partManager.TeleportPlayerToNextFloor(character);
        }

        return true;
    }
}
