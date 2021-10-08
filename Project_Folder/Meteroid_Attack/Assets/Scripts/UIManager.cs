using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    RectTransform mainmenuBG;
    [SerializeField]
    RectTransform mainmenuLogo;
    [SerializeField]
    Transform mainmenuPlanet;

    public bool gameStarted;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
