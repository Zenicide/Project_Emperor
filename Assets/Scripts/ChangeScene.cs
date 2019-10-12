using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    const int totalScenes = 7;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown("c"))
        {
            
            SceneManager.LoadScene(index + 1);
            index++;
        }
        if (index != 0)
        {
            if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene(4);
            }
        }
        

        if (index == 0) {

            

            if (Input.GetKeyDown("escape"))
            {
                Application.Quit();
            }
        }

        if (index == 4)
        {
            if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
