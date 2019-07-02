using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode pressKey;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressKey)){
            SR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(pressKey))
        {
            SR.sprite = defaultImage;
        }
    }
}
