using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    bool leftOf;


    // Start is called before the first frame update
    void Start()
    {
        leftOf = true;
        SpawnCharacter();
        SpawnUI();
    }

    // Update is called once per frame
    void Update()
    {
        time.text = time.GetComponent<timerHandle>().timeString;
        FacingRight();

        healthOne.transform.position = new Vector2(-5.1f + 7.7f / 100 * (playerOne.GetComponent<Character>().health - 100), healthOne.transform.position.y);
        healthTwo.transform.position = new Vector2(5.1f + 7.7f / 100 * (100 - playerTwo.GetComponent<Character>().health), healthTwo.transform.position.y);
        if (playerOne.GetComponent<Character>().health <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (playerTwo.GetComponent<Character>().health <= 0)
        {
            SceneManager.LoadScene(4);
        }
        if (playerOne.GetComponent<Character>().health < playerTwo.GetComponent<Character>().health && time.GetComponent<timerHandle>().time <= 0)
        {
            SceneManager.LoadScene(5);
        }
        if (playerOne.GetComponent<Character>().health > playerTwo.GetComponent<Character>().health && time.GetComponent<timerHandle>().time <= 0)
        {
            SceneManager.LoadScene(4);
        }
        if (playerOne.GetComponent<Character>().health == playerTwo.GetComponent<Character>().health && time.GetComponent<timerHandle>().time <= 0)
        {
            int randomWinner = Random.Range(4, 6);
            SceneManager.LoadScene(randomWinner);
        }
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
        if (playerOne.transform.position.x < playerTwo.transform.position.x && !leftOf)
        {
            leftOf = true;
            //playerOne.GetComponent<SpriteRenderer>().flipX = false;
            playerOne.GetComponent<Character>().isFacingRight = true;
            playerOne.transform.localScale *= new Vector2(-1, 1);
            //playerTwo.GetComponent<SpriteRenderer>().flipX = true;
            playerTwo.transform.localScale *= new Vector2(-1, 1);
            playerTwo.GetComponent<Character>().isFacingRight = false;
        }
        else if (playerOne.transform.position.x > playerTwo.transform.position.x && leftOf)
        {
            leftOf = false;
            //playerOne.GetComponent<SpriteRenderer>().flipX = true;
            playerOne.transform.localScale *= new Vector2(-1, 1);
            playerOne.GetComponent<Character>().isFacingRight = false;
            //playerTwo.GetComponent<SpriteRenderer>().flipX = false;
            playerTwo.transform.localScale *= new Vector2(-1, 1);
            playerTwo.GetComponent<Character>().isFacingRight = true;
        }
    }
}
