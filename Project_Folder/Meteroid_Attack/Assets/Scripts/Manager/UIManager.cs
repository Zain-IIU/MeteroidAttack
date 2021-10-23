using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Main Menu")]
    [SerializeField]
    TextMeshProUGUI highscoreText;
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
    [SerializeField]
    TextMeshProUGUI endGameScoreText;
    [SerializeField]
    public bool gameStarted;
    [SerializeField]
    RectTransform noAdsPanel;


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
            highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
            
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
        playButton[ShipManager.instance.shipIndex].DOAnchorPos(new Vector3(0,650,0),0.35f).OnComplete(() =>
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
        endGameScoreText.text = ScoreManager.instance.getCurScore().ToString();
        restartButton.DOScale(Vector2.one, 0.25f);
        controlMenu.DOScale(Vector2.zero, 0.25f);
        if(ScoreManager.instance.getCurScore()>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", ScoreManager.instance.getCurScore());
        }
    }

    public void DisableRestartButton()
    {
        restartButton.DOScale(Vector2.zero, 0.25f);
        controlMenu.DOScale(Vector2.one, 0.25f);
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

    public void ShowNoAdsPanel()
    {
        noAdsPanel.DOScale(Vector2.one, 0.25f);
    }
    public void HideAdsPanel()
    {
        noAdsPanel.DOScale(Vector2.zero, 0.25f);
    }
}
