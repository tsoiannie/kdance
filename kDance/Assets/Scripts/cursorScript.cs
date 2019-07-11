using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorScript : MonoBehaviour
{

    public Texture2D activatedCursor;
    private CursorMode cursorMode = CursorMode.Auto;
    public Texture2D defaultCursor;
    public Vector2 hotSpot = Vector2.zero;
    private Renderer rending;
    private Color defaultColor = new Color(0.9f, 0.9f, 0.9f);

    public GameObject gameTitle;
    public GameObject buttons;
    public GameObject spectrum;
    public GameObject part2;
    public GameObject rain;

    void Start()
    {
        rending = GetComponent<Renderer>();
        rending.material.SetColor("_Color", defaultColor);

    }

    private void OnMouseDown()
    {
        gameTitle.SetActive(false);
        buttons.SetActive(false);
        spectrum.SetActive(false);
        part2.SetActive(true);
        rain.SetActive(false);
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(activatedCursor, hotSpot, cursorMode);
        rending.material.SetColor("_Color", Color.white);

    }

    void OnMouseExit()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
        rending.material.SetColor("_Color", defaultColor);



    }
    // Start is called before the first frame update



}
