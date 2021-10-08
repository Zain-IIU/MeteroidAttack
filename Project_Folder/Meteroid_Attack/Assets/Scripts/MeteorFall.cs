using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MeteorFall : MonoBehaviour
{
    [SerializeField]
    float fallSpeed;
    [SerializeField]
    float sizeIncrementTime;

    Rigidbody2D RB;

    private void Awake()
    {
        transform.DOScale(new Vector2(0.25f, 0.25f), 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        transform.DOScale(Vector2.one, sizeIncrementTime);
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            Destroy(this.gameObject);
        }
    }

}