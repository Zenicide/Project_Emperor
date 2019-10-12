using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public string player; //tracks if player one or two, ex "one" or "two"
    public string leftOrRight; //tracks if player is facing left or right.

    public float health; //health of fighter
    public float damageMultiplier; //damage you multiply to character's attacks
    public float rageBar;
    public Slider rageSlider; 

    public Vector2 position;
    public Vector2 velocity;

    public bool jumped;

    public List<Sprite> sprites;
    public enum currentState
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (player == "one")
        {
            leftOrRight = "right";
            transform.position = new Vector2(0, 0);
        }
        else if (player == "two")
        {
            leftOrRight = "left";
        }
        position = transform.position;
        velocity = new Vector2(.1f, 1.2f); //change values to change speed

        jumped = false;

    }

    // Update is called once per frame
    void Update()
    {
        InputKeys();
        if (jumped == true)
        {
            position.y -= Time.deltaTime * 3;
            if (position.y <= 0)
            {
                position.y = 0;
                jumped = false;
            }
        }
        transform.position = position;
    }

    void InputKeys()
    {
        if (player == "one")
        {
            if (Input.GetKey(KeyCode.W) && jumped == false) //up
            {
                jumped = true;
                position.y += velocity.y;
            }
            if (Input.GetKey(KeyCode.A)) //left
            {
                position.x -= velocity.x;
            }
            if (Input.GetKey(KeyCode.D)) //right
            {
                position.x += velocity.x;
            }
            if (Input.GetKey(KeyCode.J))
            {

            }
            if (Input.GetKey(KeyCode.K))
            {

            }
            if (Input.GetKey(KeyCode.L))
            {

            }
        }
        else if (player == "two")
        {
            if (Input.GetKey(KeyCode.UpArrow)) //up
            {
                position.y += velocity.y;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) //left
            {
                position.x -= velocity.x;
            }
            if (Input.GetKey(KeyCode.RightArrow)) //right
            {
                position.x += -velocity.x;
            }
            if (Input.GetKey(KeyCode.Keypad1))
            {

            }
            if (Input.GetKey(KeyCode.Keypad2))
            {

            }
            if (Input.GetKey(KeyCode.Keypad3))
            {

            }
        }
    }
}
