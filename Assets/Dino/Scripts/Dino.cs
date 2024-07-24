using Assets.Dino.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Player player { get; set; }


    // Start is called before the first frame update
    void Start()
    {
       player = new Player(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}