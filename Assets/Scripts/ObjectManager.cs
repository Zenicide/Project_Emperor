using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;
    public GameObject healthPrefab;
    public GameObject healthBarPrefab;
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
        SpawnHealthBars();
    }

    // Update is called once per frame
    void Update()
    {
        healthOne.transform.localScale = new Vector2(healthOne.transform.localScale.x, healthOne.transform.localScale.y); //change x later to change health
        healthTwo.transform.localScale = new Vector2(healthTwo.transform.localScale.x, healthTwo.transform.localScale.y);
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

    void SpawnHealthBars()
    {
        healthOne = Instantiate(healthPrefab);
        healthOne.transform.position = new Vector2(-6, 4);
        healthBarOne = Instantiate(healthBarPrefab);
        healthBarOne.transform.position = new Vector2(-6, 4);

        healthTwo = Instantiate(healthPrefab);
        healthTwo.transform.position = new Vector2(6, 4);
        healthBarTwo = Instantiate(healthBarPrefab);
        healthBarTwo.transform.position = new Vector2(6, 4);
    }
}
