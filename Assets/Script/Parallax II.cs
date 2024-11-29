using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxII : MonoBehaviour
{
    Material material;
    float distance;

    [Range(0f, 1f)]
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
