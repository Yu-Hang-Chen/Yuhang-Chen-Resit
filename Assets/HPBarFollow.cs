using UnityEngine;
using UnityEngine.UI;

public class HPBarFollow : MonoBehaviour
{
    public Transform target;          
    public Vector3 offset = new Vector3(0, -10f, 0); 

    public Image fillImage;           
    public float maxHealth = 100f;   

    private Camera mainCamera;
    private RectTransform rectTransform;

    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();

        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) target = player.transform;
        }
    }

    

  
    public void SetHealth(float currentHealth)
    {
        if (fillImage == null) return;

        float percent = Mathf.Clamp01(currentHealth / maxHealth);
        fillImage.fillAmount = percent;

        if (percent < 0.3f)
            fillImage.color = Color.red;
        else if (percent < 0.6f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.green;
    }
}
