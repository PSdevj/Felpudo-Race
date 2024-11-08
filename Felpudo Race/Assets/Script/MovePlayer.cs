using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

 
    public Rigidbody2D corpoPlayer;
    public float velocidadePlayer;

    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEChao;
    public int quantidadeDePulo = 1;


    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody2D>();
     
    }
    void Update()

    {
        movimentacaoPlayer();
    }


    public void movimentacaoPlayer()
    {
        velocidadePlayer = Input.GetAxis("Horizontal") * 3.5f;
        corpoPlayer.velocity = new Vector2(velocidadePlayer, corpoPlayer.velocity.y);
    }

    public void puloPlayer()
    {
        
    }
}
