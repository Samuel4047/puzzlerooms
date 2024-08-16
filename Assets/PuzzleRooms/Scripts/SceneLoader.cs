using System.Collections;
using System.Collections.Generic;
using UMod;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ModScriptBehaviour
{
    public void LoadScene(string nameOrPath, bool additive)
    {
        var mode = additive ? LoadSceneMode.Additive : LoadSceneMode.Single;
        ModScenes.Load(nameOrPath, additive);
    }
}
