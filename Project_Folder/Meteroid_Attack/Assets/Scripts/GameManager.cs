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

    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;
        Spawner.enabled = false;
        Spawner.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        player.enabled = true;
        Spawner.enabled = true ;
        Spawner.gameObject.SetActive(true);
    }
    
    public void StopAllOperaions()
    {
        player.enabled = false;
        Spawner.StopSpawning();
    }
     public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);  
    }
}
