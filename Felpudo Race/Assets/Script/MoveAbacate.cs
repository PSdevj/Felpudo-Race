using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbacate : MonoBehaviour
{
    //C�digo respons�vel pela velocidade do abacate(item)
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


}
