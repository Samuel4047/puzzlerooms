using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxChange : MonoBehaviour
{
    public Material skybox;


    private void OnTriggerEnter(Collider other)
    {
        if(RenderSettings.skybox != skybox && other.tag == "Player")
        {
            RenderSettings.skybox = skybox;
        }
    }
}
