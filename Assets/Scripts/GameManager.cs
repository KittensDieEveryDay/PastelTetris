using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text finalScore;
    public static int score = 0;
    public GameObject gameOverCanvas;
    AudioSource audioSource;
    public AudioClip gameOverSound;
    public AudioClip clearRowSound;
    public GameObject gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void GameOver()
    {
        //audioSource.PlayOneShot(gameOverSound);
        //PlayerPrefs.SetString("Your score: ", scoreText.text);
        //SceneManager.LoadScene("GameOverScene");
        //SceneManager.LoadScene("GameOverScene");
        //DestroyTetros("Tetromino");
        //gameOverCanvas.SetActive(true);
        //gameCanvas.SetActive(false);
        //finalScore.text = "Your score: " + score;

        Invoke("gameIsLiterallyOver", 2.0f);
    }

    void DestroyTetros(string tagName)
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag(tagName);
        foreach (GameObject prefab in prefabs)
        {
            Destroy(prefab);
        }
    }

    public void IncreaseScore()
    {
        score += 1;
        scoreText.text = "Score: " + score;
        audioSource.PlayOneShot(clearRowSound);
    }

    public void FinalScore()
    {
        scoreText.text = "Your score: " + score;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void gameIsLiterallyOver()
    {
        audioSource.PlayOneShot(gameOverSound);
        PlayerPrefs.SetString("Your score: ", scoreText.text);
        SceneManager.LoadScene("GameOverScene");
    }
}
