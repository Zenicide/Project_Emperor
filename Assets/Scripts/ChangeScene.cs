using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Windows.Input;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
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
        
        // Testing uses of escape
        if (Input.GetKeyDown("escape"))
        {

            switch (index)
            {
                case 0:
                    Application.Quit();
                    break;
                case 3:
                    SceneManager.LoadScene(4);
                    break;
                case 4:
                    SceneManager.LoadScene(3);
                    break;

            }
        }
        

        
    }
}
