using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] Transform runtimeSpawnParent;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) {        
        Instantiate(explosion,transform.position,Quaternion.identity,runtimeSpawnParent.transform);
        Destroy(gameObject);
    }

    private void AddNonTriggerBoxCollider() {        
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
}
