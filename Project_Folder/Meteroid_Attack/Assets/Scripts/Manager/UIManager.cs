using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Main Menu")]
    [SerializeField]
    RectTransform mainmenuBG;
    [SerializeField]
    RectTransform mainmenuLogo;
    [SerializeField]
    Transform mainmenuPlanet;
    
    public RectTransform[] playButton;
    [SerializeField]
    GameObject loadingBar;

    [Header("In Game")]
    [SerializeField]
    RectTransform restartButton;
    [SerializeField]
    RectTransform controlMenu;
    

    public bool gameStarted;


    public  bool OnMainMenu=true;
    [SerializeField]
    string sceneName;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(OnMainMenu)
        {
            AudioManager.instance.Play("Space");
            mainmenuLogo.DOScale(Vector2.one, 0.4f);
            mainmenuPlanet.DOScale(Vector2.one, 0.4f);

            playButton[ShipManager.instance.shipIndex].DOScale(Vector2.one, 0.45f);
        }

        else
        {
            controlMenu.DOScale(Vector2.one, 0.35f);
        }
    }

    public void OnPressPlay()
    {
        PlayerPrefs.SetInt("ShipIndex", ShipManager.instance.shipIndex);
        AudioManager.instance.Play("Initialize");
        mainmenuLogo.GetComponent<Animator>().enabled = false;
        loadingBar.SetActive(true);
        playButton[ShipManager.instance.shipIndex].DOMoveY(100,0.75f).OnComplete(() =>
        {
            mainmenuLogo.DOScale(Vector2.zero, 0.25f);
            mainmenuPlanet.DOScale(Vector2.zero, 0.25f);
            mainmenuBG.DOAnchorPos(new Vector3(0, -10000, 0), 0.25f);
            
            gameStarted = true;

            SceneManager.LoadScene(sceneName);
        });
        playButton[ShipManager.instance.shipIndex].DOScale(Vector2.zero, 0.75f);
        
    }

    public void TweenPlayButton()
    {
        Debug.Log(ShipManager.instance.shipIndex );
        playButton[ShipManager.instance.shipIndex ].DOScale(Vector2.one, 0.45f);
    }
    public void EnableRestartButton()
    {
        
        restartButton.DOScale(Vector2.one, 0.25f);
        controlMenu.DOScale(Vector2.zero, 0.25f);
    }
    public void Mute_UnMute()
    {
        if(AudioManager.instance.wasMuted())
        {
            AudioManager.instance.setAudio(false);
            Camera.main.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            
            Camera.main.GetComponent<AudioListener>().enabled = false;
            AudioManager.instance.setAudio(true);
        }
    }
    public void OnPressRestart()
    {
        AudioManager.instance.Play("Button Press");

        restartButton.DOScale(Vector2.zero, 0.09f).OnComplete(() =>
        {
            restartButton.DOScale(new Vector2(0.8f, 0.8f), 0.09f);
            GameManager.instance.RestartGame();

        });
    }
}
