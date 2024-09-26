using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 10;
        }
        
        if(Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = 1;
        }
    }
}
