using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ControlManager : MonoBehaviour
{
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

    
    public void ShootMeteor()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        if(Player && raycastPoint)
        {
            Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(raycastPoint.position, 20f, enemyLayer);
            if (nearbyObjects != null)
            {
                GameObject closeOne = GetNearestObject(Player.gameObject, nearbyObjects);
                if(closeOne)
                {
                    Player.DOMoveX(closeOne.transform.position.x, easingTime).SetEase(EaseType).OnComplete(() =>
                    {
                        Player.DOMove(new Vector3(0, -1.5f), 1.5f);
                        GameObject Fire = Instantiate(projectile, projectilePoint.position, Quaternion.Euler(0,0,90f));
                        Fire.GetComponent<Projectile>().SetID(int.Parse(EventSystem.current.currentSelectedGameObject.name));
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
}
