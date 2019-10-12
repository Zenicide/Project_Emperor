using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen_menu_selector : MonoBehaviour
{
    const int totalOptions = 4;
    int currentOptionsIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentOptionsIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentOptionsIndex++;
            if (currentOptionsIndex == totalOptions)
            {
                currentOptionsIndex = 0;
                gameObject.transform.Translate(new Vector3(0, (totalOptions - 1) * 0.5f, 0));
            }
            else
            {
                gameObject.transform.Translate(new Vector3(0, -0.5f, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            if(currentOptionsIndex == 0)
            {
                currentOptionsIndex = totalOptions;
                gameObject.transform.Translate(new Vector3(0, (totalOptions - 1) * -0.5f, 0));
            }
            else
            {
                gameObject.transform.Translate(new Vector3(0, 0.5f, 0));
            }
            currentOptionsIndex--;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(currentOptionsIndex == 0)
            {
                //load the gameplay screen
                SceneManager.LoadScene(1);
            }else if(currentOptionsIndex == 1)
            {
                //loads the practice mode
                SceneManager.LoadScene(2);
            }
            else if(currentOptionsIndex == 2)
            {
                //load the instructions screen
                SceneManager.LoadScene(3);
            }
            else
            {
                //closes the game
                Application.Quit();
            }
        }
    }
}
