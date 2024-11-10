using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesma : MonoBehaviour
{

    //Código responsável pela movimentação da lesma
    public float speed = 2f;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pera")
        {
            Destroy(gameObject);
        }
    }
   
}
