using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource music;
    public float musicStartTime;

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

    public static GameManager instance;

    public GameObject great;
    public GameObject perfect;
    public GameObject hit;
    public GameObject miss;


    public float normalHits;
    public float greatHits;
    public float perfectHits;
    public float missedHits;

    public Text normalsText, greatsText, perfectsText, missesText, rankText, finalscoreText;

    public GameObject resultsScreen;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > musicStartTime && counter == 0)
        {

            music.Play();
            counter++;
        }

        if(Time.fixedTime > music.time + 5 && !resultsScreen.activeInHierarchy)
        {
            resultsScreen.SetActive(true);

            normalsText.text = "" + normalHits;
            greatsText.text = "" + greatHits;
            perfectsText.text = "" + perfectHits;
            missesText.text = "" + missedHits;

            string rankVal = "F";

            if (currentScore >= 1000)
            {
                rankVal = "D";
                rankText.color = Color.gray;
                    if (currentScore >= 2000)
                {
                    rankVal = "C";
                    rankText.color = Color.yellow;
                    if (currentScore >= 3000)
                    {
                        rankVal = "B";
                        rankText.color = Color.blue;
                        if(currentScore >= 4000)
                        {
                            rankVal = "A";
                            rankText.color = Color.red;
                            if(currentScore >= 5000)
                            {
                                rankVal = "S";
                                rankText.color = Color.magenta;
                                if(currentScore >= 6000)
                                {
                                    rankVal = "SS";
                                    rankText.color = Color.cyan;
                                }
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
        Debug.Log("Collision Detected");
        detected = true;
        Debug.Log(detected);

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
}
