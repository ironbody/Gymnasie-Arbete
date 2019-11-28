using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    private static Text uiText;
    private static RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        rectTrans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Sequence NewWave(int waveNum)
    {
        uiText.text = "Wave: " + waveNum;

        Sequence waveSeq = DOTween.Sequence();
        waveSeq.Append(rectTrans.DOAnchorPosX(0, 2f, false));
        waveSeq.Append(rectTrans.DOAnchorPosX(300, 2f, false));
        waveSeq.PrependInterval(1.5f);

        return waveSeq;
    }
}