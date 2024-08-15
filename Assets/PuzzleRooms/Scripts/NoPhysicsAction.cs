using ModWobblyLife;
using ModWobblyLife.Network;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPhysicsAction : ModNetworkBehaviour
{
    private ModActionEnterExitInteract action;
    private Transform playerTransform;
    private Vector3 seatPos;

    private void Awake()
    {
        TryGetComponent(out action);
        action.onPlayerEntered += OnPlayerEntered;
        action.onPlayerExited += OnPlayerExited;
        
    }

    private void OnPlayerEntered(ModPlayerController controller)
    {
        playerTransform = controller.GetPlayerCharacter().GetPlayerTransform();
        seatPos = playerTransform.position;
    }

    private void OnPlayerExited(ModPlayerController controller)
    {
        playerTransform = null;
        seatPos = Vector3.zero;
    }

    private void Update()
    {
        if(playerTransform != null)
        {
        }
    }
}
