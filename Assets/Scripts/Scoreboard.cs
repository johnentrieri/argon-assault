using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;    
    [SerializeField] int scorePerHit = 100;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit() {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
