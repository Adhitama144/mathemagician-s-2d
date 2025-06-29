using UnityEngine;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator enemyAnimator;

    public Animator kabut;

    private string HitingSceneName = "Hit";

    void Start()
    {
        StartCoroutine(PlayKillSequence());
    }

    private System.Collections.IEnumerator PlayKillSequence()
    {
        kabut.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        enemyAnimator.SetInteger("state", 2);
        yield return new WaitForSeconds(1f);
        enemyAnimator.SetInteger("state", 0);

        playerAnimator.SetInteger("state", 4);
        yield return new WaitForSeconds(0.3f);
        playerAnimator.SetInteger("state", 0);

        kabut.gameObject.SetActive(true);
        enemyAnimator.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        kabut.gameObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        SceneManager.UnloadSceneAsync(HitingSceneName);
    }
}