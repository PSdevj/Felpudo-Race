using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] objetosSpawns;
    public Transform[] pontosSpawns;

    public float tempoMaximoSpawns;
    public float tempoAtualSpawns;

    // Start is called before the first frame update
    void Start()
    {
        
        tempoAtualSpawns = tempoMaximoSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        tempoAtualSpawns -= Time.deltaTime;


        if (tempoAtualSpawns <= 0)
        {
            SpawnsObjeto();
        }
    }

    private void SpawnsObjeto()
    {
        int objetoAleatorio = Random.Range(0, objetosSpawns.Length);
        int pontoAleatorio = Random.Range(0, pontosSpawns.Length);

        Instantiate(objetosSpawns[objetoAleatorio], pontosSpawns[pontoAleatorio].position, Quaternion.Euler(0f, 0f, -0.04253413f));

        tempoAtualSpawns = tempoMaximoSpawns;
    }
}
