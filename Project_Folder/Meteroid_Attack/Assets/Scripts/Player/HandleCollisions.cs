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
               
                if (collision.GetComponent<Projectile>().GetID() == ID)
                {

                    
                    Destroy(this.gameObject);
                    ScoreManager.instance.IncrementScore();
                    AudioManager.instance.Play("Meteor Explode");
                }
                else
                {
                    AudioManager.instance.Play("Negative");
                    UIManager.instance.EnableRestartButton();
                    GameManager.instance.StopAllOperaions();
                    AdsManager.instance.onGameStartLoadInterstitial();
                }
                Destroy(collision.gameObject);
                

            }
            else if(!isMeteor)
            {
                AudioManager.instance.Play("Negative");
                AudioManager.instance.Play("Ship Explode");
                this.gameObject.SetActive(false);
                UIManager.instance.EnableRestartButton();
                GameManager.instance.StopAllOperaions();

                AdsManager.instance.onGameStartLoadInterstitial();
            }


            Instantiate(VFXPrefab, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("DeadZone"))
        {
            AudioManager.instance.Play("Negative");
            UIManager.instance.EnableRestartButton();
            GameManager.instance.StopAllOperaions();
            Instantiate(VFXPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AdsManager.instance.onGameStartLoadInterstitial();
        }

       
    }


}
