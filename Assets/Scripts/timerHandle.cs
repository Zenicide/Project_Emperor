using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerHandle : MonoBehaviour
{

    public double time = 90;
    public int displayTime = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (time >= 0) {
            time -= 0.01;
        }

        if (time % 1 == 0)
        {
            displayTime = (int)time;
        }
    }
}
