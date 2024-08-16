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
            // Notify the puzzle manager when the plate is stepped on
            puzzleManager.PlatePressed(gameObject);
        }
    }
}
