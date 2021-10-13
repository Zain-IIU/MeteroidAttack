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
    [SerializeField]
    RectTransform nextButton;
     [SerializeField]
    RectTransform backButton;
    
    private void Awake()
    {
        instance = this;

        shipIndex = 0;

    }
  
    public void NextShip()
    {
        AudioManager.instance.Play("ButtonPress");
        TweenButton(nextButton);
        if (shipIndex <= totalShips - 2)
            shipIndex++;
        else
            shipIndex = 0;
        shipTransform.DOAnchorPos(new Vector2(-400 * (shipIndex), 0), tweeningTime).SetEase(easeType);

        UIManager.instance.TweenPlayButton();
    }
    public void previousShip()
    {
        AudioManager.instance.Play("ButtonPress");
        TweenButton(backButton);

        if (shipIndex > 0)
            shipIndex--;
        else
            shipIndex = totalShips-1;
        shipTransform.DOAnchorPos(new Vector2(-400 * (shipIndex), 0), tweeningTime).SetEase(easeType);

        UIManager.instance.TweenPlayButton();
    }


    void TweenButton(RectTransform button)
    {
        button.DOScale(Vector2.zero, 0.25f).OnComplete(() =>
        {
            button.DOScale(Vector2.one, 0.25f);
        });
    }
}


