using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemColetavel : MonoBehaviour
{

   
    public int abacate = 0;
    public Text abacateText;

    // Start is called before the first frame update
    void Start()
    {
        ModTexto();
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
        }
    }


    void ModTexto()
    {
        abacateText.text = abacate.ToString() + "x";
    }
}
