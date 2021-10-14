using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Mover player;
    [SerializeField]
    MeteorSpawner Spawner;
    [SerializeField]
    string sceneName;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AudioManager.instance.Play("Space");
    }
    public void StartGame()
    {
        player.enabled = true;
        Spawner.enabled = true ;
        Spawner.gameObject.SetActive(true);
    }
    
    public void StopAllOperaions()
    {
        if(player)
        player.enabled = false;
        Spawner.StopSpawning();
    }

    public void StartAllOperations()
    {
        if (player)
        {

            player.enabled = true;
            player.NormalizeBehaviour();
            player.gameObject.SetActive(true);
        }
            
        Spawner.ReSpawnStart();
    }
     public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);  
    }


    public void ContinueGame()
    {
        StartAllOperations();
        UIManager.instance.DisableRestartButton();
    }
}
