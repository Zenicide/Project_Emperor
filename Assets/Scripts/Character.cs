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

    // Start is called before the first frame update
    void Start()
    {
        if (player == "one")
        {
            leftOrRight = "right";
        }
        else if (player == "two")
        {
            leftOrRight = "left";
        }
        position = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        InputKeys();
    }

    void InputKeys()
    {
        if (player == "one")
        {
            if (Input.GetKey(KeyCode.W))
            {

            }
            if (Input.GetKey(KeyCode.A))
            {

            }
            if (Input.GetKey(KeyCode.S))
            {

            }
            if (Input.GetKey(KeyCode.D))
            {

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
            if (Input.GetKey(KeyCode.UpArrow))
            {

            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {

            }
            if (Input.GetKey(KeyCode.RightArrow))
            {

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
