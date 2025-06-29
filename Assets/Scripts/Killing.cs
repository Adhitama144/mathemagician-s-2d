using UnityEngine;
using UnityEngine.SceneManagement;

public class Killing : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator enemyAnimator;

    private string killingSceneName = "Killing";

    void Start()
    {
        StartCoroutine(PlayKillSequence());
    }

    private System.Collections.IEnumerator PlayKillSequence()
    {
        yield return new WaitForSeconds(1f);

        playerAnimator.SetInteger("state", 2);
        yield return new WaitForSeconds(1f);

        enemyAnimator.SetInteger("state", 3);
        yield return new WaitForSeconds(0.7f);

        SceneManager.UnloadSceneAsync(killingSceneName);
    }
}