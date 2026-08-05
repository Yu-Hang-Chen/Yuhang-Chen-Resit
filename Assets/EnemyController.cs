using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float chaseRange = 10f;
    private NavMeshAgent agent;
    private Transform playerTransform;
    public GameObject DeadEffect;
    private float pushForce = 2f;       
    private float upwardForce = 1f;
    private int damage = 10;

    public int currentHeath = 100;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance <= chaseRange)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized;

                Vector3 forceVector = direction * pushForce + Vector3.up * upwardForce;

                playerRb.AddForce(forceVector, ForceMode.Impulse);

            }

            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();

            playerScript.takeDamage(damage);
        }
    }

    public void takeDamage() {

        currentHeath -= 50;
        if (currentHeath <= 0) {
            Dead();
        }
    }

    private void Dead() {

        Debug.Log("Enemy Dead");
        Destroy(Instantiate(DeadEffect, transform.position, DeadEffect.gameObject.transform.rotation), 2);
        Destroy(gameObject);
    }


}
