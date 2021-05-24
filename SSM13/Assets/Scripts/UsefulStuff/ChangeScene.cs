using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string scene = "";
    public LoadSceneMode loadSceneMode = LoadSceneMode.Single;

    public void Change()
    {
        SceneManager.LoadScene(scene, loadSceneMode);
    }
}
