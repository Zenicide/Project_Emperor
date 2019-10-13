﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    GameObject playerOne;
    GameObject playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        playerOne = Instantiate(playerOnePrefab);
        playerOne.GetComponent<Character>().player = 1;
        playerTwo = Instantiate(playerTwoPrefab);
        playerTwo.GetComponent<Character>().player = 2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
