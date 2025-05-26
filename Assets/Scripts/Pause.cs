using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void Pausing(){
        Time.timeScale = 0;
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }

    public void Back()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("Pause");
    }
}
