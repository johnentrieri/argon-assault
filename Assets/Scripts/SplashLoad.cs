using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    [SerializeField] TextMesh loadText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        loadText.text = "Loading...";
        Invoke("LoadLevelOne", 2);
    }

    private void LoadLevelOne() {
        SceneManager.LoadScene(1);
    }
}
