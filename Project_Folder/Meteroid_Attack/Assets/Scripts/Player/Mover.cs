using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float speedIncrement;
    [SerializeField]
    float timetoIncreaseSpeed;

    [SerializeField]
    float maxSpeedtoAttain;
    private void Start()
    {
        InvokeRepeating(nameof(IncrementSpeed),2f,timetoIncreaseSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    void IncrementSpeed()
    {
        if(moveSpeed<maxSpeedtoAttain)
            moveSpeed += speedIncrement * Time.deltaTime;
    }
}
