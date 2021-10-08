using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweeningElements : MonoBehaviour
{
    public enum TweenType
    {
        Rotate,
        Fade,
        Scale
    }
    [SerializeField]
    float easingtime;

    [SerializeField]
    Ease easeType;

    [SerializeField]
    TweenType tweenStyle;

    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 90), easingtime);
        switch (tweenStyle)
        {
            case TweenType.Rotate:
                
                break;

            case TweenType.Fade:
                break;

            case TweenType.Scale:
                break;
        }
    }

  
}
