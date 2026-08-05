using UnityEngine;

public class Teleporter : MonoBehaviour
{
    
    public Teleporter targetTeleporter; 
    public float cooldown = 2f;         

    private bool isCooldown = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;

        
        if (isCooldown || targetTeleporter == null) return;

        
        TeleportPlayer(other.transform);

        
        StartCoroutine(CooldownRoutine());
    }

    void TeleportPlayer(Transform playerTransform)
    {
        Vector3 targetPos = targetTeleporter.transform.position;

        targetPos.y = playerTransform.position.y; 

        playerTransform.position = targetPos + targetTeleporter.transform.forward * 2f;

    }

    System.Collections.IEnumerator CooldownRoutine()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
    }
}
