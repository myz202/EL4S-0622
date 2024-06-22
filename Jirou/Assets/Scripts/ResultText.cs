using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "îÑÇËè„Ç∞  " + Score.score.ToString("N0") + "íõâ~";
    }
}
