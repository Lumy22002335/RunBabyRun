using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void OnEnable()
    {
        SceneManager.LoadScene("Room", LoadSceneMode.Single);
    }
}
