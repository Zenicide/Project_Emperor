using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    Animator Anim;

    public int player;
    public float health; //health of fighter
    public float damageMultiplier; //damage you multiply to character's attacks
    public float rageBar;

    public Vector2 position;
    public Vector2 velocity;
    const float deceleration = 0.07f;

    public bool isFacingRight = true;
    public bool jumped;
    public bool crouched;

    public GameObject projectile;
    public List<GameObject> projectiles;

    float projVelocity = 0.2f;

    public BoxCollider2D punchCollider;
    public BoxCollider2D kickCollider;
    BoxCollider2D projCollider;

    //internal cooldown timer so they can't do the same action again
    const int resetCooldownTimer = 18;
    const int actionframeTime = 18;
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
        Anim = GetComponent<Animator>();
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
            //GetComponent<SpriteRenderer>().flipX = true;
            //transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            transform.localScale *= new Vector2(-1, 1);
        }
        position = transform.position;
        velocity = new Vector2(.15f, 0.9f); //change values to change speed

        jumped = false;

        //setting timers for each action
        player1PunchTimer = actionframeTime;
        player1KickTimer = actionframeTime;
        player1ProjTimer = actionframeTime;

        player2PunchTimer = actionframeTime;
        player2KickTimer = actionframeTime;
        player2ProjTimer = actionframeTime;

        projectiles = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        InputKeys();
        Bounds();
        transform.position = position;
    }

    void InputKeys()
    {
        if (player == 1)
        {
            if (jumped)
            {
                velocity.y -= deceleration;
                position.y += velocity.y;
                Anim.SetFloat("VelocityY", velocity.y);
                if (position.y <= -1.9f)
                {
                    position.y = -2f;
                    jumped = false;
                    Anim.SetBool("isJumping", false);
                }
            }
            
            
            if (Input.GetKey(KeyCode.S)) //down
            {
                Anim.SetBool("isCrouching", true);
            }
            if (Input.GetKeyDown(KeyCode.W) && !jumped) //up
            {
                jumped = true;
                velocity.y = 0.9f;
                Anim.SetBool("isJumping", true);
            }
            if (Input.GetKey(KeyCode.S)) //down
            {
                Anim.SetBool("isCrouching", true);
            }
            else if (Input.GetKey(KeyCode.A)) //left
            {
                position.x -= velocity.x;
                Anim.SetFloat("Speed", Mathf.Abs(velocity.x));

            }
            else if (Input.GetKey(KeyCode.D)) //right
            {
                position.x += velocity.x;
                Anim.SetFloat("Speed", Mathf.Abs(velocity.x));
            }
            

            if (Input.GetKeyUp(KeyCode.A))
            {
                Anim.SetFloat("Speed", 0);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Anim.SetFloat("Speed", 0);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                Anim.SetBool("isCrouching", false);
            }

            //detects if the player is trying to punch and the player is able to punch(not already in animation)
            if (Input.GetKeyDown(KeyCode.J) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                punchCollider.enabled = true;
                Anim.SetBool("isPunching", true);
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
                Anim.SetBool("isPunching", false);
            }


            if (Input.GetKeyDown(KeyCode.K) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                kickCollider.enabled = true;
                Anim.SetBool("isKicking", true);
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
                Anim.SetBool("isKicking", false);
            }


            if (Input.GetKeyDown(KeyCode.L) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                //get current player position
                Vector2 startProj = transform.position;

                if (isFacingRight)
                {
                    startProj.x += 0.5f;
                }
                else
                {
                    startProj.x -= 0.5f;
                }

                GameObject obj = Instantiate(projectile);
                obj.transform.position = punchCollider.transform.position;
                if (isFacingRight)
                {
                    obj.transform.position += new Vector3(2, 1, 0);
                }
                else
                {
                    obj.transform.position += new Vector3(-2, 1, 0);
                }
                projectiles.Add(obj);
                if (isFacingRight)
                {
                    obj.GetComponent<ProjectileManager>().velocity = projVelocity;
                }else
                {
                    obj.GetComponent<ProjectileManager>().velocity = -projVelocity;
                    obj.transform.localScale *= new Vector2(-1, 1);
                }
                //projectiles[0].transform.position = startProj;
                projCollider = projectile.GetComponent<BoxCollider2D>();
                player1ProjAnim = true;
                Anim.SetBool("isThrowing", true);
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
                Anim.SetBool("isThrowing", false);
            }
            
            
        }
        else if (player == 2)
        {
            if (jumped)
            {
                velocity.y -= deceleration;
                position.y += velocity.y;
                Anim.SetFloat("VelocityY", velocity.y);
                if (position.y <= -1.9f)
                {
                    position.y = -2f;
                    jumped = false;
                    Anim.SetBool("isJumping", false);
                }
            }


            if (Input.GetKey(KeyCode.DownArrow)) //down
            {
                Anim.SetBool("isCrouching", true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && !jumped) //up
            {
                jumped = true;
                velocity.y = 0.9f;
                Anim.SetBool("isJumping", true);
            }
            if (Input.GetKey(KeyCode.DownArrow)) //down
            {
                Anim.SetBool("isCrouching", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow)) //left
            {
                position.x -= velocity.x;
                Anim.SetFloat("Speed", Mathf.Abs(velocity.x));

            }
            else if (Input.GetKey(KeyCode.RightArrow)) //right
            {
                position.x += velocity.x;
                Anim.SetFloat("Speed", Mathf.Abs(velocity.x));
            }


            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Anim.SetFloat("Speed", 0);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Anim.SetFloat("Speed", 0);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Anim.SetBool("isCrouching", false);
            }

            //detects if the player is trying to punch and the player is able to punch(not already in animation)
            if (Input.GetKeyDown(KeyCode.Keypad1) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                punchCollider.enabled = true;
                Anim.SetBool("isPunching", true);
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
                Anim.SetBool("isPunching", false);
            }


            if (Input.GetKeyDown(KeyCode.Keypad2) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                kickCollider.enabled = true;
                Anim.SetBool("isKicking", true);
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
                Anim.SetBool("isKicking", false);
            }


            if (Input.GetKeyDown(KeyCode.Keypad3) && player1PunchTimer == actionframeTime && player1KickTimer == actionframeTime && player1ProjTimer == actionframeTime)
            {
                //get current player position
                Vector2 startProj = transform.position;

                if (isFacingRight)
                {
                    startProj.x += 0.5f;
                }
                else
                {
                    startProj.x -= 0.5f;
                }
                

                GameObject obj = Instantiate(projectile);
                obj.transform.position = punchCollider.transform.position;
                if (isFacingRight)
                {
                    obj.transform.position += new Vector3(2, 1,0);
                }
                else
                {
                    obj.transform.position += new Vector3(-2, 1, 0);
                }
                projectiles.Add(obj);
                if (isFacingRight)
                {
                    obj.GetComponent<ProjectileManager>().velocity = projVelocity;
                }
                else
                {
                    obj.GetComponent<ProjectileManager>().velocity = -projVelocity;
                    obj.transform.localScale *= new Vector2(-1, 1);
                }
                //projectiles[0].transform.position = startProj;
                projCollider = projectile.GetComponent<BoxCollider2D>();
                player1ProjAnim = true;
                Anim.SetBool("isThrowing", true);
            }
            //checks to see if the player is in the projectile throwing animation
            if (player1ProjAnim)
            {
                player1ProjTimer--;
            }
            //checks to see if the player's proj timer is at 0
            if (player1ProjTimer == 0)
            {
                //reset the animation and the timer for the projectile animation
                player1ProjTimer = resetCooldownTimer;
                player1ProjAnim = false;
                Anim.SetBool("isThrowing", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "punch")
        {
            Debug.Log("Hit");
            //Take Damage
            health -= 3;
            if (isFacingRight)
            {
                transform.Translate(new Vector3(-100000f, 0, 0));
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
        if (collision.gameObject.name == "proj")
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

    void Bounds()
    {
        if (position.x <= - 8)
        {
            position.x += velocity.x;
        }
        else if (position.x >= 8)
        {
            position.x -= velocity.x;
        }
    }
}
