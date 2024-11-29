using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public int dano = 1; // Dano que o proj�til causar� ao player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Acessa o script de vida do player e aplica o dano
            VidaDoPlayer vidaDoPlayer = collision.gameObject.GetComponent<VidaDoPlayer>();
            if (vidaDoPlayer != null)
            {
                vidaDoPlayer.vidaAtual -= dano;
                vidaDoPlayer.barraDeVida.value = vidaDoPlayer.vidaAtual;
                //Debug.Log("O player foi atingido pelo proj�til! Vida atual do player: " + vidaDoPlayer.vidaAtual);
            }

            // Destr�i o proj�til ap�s o impacto
            Destroy(gameObject);
        }
    }
}
