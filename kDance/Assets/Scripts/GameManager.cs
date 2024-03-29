﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public float musicStartTime;
    public float musicEndTime;

    public bool startPlaying;

    public BeatScroller bs;

    public bool detected;

    public int currentScore;
    public int scorePerNote = 10;
    public int scorePerGoodNote = 25;
    public int scorePerPerfectNote = 50;

    public Text scoreText;
    public Text multiText;
    int counter = 0;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThreshold;

    //rank numbers
    public int dRank;
    public int cRank;
    public int bRank;
    public int aRank;
    public int sRank;

    public static GameManager instance;

    public GameObject great;
    public GameObject perfect;
    public GameObject hit;
    public GameObject miss;


    public float normalHits;
    public float greatHits;
    public float perfectHits;
    public float missedHits;
    bool startingFade;

    public Text normalsText, greatsText, perfectsText, missesText, rankText, finalscoreText;

    public GameObject resultsScreen;

    // Start is called before the first frame update
    void Start()
    {

        int width = 1920; // or something else
        int height= 1080; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else
        startingFade = false;

        Screen.SetResolution (width , height, isFullScreen, desiredFPS );

        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;


    }

    // Update is called once per frame
    void Update()
    {

        //add 5 to musicEndTime
        if(Time.timeSinceLevelLoad > musicEndTime-5 && startingFade == false)
        {
            startingFade = true;
            StartCoroutine(FadeOut(music, 5f));
        }
        if (Time.timeSinceLevelLoad > musicStartTime && counter == 0)
        {

            music.Play();
            counter++;
        }

        if(Time.timeSinceLevelLoad + 3.5 > musicEndTime + 5 && !resultsScreen.activeInHierarchy)
        {
            resultsScreen.SetActive(true);

            normalsText.text = "" + normalHits;
            greatsText.text = "" + greatHits;
            perfectsText.text = "" + perfectHits;
            missesText.text = "" + missedHits;

            string rankVal = "F";
            rankText.color = Color.white;

            if (currentScore >= dRank)
            {
                rankVal = "D";
                rankText.color = Color.gray;
                    if (currentScore >= cRank)
                {
                    rankVal = "C";
                    rankText.color = Color.yellow;
                    if (currentScore >= bRank)
                    {
                        rankVal = "B";
                        rankText.color = Color.blue;
                        if(currentScore >= aRank)
                        {
                            rankVal = "A";
                            rankText.color = Color.red;
                            if(currentScore >= sRank)
                            {
                                rankVal = "S";
                                rankText.color = Color.magenta;
                            }
                        }
                    }
                }
            }

            rankText.text = rankVal;
            finalscoreText.text = currentScore.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider1)
    {

        detected = true;


    }

    public void NoteHit()
    {
        if (currentMultiplier - 1 < multiplierThreshold.Length)
        {


            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        multiText.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;



    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        Instantiate(hit, new Vector2(3, 8), Quaternion.identity);
        normalHits++;

    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        Instantiate(great, new Vector2(3, 5), Quaternion.identity);
        greatHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        Instantiate(perfect, new Vector2(3, 2), Quaternion.identity);
        perfectHits++;
    }

    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        Instantiate(miss, new Vector2(3, -1), Quaternion.identity);
        missedHits++;
    }

    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {

        float startVolume = audioSource.volume;
 
        while (audioSource.volume > 0) {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
 
            yield return null;
        }
 

        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
}
