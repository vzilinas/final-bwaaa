﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExorcistItemController : MonoBehaviour {
    public GameObject hearthsText;
    public GameObject crossText;
    public GameObject crossImage;
    public GameObject portalReady;
    public GameObject portalNotReady;
    public void CrossImage()
    {
        crossImage.SetActive(true);
    }
    public void CrossText(bool active)
    {
        crossText.SetActive(active);
    }
    public void HeartsText(bool active)
    {
        hearthsText.SetActive(active);
    }
    public void PortalReadyText(bool active)
    {
        portalReady.SetActive(active);
    }
    public void PortalNotReadyText(bool active)
    {
        portalNotReady.SetActive(active);
    }
}
