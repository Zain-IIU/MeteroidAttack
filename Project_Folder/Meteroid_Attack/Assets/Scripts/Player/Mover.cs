using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    Sprite[] ships;
    [SerializeField]
    SpriteRenderer Renderer;
    [SerializeField]
    float speedIncrement;
    [SerializeField]
    float timetoIncreaseSpeed;

    [SerializeField]
    float maxSpeedtoAttain;
    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        Renderer.sprite = ships[PlayerPrefs.GetInt("ShipIndex")];
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

    public void NormalizeBehaviour()
    {
        moveSpeed = 1.5f;
    }
}
