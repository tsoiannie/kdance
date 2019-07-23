using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToSong : MonoBehaviour
{
    public Texture2D activatedCursor;
    private CursorMode cursorMode = CursorMode.Auto;
    public Texture2D defaultCursor;
    public Vector2 hotSpot = Vector2.zero;
    private Renderer rending;
    private Color defaultColor = new Color(0.9f, 0.9f, 0.9f);

    public float delayTime = 3.5f;

    public string whichScene;

    // Start is called before the first frame update
    void Start()
    {
        rending = GetComponent<Renderer>();
        rending.material.SetColor("_Color", defaultColor);
    }

    private void OnMouseDown()
    {
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
        SceneManager.LoadScene(whichScene);

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
}
