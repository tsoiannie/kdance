using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowEnter : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode keyPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (transform.position.y >= 10.7 && transform.position.y < 11.2)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();

                }
                else if (transform.position.y >= 11.2 && transform.position.y < 11.9)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                }
                else if (transform.position.y >= 11.9 && transform.position.y < 12.4)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();

                }
                else
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = true;
            Debug.Log("ACTIVATOR IS TURNING TRUE");
        }

        if (collision.tag == "miss")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }

}
