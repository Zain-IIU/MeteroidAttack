using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    int ID;
    [SerializeField]
    float upwardThrust;

  
    private void Start()
    {
        Destroy(this.gameObject,2f);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * upwardThrust * Time.deltaTime);
    }
    public void SetID(int newID) => ID = newID;

    public int GetID()
    {
        return ID;
    }

    
}
