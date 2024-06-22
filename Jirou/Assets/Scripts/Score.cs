using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    static private int score = 0;
    private int addScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "—˜‰v:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "—˜‰v:" + score;
    }

    void CulcScore()
    {
        addScore = 0;
        score += addScore;
        addScore = 0;
    }
    
    void DescreaseScore()
    {
        addScore = 0;
        score -= addScore;
        addScore = 0;
    }
}
