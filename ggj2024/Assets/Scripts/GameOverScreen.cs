using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
     public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
