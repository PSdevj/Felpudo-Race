using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePera : MonoBehaviour
{
    public Scene scene;
    //Código responsável pela velocidade da pera
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "Cena Secundária")
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } 
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
