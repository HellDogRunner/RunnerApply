using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionService : MonoBehaviour
{
    public void SwichToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
