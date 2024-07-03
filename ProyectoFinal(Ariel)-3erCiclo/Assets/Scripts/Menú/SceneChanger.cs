using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string SceneChange)
    {
        SceneManager.LoadScene(SceneChange);
        Debug.Log("pepe");
    }
}
