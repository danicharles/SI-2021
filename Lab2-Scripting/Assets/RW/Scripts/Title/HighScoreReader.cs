using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreReader : MonoBehaviour
{
    public static HighScoreReader Instance;

    public Text highScoreText;

    private void Awake()
    {
        Instance = this;
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = HighScore.highScore.ToString();
    }

}
