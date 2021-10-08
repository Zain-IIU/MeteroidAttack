using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    Mover player;
    [SerializeField]
    MeteorSpawner Spawner;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player.enabled = false;
        Spawner.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
