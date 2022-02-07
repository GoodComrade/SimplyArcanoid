using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    [SerializeField]
    Text gameCubeScoreText;
    [SerializeField]
    Text redBorderScoreText;

    int gameCubeScore = 0;
    int redBorderScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameCubeScoreText.text = gameCubeScore++.ToString();
        redBorderScoreText.text = redBorderScore++.ToString();
    }


    public void AddGameCubeScore()
    {
        gameCubeScoreText.text = gameCubeScore++.ToString();
    }

    public void AddRedBorderScore()
    {
        redBorderScoreText.text = redBorderScore++.ToString();
    }
}
