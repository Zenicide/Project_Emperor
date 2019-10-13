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

    public GameObject projectile;

    public BoxCollider2D punchCollider;
    public BoxCollider2D kickCollider;
    BoxCollider2D projCollider;

    //internal cooldown timer so they can't do the same action again
    const int resetCooldownTimer = 4;
    int player1PunchTimer;
    int player1KickTimer;
    int player1ProjTimer;
    bool player1ProjAnim = false;

    int player2PunchTimer;
    int player2KickTimer;
    int player2ProjTimer;
    bool player2ProjAnim = false;

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

        //setting timers for each action
        player1PunchTimer = 4;
        player1KickTimer = 4;
        player1ProjTimer = 4;

        player2PunchTimer = 4;
        player2KickTimer = 4;
        player2ProjTimer = 4;

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

    void InputKeys()
    {
        if (player == 1)
        {
            if (Input.GetKey(KeyCode.W) && !jumped) //up
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

            //detects if the player is trying to punch and the player is able to punch(not already in animation)
            if (Input.GetKey(KeyCode.J) && player1PunchTimer == 4 && player1KickTimer == 4 && player1ProjTimer == 4)
            {
                punchCollider.enabled = true;
            }
            //checks if punch collider is active 
            if (punchCollider.enabled)
            {
                player1PunchTimer--;
            }
            //checks if the player's punch timer is at 0
            if (player1PunchTimer == 0)
            {
                //resets the punch collider to be false and reset the punch timer so it can be used again
                punchCollider.enabled = false;
                player1PunchTimer = resetCooldownTimer;
            }


            if (Input.GetKey(KeyCode.K) && player1PunchTimer == 4 && player1KickTimer == 4 && player1ProjTimer == 4)
            {
                kickCollider.enabled = true;
            }
            //checks if kick collider is active 
            if (kickCollider.enabled)
            {
                player1KickTimer--;
            }
            //checks if the player's kick timer is at 0
            if (player1KickTimer == 0)
            {
                //resets the kick collider to be false and reset the kick timer so it can be used again
                kickCollider.enabled = false;
                player1KickTimer = resetCooldownTimer;
            }


            if (Input.GetKey(KeyCode.L) && player1PunchTimer == 4 && player1KickTimer == 4 && player1ProjTimer == 4)
            {
                //get current player position
                Vector3 startProj = transform.position;

                if (isFacingRight)
                {
                    startProj.x += 0.5f;
                }
                else
                {
                    startProj.x -= 0.5f;
                }


                Instantiate(projectile);
                projCollider = projectile.GetComponent<BoxCollider2D>();
                player1ProjAnim = true;
            }
            //checks to see if the player is in the projectile throwing animation
            if (player1ProjAnim)
            {
                player1ProjTimer--;
            }
            //checks to see if the player's proj timer is at 0
            if(player1ProjTimer == 0)
            {
                //reset the animation and the timer for the projectile animation
                player1ProjTimer = resetCooldownTimer;
                player1ProjAnim = false;
            }

            
        }
        else if (player == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !jumped) //up
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
            if (Input.GetKey(KeyCode.Keypad1) && player2PunchTimer == 4 && player2KickTimer == 4 && player2ProjTimer == 4)
            {
                punchCollider.enabled = true;
            }
            //checks if punch collider is active 
            if (punchCollider.enabled)
            {
                player2PunchTimer--;
            }
            //checks if the player's punch timer is at 0
            if (player2PunchTimer == 0)
            {
                //resets the punch collider to be false and reset the punch timer so it can be used again
                punchCollider.enabled = false;
                player2PunchTimer = resetCooldownTimer;
            }


            if (Input.GetKey(KeyCode.Keypad2) && player2PunchTimer == 4 && player2KickTimer == 4 && player2ProjTimer == 4)
            {
                kickCollider.enabled = true;
            }
            //checks if kick collider is active 
            if (kickCollider.enabled)
            {
                player2KickTimer--;
            }
            //checks if the player's kick timer is at 0
            if (player2KickTimer == 0)
            {
                //resets the kick collider to be false and reset the kick timer so it can be used again
                kickCollider.enabled = false;
                player2KickTimer = resetCooldownTimer;
            }


            if (Input.GetKey(KeyCode.Keypad3) && player2PunchTimer == 4 && player2KickTimer == 4 && player2ProjTimer == 4)
            {
                Instantiate(projectile);
                projCollider = projectile.GetComponent<BoxCollider2D>();
                player2ProjAnim = true;
            }
            //checks to see if the player is in the projectile throwing animation
            if (player2ProjAnim)
            {
                player2ProjTimer--;
            }
            //checks to see if the player's proj timer is at 0
            if (player2ProjTimer == 0)
            {
                //reset the animation and the timer for the projectile animation
                player2ProjTimer = resetCooldownTimer;
                player2ProjAnim = false;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "punch")
        {
            //Take Damage
            health -= 3;
            if(isFacingRight)
            {
                transform.Translate(new Vector3(-0.05f, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(0.05f, 0, 0));
            }
        }
        if (collision.gameObject.name == "kick")
        {
            //Take Damage
            health -= 5;
            if (isFacingRight)
            {
                transform.Translate(new Vector3(-0.08f, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(0.08f, 0, 0));
            }
        }
        if(collision.gameObject.name == "proj")
        {
            //take damage
            health -= 5;
            if (isFacingRight)
            {
                transform.Translate(new Vector3(-0.1f, 0, 0));
            }
            else
            {
                transform.Translate(new Vector3(0.1f, 0, 0));
            }
        }
    }
}
