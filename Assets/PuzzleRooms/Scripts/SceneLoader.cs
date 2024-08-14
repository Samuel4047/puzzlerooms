using System.Collections;
using System.Collections.Generic;
using UMod;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ModScriptBehaviour
{
    public void LoadScene(string nameOrPath, bool additive)
    {
        ModScenes.Load(nameOrPath, additive);
    }
}
