using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunController : MonoBehaviour
{

    public int BulletCount = 100;
    public Transform shootingStart;
    public BulletControl bulletControl;
    public float bulletSpeed = 35;

    public float shootCoolDown = 100; // ms
    public float reloadDing = 1000; // ms

    public float nextShotTime;    

    public void Shoot() {
        if (Time.time > nextShotTime) {
            nextShotTime = Time.time + shootCoolDown / 1000;
            BulletControl bullete = Instantiate(bulletControl, shootingStart.position, shootingStart.rotation) as BulletControl;
            bullete.setSpeed(bulletSpeed);

            Destroy(bullete, 8);
        }
    }
}
