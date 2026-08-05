using UnityEngine;

public class WinZone : MonoBehaviour
{
    
    public string playerTag = "Player"; 
    public int targetCount = 3;

    public PauseManager pauseManager;

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag(playerTag)) return;

       
        PlayerController playerScript = other.GetComponent<PlayerController>();

        if (playerScript != null)
        {
            
            if (playerScript.count == targetCount)
            {
                TriggerWinState();
            }
        }
    }

    void TriggerWinState()
    {
        

        
        Time.timeScale = 0f;
        pauseManager.GameWin(); 

       
    }
}
