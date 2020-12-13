using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    private void Awake()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", -1);
        if (highScore == -1)
        {
            _highScoreText.text = "Play to achieve an score!";
        }
        else
        {
            _highScoreText.text = "High Score: " + highScore;
        }
    }

    public void OnPlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Asteroids");
    }
}
