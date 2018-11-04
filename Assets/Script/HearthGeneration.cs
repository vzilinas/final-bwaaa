using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthGeneration : MonoBehaviour {
    public ExorcistController exorcist;
    public GameObject hearth;
    public float initialX;
    public float initialY;
    public float spaceBetween;
    private int currentlyHearts;
    private Canvas canvas;
    private bool isUpdating = false;
    // Use this for initialization
    void Start () {
        canvas = GetComponent<Canvas>();
        var rect = canvas.transform.GetComponent<RectTransform>();
        for (int i= 1; i < exorcist.maxHealth+1; i++)
        {
            var hearths = Instantiate(hearth);
            hearths.transform.SetParent(canvas.transform);
            hearths.name = "heart" + i.ToString();
            hearths.transform.localPosition = new Vector3(150 - (rect.sizeDelta.x / 2) + (i * spaceBetween), 80 - rect.sizeDelta.y / 2, 0);
        }
        currentlyHearts = exorcist.maxHealth;
    }

    // Update is called once per frame
    void Update () {
        if (!isUpdating)
        {
            isUpdating = true;
            if (exorcist.currentHealth < currentlyHearts)
            {
                Destroy(GameObject.Find("heart" + currentlyHearts));
                currentlyHearts--;
            }
            else if (exorcist.currentHealth > currentlyHearts)
            {
                var rect = canvas.transform.GetComponent<RectTransform>();
                var hearths = Instantiate(hearth);
                hearths.transform.SetParent(canvas.transform);
                hearths.name = "heart" + exorcist.currentHealth.ToString();
                hearths.transform.localPosition = new Vector3(150 - (rect.sizeDelta.x / 2) + (exorcist.currentHealth * spaceBetween), 80 - rect.sizeDelta.y / 2, 0);
                currentlyHearts++;
            }
            isUpdating = false;
        }
    }
}
