using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    RectTransform scoreObject;

    [SerializeField]
    int increaseinScore;

    int curScore;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        curScore = 0;
        scoreText.text = curScore.ToString();
    }

    public void IncrementScore()
    {
        AudioManager.instance.Play("Score SFX");
        curScore += increaseinScore;
        scoreObject.transform.DOScale(new Vector2(1.25f, 1.25f), 0.25f).OnComplete(() =>
        {
            scoreObject.transform.DOScale(Vector2.one, 0.25f);
        }
            );
        scoreText.text = curScore.ToString();
    }

    public int getCurScore()
    {
        return curScore;
    }
}
