using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{   
    public static GameControl instance;
    private SceneFader scenefaderScript;

    public GameObject gameOvercanvas;
    public GameObject mainmenufader;
    public Text coinText, finalcoinText;
    int highcoin;
    public Text HighCoin;
    public float coinCount = 0;
    public GameObject tapToContinue;
    public GameObject flare;
    public GameObject tutCanvas;
    public GameObject playerBird;
    public GameObject scoreText;
    public GameObject videoAdobj;

    private AudioSource source;
    public AudioClip UIclick_sound, buttonCrashSound;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){
            instance = this;
        } else if( instance != null)
        {
            Destroy(gameObject);
        }
       
    }

    void Start(){
        scenefaderScript = GameObject.FindGameObjectWithTag("fader").GetComponent<SceneFader>();
        highcoin = PlayerPrefs.GetInt("HighCoin");
        HighCoin.text = highcoin + ".00";
        source = GetComponent<AudioSource>();
    }
    
    public void Restart(){
        source.clip = UIclick_sound;
        source.Play();
        scenefaderScript.FadeSceneOut();
    }
    public void BirdDied(){
        scoreText.SetActive(false);
        flare.SetActive(false);
        int i = Random.Range(1,4);
        switch (i)
         {
            case 3:
                videoAdobj.SetActive(true);
                break;
         }
        tapToContinue.SetActive(true);
    }
    public void tapContinuePress()
    {   source.clip = buttonCrashSound;
        source.volume = 0.4f;
        source.Play();
        Time.timeScale = 0f;
        gameOvercanvas.SetActive(true);
    }
    public void Home(){
        source.clip = UIclick_sound;
        source.Play();
        mainmenufader.SetActive(true);
    }

    public void coinScore(){
        coinCount += 2;
        coinText.text = "" + coinCount;
        finalcoinText.text = "Coins collected:   	     " + coinCount;
        highcoin += (int)coinCount;
        PlayerPrefs.SetInt("HighCoin", highcoin);
        PlayerPrefs.Save();
        HighCoin.text = highcoin + ".00";
    }

    public void OnClickStart(){
        Destroy(tutCanvas);
        playerBird.SetActive(true);
        scoreText.SetActive(true);
    }
}
