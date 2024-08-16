using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    public GameObject[] pressurePlates; // Assign pressure plates in the inspector
    public GameObject door; // Assign the door object in the inspector

    private int currentStep = 0;
    private List<GameObject> pressedPlates = new List<GameObject>();

    void Start()
    {
        // Initialize or set the door to the closed position
        door.SetActive(true); // Door is closed initially
    }

    public void PlatePressed(GameObject plate)
    {
        if (pressedPlates.Contains(plate)) return;

        if (plate == pressurePlates[currentStep])
        {
            // Correct plate pressed
            currentStep++;
            plate.GetComponent<Renderer>().material.color = Color.green; // Optional: change color to show activation

            if (currentStep == pressurePlates.Length)
            {
                // All plates pressed in correct order, open the door
                door.SetActive(false); // Deactivate the door to "open" it
            }

            pressedPlates.Add(plate);
        }
        else
        {
            // Incorrect plate pressed, reset puzzle
            currentStep = 0;

            // Reset all plates to initial state (optional)
            foreach (GameObject p in pressurePlates)
            {
                p.GetComponent<Renderer>().material.color = Color.red; // Optional: change back to initial color
            }

            pressedPlates.Clear();
        }
    }
}
