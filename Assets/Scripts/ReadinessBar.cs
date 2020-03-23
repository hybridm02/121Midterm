using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadinessBar : MonoBehaviour
{
    public Image currentReadinessBar;
    public Text ratioText;

    public static float readinessPt;
    float maxReadinessPt = 100f;

    // Start is called before the first frame update
    void Start()
    {
        readinessPt = 0f;
        UpdateReadinessBar();
    }

    // Update is called once per frame
    void UpdateReadinessBar()
    {
        float ratio = readinessPt / maxReadinessPt;
        currentReadinessBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    void AddReadiness(float addReadinessPt)
    {
        readinessPt += addReadinessPt;
        if(readinessPt > maxReadinessPt){
            readinessPt = maxReadinessPt;
        }

        UpdateReadinessBar();
    }
}
