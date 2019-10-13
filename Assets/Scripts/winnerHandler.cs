using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class winnerHandler : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    Character Player1Char;
    Character Player2Char;
    public Text time;

    // Start is called before the first frame update
    void Start()
    {
        Player1Char = Player1.GetComponent<Character>();
        Player2Char = Player2.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Char.health <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (Player2Char.health <= 0)
        {
            SceneManager.LoadScene(4);
        }
        if (Player1Char.health < Player2Char.health && time.GetComponent<timerHandle>().time <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (Player1Char.health > Player2Char.health && time.GetComponent<timerHandle>().time <= 0)
        {
            SceneManager.LoadScene(4);
        }
        if (Player1Char.health == Player2Char.health && time.GetComponent<timerHandle>().time <= 0)
        {
            int randomWinner = Random.Range(4, 6);
            SceneManager.LoadScene(randomWinner);
        }
    }
}
