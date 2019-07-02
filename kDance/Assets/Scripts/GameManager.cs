using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource music;

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
        if (Time.fixedTime > 1f && counter == 0)
        {
            Debug.Log("HERE TIME AFTER ONE SECOND");
            music.Play();
            counter++;
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

        Instantiate(hit, new Vector2(3, 8), Quaternion.identity);

    }


    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        Instantiate(great, new Vector2(3, 5), Quaternion.identity);
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        Instantiate(perfect, new Vector2(3, 2), Quaternion.identity);
    }

    public void NoteMissed()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        Instantiate(miss, new Vector2(3, -1), Quaternion.identity);
    }
}
