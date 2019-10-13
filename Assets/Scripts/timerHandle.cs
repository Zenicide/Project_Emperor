using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows;
using UnityEngine.SceneManagement;

public class timerHandle : MonoBehaviour
{
    // set time and allow for it to be seen in a label
    public int time;
    public string timeString;
    int frames;
    // Start is called before the first frame update
    void Start()
    {
        time = 99;
        frames = 60;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 0)
        {
            SceneManager.LoadScene(5);
        }
        else // tick down time using frames, preferably 60 fps
        {
            frames--;
            if (frames == 0)
            {
                time--;
                frames = 60;
            }
        }
        timeString = time.ToString();
    }

    
}
