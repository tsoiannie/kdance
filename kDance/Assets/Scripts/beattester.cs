using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beattester : MonoBehaviour
{

    public float tempo;
    public bool start;


     // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Y: "+transform.position.y);
        }

        if (start)
        {
            if (Input.anyKeyDown)
            {
                start = true;
            }
            else
            {
                transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
            }
        }
    }
}
