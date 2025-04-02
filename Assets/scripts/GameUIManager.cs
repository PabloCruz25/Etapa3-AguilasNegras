using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI messageText;
    public Button restartButton;

    private int score = 0;
    private int round = 1;

    void Start()
    {
        UpdateUI();
        restartButton.onClick.AddListener(RestartGame);
        messageText.text = "";
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void NextRound()
    {
        round++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Puntuación: " + score;
        roundText.text = "Ronda: " + round;
    }

    public void ShowMessage(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color;
        Invoke("ClearMessage", 2f); // Borra el mensaje después de 2 segundos
    }

    private void ClearMessage()
    {
        messageText.text = "";
    }

    private void RestartGame()
    {
        score = 0;
        round = 1;
        UpdateUI();
        messageText.text = "";
    }
}
