using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;

    static public int score = 0;
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

    static public void CulcScore(int addScore)
    {
        score += addScore;
    }
    
    static public void DecreaseScore(int addScore)
    {
        score -= addScore;
    }
}
