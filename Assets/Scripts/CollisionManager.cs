using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;
    SpriteRenderer renderA;
    SpriteRenderer renderB;

    //the values for the 2 bounding boxes
    float player1CenterXBound;
    float player1CenterYBound;
    float player1MinX;
    float player1MaxX;
    float player1MinY;
    float player1MaxY;

    float player2CenterXBound;
    float player2CenterYBound;
    float player2MinX;
    float player2MaxX;
    float player2MinY;
    float player2MaxY;

    //the attack collision bounding boxes for player 1 and 2
    float player1AttackMinX;
    float player1AttackMaxX;
    float player1AttackMinY;
    float player1AttackMaxY;

    float player2AttackMinX;
    float player2AttackMaxX;
    float player2AttackMinY;
    float player2AttackMaxY;

    CollisionDetection player1Detect;
    CollisionDetection player2Detect;

    Character Player1CharScript;
    Character Player2CharScript;

    bool player1FacingRight;
    bool player2FacingRight;

    //projectile stuff
    GameObject Player1Projectile;
    GameObject Player2Projectile;


    float proj1MaxX;
    float proj1MinX;
    float proj1MaxY;
    float proj1MinY;

    float proj2MaxX;
    float proj2MinX;
    float proj2MaxY;
    float proj2MinY;

    // Start is called before the first frame update
    void Start()
    {
        player1Detect = gameObject.GetComponent<CollisionDetection>();
        player2Detect = gameObject.GetComponent<CollisionDetection>();

        renderA = Player1.GetComponent<SpriteRenderer>();
        renderB = Player2.GetComponent<SpriteRenderer>();

        //setting values for the player 1 and 2 base bounding boxes
        player1CenterXBound = renderA.bounds.center.x;
        player1CenterYBound = renderA.bounds.center.y;
        player1MinX = player1CenterXBound - 0.5f;
        player1MaxX = player1CenterXBound + 0.5f;
        player1MinY = player1CenterYBound - 1f;
        player1MaxY = player1CenterYBound + 1f;

        player2CenterXBound = renderB.bounds.center.x;
        player2CenterYBound = renderB.bounds.center.y;
        player2MinX = player2CenterXBound - 0.5f;
        player2MaxX = player2CenterXBound + 0.5f;
        player2MinY = player2CenterYBound - 1f;
        player2MaxY = player2CenterYBound + 1f;

    }

    // Update is called once per frame
    void Update()
    {
        Player1Attacks();
    }
    
    void Player1Attacks()
    {
        Player1CharScript = Player1.GetComponent<Character>();
        player1FacingRight = Player1CharScript.isFacingRight;

        //player 1 punch
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (player1FacingRight)
            {
                player1AttackMaxX = player1CenterXBound + 1.5f;
                player1AttackMinX = player1CenterXBound + 0.5f;
                player1AttackMaxY = player1CenterYBound + 0.9f;
                player1AttackMinY = player1CenterYBound + 0.7f;
            }
            else
            {
                player1AttackMaxX = player1CenterXBound - 0.5f;
                player1AttackMinX = player1CenterXBound - 1.5f;
                player1AttackMaxY = player1CenterYBound + 0.9f;
                player1AttackMinY = player1CenterYBound + 0.7f;
            }

            player1Detect.AttackToPlayerCollision(player1AttackMaxX, player1AttackMinX, player1AttackMaxY, player1AttackMinY, player2MaxX, player2MinX, player2MaxY, player2MinY);
        }

        //player 1 kick
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (player1FacingRight)
            {
                player1AttackMaxX = player1CenterXBound + 1.5f;
                player1AttackMinX = player1CenterXBound + 0.5f;
                player1AttackMaxY = player1CenterYBound + 0f;
                player1AttackMinY = player1CenterYBound - 0.2f;
            }
            else
            {
                player1AttackMaxX = player1CenterXBound - 0.5f;
                player1AttackMinX = player1CenterXBound - 1.5f;
                player1AttackMaxY = player1CenterYBound + 0f;
                player1AttackMinY = player1CenterYBound - 0.2f;
            }

            player1Detect.AttackToPlayerCollision(player1AttackMaxX, player1AttackMinX, player1AttackMaxY, player1AttackMinY, player2MaxX, player2MinX, player2MaxY, player2MinY);
        }

        //spear throw
        if (Input.GetKeyDown(KeyCode.L))
        {

            Instantiate(Player1.GetComponent<Character>().projectile);
        }
    }
}
