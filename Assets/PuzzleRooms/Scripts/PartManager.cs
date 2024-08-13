using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartManager : MonoBehaviour
{
    [Header("This Floor")]
    public Transform startPosition;

    [Header("Floors")]
    public Scene nextFloor;
    public Scene previousFloor;
}
