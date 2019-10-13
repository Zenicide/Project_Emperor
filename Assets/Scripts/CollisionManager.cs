using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    GameObject Player1;
    GameObject Player2;

    CollisionDetection player1Detect;
    CollisionDetection player2Detect;
    // Start is called before the first frame update
    void Start()
    {
        player1Detect = gameObject.GetComponent<CollisionDetection>();
        player2Detect = gameObject.GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
