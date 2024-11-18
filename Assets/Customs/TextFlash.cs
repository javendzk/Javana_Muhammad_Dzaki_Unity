using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum AlphaValue
{
    Shrinking,
    Growing,
}

public class TextFlash : MonoBehaviour
{
    [SerializeField] private AlphaValue currentAlphaValue;
    [SerializeField] private float minAlpha = 0.0f;
    [SerializeField] private float maxAlpha = 1.0f;
    [SerializeField] private float currentAlpha = 1.0f;
    [SerializeField] private float tickTime = 0.007f;

    [SerializeField] private TextMeshProUGUI myText;

    void Start()
    {
        currentAlphaValue = AlphaValue.Shrinking;
        myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, currentAlpha);
    }

    void Update()
    {
        UpdateAlpha();
    }

    public void UpdateAlpha()
    {
        if (currentAlphaValue == AlphaValue.Shrinking)
        {
            currentAlpha -= tickTime;
            myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, currentAlpha);
            if (currentAlpha <= minAlpha)
            {
                currentAlphaValue = AlphaValue.Growing;
            }
        }
        else if (currentAlphaValue == AlphaValue.Growing)
        {
            currentAlpha += tickTime;
            myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, currentAlpha);
            if (currentAlpha >= maxAlpha)
            {
                currentAlphaValue = AlphaValue.Shrinking;
            }
        }
    }
}
