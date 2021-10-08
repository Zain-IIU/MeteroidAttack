using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    int ID;
    [SerializeField]
    float upwardThrust;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.AddForce(Vector2.up * upwardThrust);
    }

    public void SetID(int newID) => ID = newID;

    public int GetID()
    {
        return ID;
    }

    
}
