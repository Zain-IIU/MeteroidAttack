using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollisions : MonoBehaviour
{
    [SerializeField]
    string Tag;

    [SerializeField]
    GameObject VFXPrefab;
    [SerializeField]
    bool isMeteor;

    [SerializeField]
    int ID;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Tag))
        {
            if(isMeteor)
            {
                if(collision.GetComponent<Projectile>().GetID() == ID)
                {

                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    ScoreManager.instance.IncrementScore();
                    Instantiate(VFXPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    UIManager.instance.EnableRestartButton();
                    GameManager.instance.StopAllOperaions();
                }
               
            }
            else if(!isMeteor)
            {
                Destroy(this.gameObject);
                UIManager.instance.EnableRestartButton();
                GameManager.instance.StopAllOperaions();
                Instantiate(VFXPrefab, transform.position, Quaternion.identity);
            }
            


        }
    }

  
}
