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

  

    private void Awake()
    {
        transform.DOScale(new Vector2(0.25f, 0.25f), 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(Vector2.one, sizeIncrementTime);
    }

    
}