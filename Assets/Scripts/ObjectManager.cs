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
    public Text time;
    [SerializeField]
    BoxCollider2D punchCol;
    GameObject playerOne;
    GameObject playerTwo;
    GameObject healthOne;
    GameObject healthTwo;
    GameObject healthBarOne;
    GameObject healthBarTwo;


    // Start is called before the first frame update
    void Start()
    {
        SpawnCharacter();
        SpawnUI();
    }

    // Update is called once per frame
    void Update()
    {
        time.text = time.GetComponent<timerHandle>().timeString;
        FacingRight();
        //healthOne.transform.position = new Vector2(healthOne.transform.position.x + (playerOne.GetComponent<Character>().health - 100) / 100, healthOne.transform.position.y);

        healthOne.transform.position = new Vector2(-5.1f + 7.7f / 100 * (playerOne.GetComponent<Character>().health - 100), healthOne.transform.position.y);
        healthTwo.transform.position = new Vector2(5.1f + 7.7f / 100 * (100 - playerTwo.GetComponent<Character>().health), healthTwo.transform.position.y);
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
        healthBarOne = Instantiate(healthBarPrefab);
        healthBarOne.transform.position = new Vector2(-5.2f, 4);
        healthOne = Instantiate(healthPrefab);
        healthOne.transform.position = new Vector2(-5.2f, 4);
        //health bar two
        healthBarTwo = Instantiate(healthBarPrefab);
        healthBarTwo.transform.position = new Vector2(5.2f, 4);
        healthTwo = Instantiate(healthPrefab);
        healthTwo.transform.position = new Vector2(5.2f, 4);
    }

    void FacingRight()
    {
        if (playerOne.transform.position.x < playerTwo.transform.position.x)
        {
            playerOne.GetComponent<SpriteRenderer>().flipX = false;
            playerOne.GetComponent<Character>().isFacingRight = true;
            playerTwo.GetComponent<SpriteRenderer>().flipX = true;
            playerTwo.GetComponent<Character>().isFacingRight = false;
        }
        else if (playerOne.transform.position.x > playerTwo.transform.position.x)
        {
            playerOne.GetComponent<SpriteRenderer>().flipX = true;
            playerOne.GetComponent<Character>().isFacingRight = false;
            playerTwo.GetComponent<SpriteRenderer>().flipX = false;
            playerTwo.GetComponent<Character>().isFacingRight = true;
        }
    }
}
