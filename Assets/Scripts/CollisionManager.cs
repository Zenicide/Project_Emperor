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

    CollisionDetection player1Detect;
    CollisionDetection player2Detect;
    // Start is called before the first frame update
    void Start()
    {
        player1Detect = gameObject.GetComponent<CollisionDetection>();
        player2Detect = gameObject.GetComponent<CollisionDetection>();

        //setting values for the player 1 and 2 base bounding boxes
        player1CenterXBound = renderB.bounds.center.x;
        player1CenterYBound = renderB.bounds.center.y;
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
        
    }
}
