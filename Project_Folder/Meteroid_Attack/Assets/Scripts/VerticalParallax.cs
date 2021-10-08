using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VerticalParallax : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    Transform BG1;
    [SerializeField]
    Transform BG2;

    [SerializeField]
    float cameraSmoothing;
    float size;
    private void Awake()
    {
        size = BG1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if(target)
        //{
        //    Vector3 targetPos = new Vector3(this.transform.position.x, target.transform.position.y + offset.y, this.transform.position.z);

        //    transform.position = Vector3.Lerp(this.transform.position, targetPos, cameraSmoothing);

           
        //}
        if (transform.position.y >= BG2.transform.position.y)
        {
            BG1.position = new Vector3(BG1.position.x, BG2.position.y + size, BG1.position.z);
            SwapBackground();
        }
    }

    void SwapBackground()
    {
        Transform temp = BG1;
        BG1 = BG2;
        BG2 = temp;
    }
}
