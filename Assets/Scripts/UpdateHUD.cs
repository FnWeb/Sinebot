using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHUD : MonoBehaviour
{
    public RectTransform crosshair;
    void Update()
    {
        if (PlayerTarget.isInteractable)
        {
            crosshair.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GlobalConstants.crosshairSizeSelected);
            crosshair.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GlobalConstants.crosshairSizeSelected);
        }
        else
        {
            crosshair.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, GlobalConstants.crosshairSizeDefault);
            crosshair.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GlobalConstants.crosshairSizeDefault);
        }
    }
}
