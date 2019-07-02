using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class great_script : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime > timer + 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
