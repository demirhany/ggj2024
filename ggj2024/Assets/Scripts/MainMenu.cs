using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("application has quit");
    }
}
