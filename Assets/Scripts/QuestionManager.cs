using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class QuestionManager : MonoBehaviour
{
    public Enemy[] enemies;
    public TMP_InputField answerInput;
    private Player playerScript;

    public void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
    }

    public void OnSubmitAnswer()
    {
        string playerAnswer = "";

        if (answerInput != null)
        {
            playerAnswer = answerInput.text;
        }
        else
        {
            Debug.LogError("Answer Input Field is not assigned.");
        }

        if (enemies != null && enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                if (enemy != null && enemy.isInteracting == true)
                {
                    enemy.AnswerQuestion(playerAnswer);
                    CheckAllEnemiesDead();
                    answerInput.text = "";
                }
            }
        }
        else
        {
            Debug.LogError("Enemies array is empty or not assigned.");
        }
    }

 public void ShowInputField()
{
    if (answerInput != null)
    {
        answerInput.gameObject.SetActive(true);
        answerInput.text = "";

        StartCoroutine(FocusInput());
    }
}

private IEnumerator FocusInput()
{
    yield return null;
    Debug.Log("Focusing input field...");
    answerInput.Select();
    answerInput.ActivateInputField();
}



    void CheckAllEnemiesDead()
    {
        if (playerScript.health <= 0)
        { return; }
        
        bool allEnemiesDead = true;

        foreach (var enemy in enemies)
        {
            if (enemy != null && enemy.isActiveAndEnabled)
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            Progress progress = new Progress();
            string sceneName = SceneManager.GetActiveScene().name;
            string[] parts = sceneName.Split('-');
            int levelNumber = 1;

            if (parts.Length > 1) int.TryParse(parts[1], out levelNumber);

            progress.SimpanProgress(levelNumber + 1);
            SceneManager.LoadScene("Win", LoadSceneMode.Additive);
        }
    }
}
