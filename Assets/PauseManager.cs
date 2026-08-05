using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseManager : MonoBehaviour
{
   
    public GameObject pauseMenuUI;
    public GameObject winMenuUI;

    private bool isPaused = false;

    void Start()
    {
       
        Time.timeScale = 1f;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 
        pauseMenuUI.SetActive(true); 
    }

  
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 
        pauseMenuUI.SetActive(false);
        Debug.Log("Resume Clicked");
    }

  
    public void RestartGame()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart Clicked");
    }


    public void QuitGame()
    {
      
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameWin()
    {
        isPaused = true;
        Time.timeScale = 0f;
        winMenuUI.SetActive(true); 
    }

}
