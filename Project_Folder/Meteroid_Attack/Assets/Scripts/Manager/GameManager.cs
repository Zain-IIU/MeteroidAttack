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

    [SerializeField]
    string mainMenu;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        AudioManager.instance.Play("Space");
        AudioManager.instance.DisableAudio();
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
        AudioManager.instance.Play("Button Press");
        SceneManager.LoadScene(sceneName);  
    }
    public void GotoMainMenu()
    {
        AudioManager.instance.Play("Button Press");
        SceneManager.LoadScene(mainMenu);
    }


    public void ContinueGame()
    {
        //ads reward to continue playing
        StartAllOperations();
        ControlManager.instance.DestroyNearbyObjectsforContinuation();
        UIManager.instance.DisableRestartButton();
    }
}
