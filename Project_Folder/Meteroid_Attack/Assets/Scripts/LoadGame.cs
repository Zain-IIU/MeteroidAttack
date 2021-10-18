using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class LoadGame : MonoBehaviour
{
    [SerializeField]
    RectTransform centerPart;
    private void Awake()
    {
        PlayerPrefs.SetInt("PlayAudio", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadintoGame), 1.5f);

        //PlayerPrefs.SetInt("HighScore", 0);
    }
    public void LoadintoGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
