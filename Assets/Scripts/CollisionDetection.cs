using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //objA is the attack obj collision box, objB is the model that is being attacked
    public bool PlayerToPlayerCollision(float p1MaxX, float p1MinX, float p1MaxY, float p1MinY, float p2MaxX, float p2MinX, float p2MaxY, float p2MinY)
    {
        return (p1MaxX > p2MinX && p1MinX < p2MaxX && p1MaxY > p2MinY && p1MinY < p2MaxY);
    }
}
