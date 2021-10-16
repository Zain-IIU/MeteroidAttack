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

    // Start is called before the first frame update
    void Start()
    {
        centerPart.DOLocalRotate(new Vector3(0,0,0), 0.75f);
        centerPart.DOScale(Vector2.one, 0.75f);
        Invoke(nameof(LoadintoGame), 1.5f);

        //PlayerPrefs.SetInt("HighScore", 0);
    }
    public void LoadintoGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
