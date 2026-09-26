using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public TMP_Text pauseText;

    private int score = 0;
    public bool gameOver = false;
    public bool paused = false;

    void Awake()
    {
        Instance = this;
        scoreText.text = "Puntos: 0";
        gameOverText.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Pausar / reanudar con ESC
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (gameOver) return;

            paused = !paused;

            if (paused)
            {
                Time.timeScale = 0;
                pauseText.gameObject.SetActive(true);
            }
            else
            {
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
            }
        }

        // Reiniciar con R
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddScore(int points)
    {
        if (gameOver) return;
        score += points;
        scoreText.text = "Puntos: " + score;
    }

    public void Lose()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}