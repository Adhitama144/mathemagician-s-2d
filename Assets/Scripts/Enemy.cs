using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public TextMeshProUGUI questionText;
    public GameObject questionPanel;
    public string question = "";
    public string correctAnswer = "";

    public RandomQuestion randomQuestion;

    private Player playerScript;
    public bool isInteracting = false;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        questionPanel.SetActive(false);

        if (randomQuestion != null)
        {
            var qa = randomQuestion.GetRandomQuestionAndAnswer();
            question = qa.question;
            correctAnswer = qa.answer;
        }
        else
        {
            Debug.LogError("RandomQuestion reference not set on Enemy!");
        }
    }

    public void AttackPlayer()
    {
        isInteracting = true;
        questionPanel.SetActive(true);
        questionText.text = question;
        Time.timeScale = 0;

        // Aktifkan input field dan munculkan keyboard
        QuestionManager qm = GameObject.FindObjectOfType<QuestionManager>();
        if (qm != null)
        {
            qm.ShowInputField();
        }
        else
        {
            Debug.LogError("QuestionManager not found in scene.");
        }
    }

    public void AnswerQuestion(string playerAnswer)
    {
        string cleanPlayer = playerAnswer.Trim().ToLower().Replace("cm", "").Trim();
        string cleanCorrect = correctAnswer.Trim().ToLower().Replace("cm", "").Trim();

        if (cleanPlayer == cleanCorrect)
        {
            SceneManager.LoadScene("Killing", LoadSceneMode.Additive);
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("Hit", LoadSceneMode.Additive);
            playerScript.TakeDamage(1);
            Destroy(gameObject);
        }

        questionPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
