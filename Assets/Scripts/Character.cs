using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int player;
    public float health; //health of fighter
    public float damageMultiplier; //damage you multiply to character's attacks
    public float rageBar;

    public Vector2 position;
    public Vector2 velocity;

    public bool isFacingRight = true;
    public bool jumped;

    public List<Sprite> sprites;
    public GameObject projectile;
    public enum currentState
    {
        Idle,
        Walk,
        Kick,
        Punch,
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        if (player == 1)
        {
            isFacingRight = true;
            transform.position = new Vector2(-3, -2);
        }
        else if (player == 2)
        {
            isFacingRight = false;
            transform.position = new Vector2(3, -2);
            GetComponent<SpriteRenderer>().flipX = true;
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
            if (position.y <= -2)
            {
                position.y = -2;
                jumped = false;
            }
        }
        transform.position = position;
    }

    void TakeDamage(float damage)
    {
        health -= damage;
    }

    void InputKeys()
    {
        if (player == 1)
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
        else if (player == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow)) //up
            {
                jumped = true;
                position.y += velocity.y;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) //left
            {
                position.x -= velocity.x;
            }
            if (Input.GetKey(KeyCode.RightArrow)) //right
            {
                position.x += velocity.x;
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "punch")
        {
            //Take Damage

        }
        if (collision.gameObject.name == "kick")
        {
            //Take Damage
        }
    }
