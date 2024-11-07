using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

 
    public Rigidbody2D corpoPlayer;
    public float velocidadePlayer;



    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody2D>();
     
    }
    void Update()

    {
        velocidadePlayer = Input.GetAxis("Horizontal") * 3.5f;
        corpoPlayer.velocity = new Vector2(velocidadePlayer, corpoPlayer.velocity.y);
    }
}
