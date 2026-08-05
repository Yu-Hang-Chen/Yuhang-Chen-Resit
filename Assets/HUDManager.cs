using UnityEngine;
using TMPro; 

public class HUDManager : MonoBehaviour
{

    public TextMeshProUGUI infoText; 

 
    public GameObject playerObject;  
    private PlayerController playerScript; 

    void Start()
    {
       
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<PlayerController>();
        }

      
        UpdateText();
    }

    void Update()
    {
        if (playerScript != null && infoText != null)
        {
            UpdateText();
        }
    }

    void UpdateText()
    {
        
        string content = "Collect Orange Power Cell\nDestroy Red Enemy\nTeleport on blue plane\nTouch Green Tower When Done";
        int currentCount = playerScript.count;

        infoText.text = $"GamePlay: {content}\n\n\n  CurrentCount: {currentCount}";
    }
}
