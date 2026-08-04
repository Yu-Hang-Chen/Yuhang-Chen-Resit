using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObjectCollide : MonoBehaviour
{

    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            CollectedByPlayer();
            
        }
       
    } 

    void CollectedByPlayer(){

        Destroy(this.gameObject);
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);


    }
}
