using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _healthText, _currentScoreText, _highScoreText;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private GameObject _mobileControls;

    public void UpdateHealth(int health)
    {
        _healthText.text = "Health: " + health;
    }

    public void UpdateScore(int points)
    {
        _currentScoreText.text = "Score: " + points;
    }

    public void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", -1);
        if (highScore != -1)
            _highScoreText.text = "High Score: " + highScore;
        else
            _highScoreText.text = "";
    }

    public void ShowGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    public void OnRestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Asteroids");
    }

    public void OnExitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }


    public void ActivateMobileControls(bool activate)
    {

        _mobileControls.SetActive(activate);
    }

}
