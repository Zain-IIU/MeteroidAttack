using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ShipManager : MonoBehaviour
{
    public static ShipManager instance;

    [SerializeField]
    int totalShips;


    public int shipIndex;

    [SerializeField]
    RectTransform shipTransform;

    [SerializeField]
    float tweeningTime;
    [SerializeField]
    Ease easeType;

    
    private void Awake()
    {
        instance = this;

        shipIndex = 0;

    }
  
    public void ChangeShip()
    {
        shipTransform.DOAnchorPos(new Vector2(-400*(++shipIndex), 0), tweeningTime).SetEase(easeType);
        UIManager.instance.TweenPlayButton();
        if (shipIndex >=totalShips-1)
            shipIndex = -1;
       
    }
}
