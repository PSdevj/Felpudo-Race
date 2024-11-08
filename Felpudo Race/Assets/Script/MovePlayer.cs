using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

 
    public Rigidbody2D corpoPlayer;
    public float velocidadePlayer;

    public GameObject laserPlayer;
    public Transform localLaserPlayer;

    public bool temEnergia;
    public int energia = 10;
    public float tempoDeEnergia = 0f;

    public float tempoMaximoTiro;
    public float tempoAtualTiro;


    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody2D>();
        temEnergia = true;
        tempoAtualTiro = tempoMaximoTiro;

    }
    void Update()

    {
        movimentacaoPlayer();
   
        if (tempoAtualTiro <= 0)
        {
            AtirarFruta();
        }
        tempoAtualTiro -= Time.deltaTime;
    }


    public void movimentacaoPlayer()
    {
        velocidadePlayer = Input.GetAxis("Horizontal") * 3.5f;
        corpoPlayer.velocity = new Vector2(velocidadePlayer, corpoPlayer.velocity.y);
    }

    public void puloPlayer()
    {
        
    }

    public void AtirarFruta()
    {
        if (Input.GetButtonDown("Fire1"))
        {
        
           Instantiate(laserPlayer, localLaserPlayer.position, localLaserPlayer.rotation);
           tempoAtualTiro = tempoMaximoTiro;

        }
    }
  

}
