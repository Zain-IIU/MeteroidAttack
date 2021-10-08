using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFall : MonoBehaviour
{
    [SerializeField]
    float fallSpeed;


    Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed*Time.deltaTime);
    }
}
