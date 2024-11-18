using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemColetavel : MonoBehaviour
{

   //C�digo respons�vel por coletar e acrescentar os item, al�m da c�di��o de vit�ria da segunda cena.
    public int abacate = 0;
    public Text abacateText;
    public ControllGame genJ;

    // Start is called before the first frame update
    void Start()
    {
        ModTexto();
        genJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllGame>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Abacate")
        {
            Destroy(collision.gameObject);
            abacate++;
            ModTexto();
            if (abacate == 5)
            {
                Debug.Log("Vit�ria");
                genJ.VitoriaPlayer();
            }
        }
    }


    void ModTexto()
    {
        abacateText.text = abacate.ToString() + "x";
    }
}
