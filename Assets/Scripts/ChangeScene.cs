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
        
        
        // Testing uses of escape
        if (Input.GetKeyDown("escape"))
        {

            switch (index)
            {

                // If in the title screen, quit
                case 0:
                    Application.Quit();
                    break;

                // If in play scene,

                // Play screen to pause screen
                case 1:
                    SceneManager.LoadScene(4);
                    break;
                    // Practice screen to title screen
                case 2:
                    SceneManager.LoadScene(0);
                    break;
                    // Instructions to title screen
                case 3:
                    SceneManager.LoadScene(0);
                    break;

                    // Pause to play screen
                case 4:
                    SceneManager.LoadScene(1);
                    break;

            }
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 5)
            {
                SceneManager.LoadScene(0);
            }
        }
        
    }
}
