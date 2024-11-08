using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaDoPlayer : MonoBehaviour
{

    public int vidaMaxima;
    public int vidaAtual;

    public Slider barraDeVida;

    public Spawn spawn;

    public ControllGame genJ;


    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
        barraDeVida.maxValue = vidaAtual;

        genJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lesma")
        {
            vidaAtual--;
            barraDeVida.value = vidaAtual;
            Destroy(collision.gameObject);

            if(vidaAtual <= 4)
            {
                genJ.PersonagemMorreu();
            }

        }
    }
}
