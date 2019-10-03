using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{   public Text distanceText, finalDistanceText;
    int highscore;
    public Text HighScore;
    public Text LevelText;
    public float scoreCount;
    public bool scoreIncreasing;
    float pointsPerSec;
     public Transform target;
    // Update is called once per frame
    void Start(){
        scoreIncreasing = true;
        highscore = PlayerPrefs.GetInt("HighScore");
        HighScore.text =  highscore + "m";
    }
    void Update()
    {   if (scoreIncreasing)
        {   pointsPerSec = Random.Range(2,6);
            scoreCount += pointsPerSec * Time.deltaTime;
        }
        distanceText.text = Mathf.Round(scoreCount) + "m";
        if(scoreCount > highscore){
            highscore = (int)scoreCount;
            HighScore.text =  highscore + "m";
            PlayerPrefs.SetInt("HighScore", highscore);
            PlayerPrefs.Save();
        }

        if(target == null){
            scoreIncreasing = false;
            finalDistanceText.text = "Distance travelled: 	 " + Mathf.Round(scoreCount);
            int x = (highscore / 40);
            LevelText.text = "Level " + x;
        }
    }
}
