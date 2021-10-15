using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ControlManager : MonoBehaviour
{
    public static ControlManager instance;
    [SerializeField]
    Transform Player;
    [SerializeField]
    Transform raycastPoint;
    [SerializeField]
    Transform projectilePoint;
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    LayerMask enemyLayer;

    [SerializeField]
    float easingTime;
    [SerializeField]
    Ease EaseType;
    [SerializeField]
    RectTransform controlButton;

    [SerializeField]
    Transform allButtonsParent;


    [SerializeField]
    float timeBWchangingControlLayout;

    [SerializeField]
    float timetoStartChangingLayout;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating(nameof(RearrangeAllButtons), timetoStartChangingLayout, timeBWchangingControlLayout);
    }
    public void ShootMeteor()
    {
       
        if(Player && raycastPoint)
        {
            controlButton = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>();
            controlButton.DOScale(Vector2.zero, 0.09f).SetEase(EaseType).OnComplete(() =>
            {
                controlButton.DOScale(new Vector2(0.8f,0.8f), 0.09f).SetEase(EaseType);

            });
                 

                 
            Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(raycastPoint.position, 20f, enemyLayer);
            if (nearbyObjects != null)
            {
                GameObject closeOne = GetNearestObject(Player.gameObject, nearbyObjects);
                if(closeOne)
                {
                    Player.DOMoveX(closeOne.transform.position.x, easingTime).SetEase(EaseType).OnComplete(() =>
                    {
                        GameObject Fire = Instantiate(projectile, projectilePoint.position, Quaternion.identity);
                        Fire.GetComponent<Projectile>().SetID(int.Parse(EventSystem.current.currentSelectedGameObject.name));
                        AudioManager.instance.Play("Shoot");
                        Player.DOMoveX(0, easingTime).SetEase(EaseType);
                    });
                }
               

            }
        }  
    }

    GameObject GetNearestObject(GameObject sourceObject, Collider2D[] nearbyObjects)
    {
        GameObject nearestObject = null;
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < nearbyObjects.Length; i++)
        {
            float distance = (nearbyObjects[i].transform.position - sourceObject.transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestObject = nearbyObjects[i].gameObject;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

    public void DestroyNearbyObjectsforContinuation()
    {
        Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(raycastPoint.position, 20f, enemyLayer);
        foreach(Collider2D obj in nearbyObjects)
        {
            Destroy(obj.gameObject);
        }
    }
    public void RearrangeAllButtons()
    {
        int randomChildIndex = Random.Range(0, allButtonsParent.childCount);

        Transform randomChildObject =allButtonsParent.GetChild(randomChildIndex);

        int newChildIndex = Random.Range(0, allButtonsParent.childCount);

        while (newChildIndex==randomChildIndex)
        {
            newChildIndex = Random.Range(0, allButtonsParent.childCount);
        }

        randomChildObject.SetSiblingIndex(newChildIndex);

    }

}
