using ModWobblyLife;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public PressurePlateManager puzzleManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<ModPlayerCharacter>())
        {
            puzzleManager.ServerPlatePressed(gameObject);
        }
    }
}
