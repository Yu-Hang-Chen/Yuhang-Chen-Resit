using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    float speed = 10f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.forward * speed * Time.deltaTime);
    }

    public void setSpeed(float speed) { 
        this.speed = speed;
    }
}
