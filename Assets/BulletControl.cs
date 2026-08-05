using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    float speed = 10f;
    private Rigidbody rb;

    void Update()
    {
        rb = GetComponent<Rigidbody>();

     
        rb.velocity = transform.forward * speed;
    }

    public void setSpeed(float speed) { 
        this.speed = speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {


            EnemyController enemyScript = collision.gameObject.GetComponent<EnemyController>();

            enemyScript.takeDamage();

            Debug.Log("Hit Enemy");
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
        Debug.Log(collision.gameObject);
       
    }
}
