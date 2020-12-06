using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform runtimeSpawnParent;
    [SerializeField] int pointValue = 100;

    Scoreboard scoreboard;
    private bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) {
        if (isAlive) {
            ProcessEnemyDeath();
        }
    }

    private void ProcessEnemyDeath() {
        isAlive = false;
        scoreboard.ScoreHit(pointValue);
        Instantiate(explosion,transform.position,Quaternion.identity,runtimeSpawnParent.transform);
        Destroy(gameObject);        
    }
    private void AddNonTriggerBoxCollider() {        
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    
}
