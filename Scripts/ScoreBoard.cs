using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text scoreText;
    int score;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        scoreText.text = "Score: " + score.ToString();
    }
}
