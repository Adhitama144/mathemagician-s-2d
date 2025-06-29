using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public TextMeshProUGUI questionText;
    public GameObject questionPanel;
    public string question = "2 + 2 = ";
    public string correctAnswer = "4";

    private Player playerScript;
    public bool isInteracting = false;

    void Start()
    {
        playerScript = GameObject.FindObjectOfType<Player>();
        questionPanel.SetActive(false);
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
        if (playerAnswer == correctAnswer)
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
