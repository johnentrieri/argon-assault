using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay;
    [SerializeField] GameObject explosion;
    private Renderer rend;

    // Start is called before the first frame update
    void Start() {
        rend = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnTriggerEnter(Collider other) {
        StartDeathSequence();
    }

    private void StartDeathSequence() {
        SendMessage("OnPlayerDeath");
        rend.enabled = false;
        explosion.SetActive(true);
        Invoke("ResetLevel",levelLoadDelay);
    }

    private void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
