using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject healthPrefab;
    public GameObject healthBarPrefab;
    public Text timePrefab;
    [SerializeField]
    BoxCollider2D punchCol;
    GameObject playerOne;
    GameObject playerTwo;
    GameObject healthOne;
    GameObject healthTwo;
    GameObject healthBarOne;
    GameObject healthBarTwo;
    Text time;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter();
        SpawnUI();
    }

    // Update is called once per frame
    void Update()
    {
        playerOne.GetComponent<Character>().health -= 1;

        healthOne.transform.localScale = new Vector2(playerOne.GetComponent<Character>().health / 100, healthOne.transform.localScale.y); //change x later to change health
        //healthOne.transform.position = new Vector2(healthOne.transform.position.x - .01f, healthOne.transform.position.y);
        healthTwo.transform.localScale = new Vector2(playerTwo.GetComponent<Character>().health / 100, healthTwo.transform.localScale.y);
        time.text = time.GetComponent<timerHandle>().timeString;
    }

    void SpawnCharacter()
    {
        playerOne = Instantiate(playerOnePrefab);
        playerOne.GetComponent<Character>().player = 1;
        playerTwo = Instantiate(playerTwoPrefab);
        playerTwo.GetComponent<Character>().player = 2;
    }

    void SpawnCharacter(GameObject playerOnePrefab, GameObject playerTwoPrefab) //override
    {
        playerOne = Instantiate(playerOnePrefab);
        playerOne.GetComponent<Character>().player = 1;
        playerTwo = Instantiate(playerTwoPrefab);
        playerTwo.GetComponent<Character>().player = 2;
    }

    void SpawnUI()
    {
        //health bar one
        healthOne = Instantiate(healthPrefab);
        healthOne.transform.position = new Vector2(-6, 4);
        healthBarOne = Instantiate(healthBarPrefab);
        healthBarOne.transform.position = new Vector2(-6, 4);
        //health bar two
        healthTwo = Instantiate(healthPrefab);
        healthTwo.transform.position = new Vector2(6, 4);
        healthBarTwo = Instantiate(healthBarPrefab);
        healthBarTwo.transform.position = new Vector2(6, 4);
        //time
        time = Instantiate(timePrefab);
        time.transform.position = new Vector2(2, 0);
        time.text = "99";
    }
}
