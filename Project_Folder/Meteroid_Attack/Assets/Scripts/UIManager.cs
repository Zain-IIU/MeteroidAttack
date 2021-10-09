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
    [SerializeField]
    RectTransform playButton;
    [SerializeField]
    RectTransform restartButton;
    
    public bool gameStarted;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mainmenuLogo.DOScale(Vector2.one, 0.4f);
        mainmenuPlanet.DOScale(Vector2.one, 0.4f);
        playButton.DOScale(Vector2.one, 0.45f);
    }
    public void OnPressPlay()
    {
        mainmenuLogo.GetComponent<Animator>().enabled = false;
        playButton.DOAnchorPos(new Vector3(0, 850, 0), 0.75f).OnComplete(() =>
        {
            mainmenuLogo.DOScale(Vector2.zero, 0.25f);
            mainmenuPlanet.DOScale(Vector2.zero, 0.25f);
            mainmenuBG.DOAnchorPos(new Vector3(0, -10000, 0), 0.25f);
            gameStarted = true;
            GameManager.instance.StartGame();
        });
        playButton.DOScale(Vector2.zero, 0.75f);
    }

    public void EnableRestartButton()
    {
        restartButton.DOScale(Vector2.one, 0.25f);
    }
    public void OnPressRestart()
    {
        restartButton.DOScale(Vector2.zero, 0.09f).OnComplete(() =>
        {
            restartButton.DOScale(new Vector2(0.8f, 0.8f), 0.09f);
            GameManager.instance.RestartGame();

        });
    }
}
