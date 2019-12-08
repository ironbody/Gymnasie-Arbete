using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public GameObject waveText;
    private static Text uiText;
    private static RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        uiText = waveText.GetComponent<Text>();
        rectTrans = GetComponent<RectTransform>();
    }

    public static Sequence NewWave(int waveNum)
    {
        uiText.text = waveNum.ToString();

        Sequence waveSeq = DOTween.Sequence();
        waveSeq.Append(rectTrans.DOAnchorPosX(0, 2f, false));
        waveSeq.Append(rectTrans.DOAnchorPosX(-300, 2f, false));
        waveSeq.PrependInterval(1.5f);
        rectTrans.anchoredPosition = new Vector2(300f, 0f);

        // rectTrans.anchoredPosition.x = 300f;

        return waveSeq;
    }
}