using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    [SerializeField] TextMesh loadText;

    void OnMouseDown() {
        loadText.text = "Loading...";
        Invoke("LoadLevelOne", 2);
    }

    private void LoadLevelOne() {
        SceneManager.LoadScene(1);
    }
}
