using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class okButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    private CursorMode cursormode = CursorMode.Auto;
    public Texture2D activatedCursor;
    public Texture2D defaultCursor;
    public Vector2 hotspot = Vector2.zero;
    private bool isOver = false;
    private Renderer rendering;
    private Color defaultColor = new Color(0.9f, 0.9f, 0.9f);

    // Start is called before the first frame update
    void Start()
    {
        rendering = GetComponent<Renderer>();
        rendering.material.SetColor("_Color", defaultColor);
    }

   public void OnPointerDown(PointerEventData eventData)
    {
        if (isOver)
        {
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        Cursor.SetCursor(activatedCursor, hotspot, cursormode);
        rendering.material.SetColor("_Color", Color.white);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("mouseExits");
        isOver = false;
        Cursor.SetCursor(defaultCursor, hotspot, cursormode);
        rendering.material.SetColor("_Color", defaultColor);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
