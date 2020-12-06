using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int pointValue = 100;
    [SerializeField] int maxHealth = 1;

    [Header("Visual Effects")]
    [SerializeField] GameObject explosion;

    [Header("Development")]
    [SerializeField] Transform runtimeSpawnParent;


    Scoreboard scoreboard;
    private bool isAlive;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) {
        ProcessEnemyDamage();
    }

    void ProcessEnemyDamage() {
        if ( --health <= 0) {
            ProcessEnemyDeath();
        }
    }

    private void ProcessEnemyDeath() {
        if (!isAlive) { return; }
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
