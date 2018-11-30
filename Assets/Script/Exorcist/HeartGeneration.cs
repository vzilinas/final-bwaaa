using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGeneration : MonoBehaviour {
    public ExorcistController exorcist;
    public GameObject heart;
    private float spaceBetween;
    private int currentlyHearts;
    private Canvas canvas;
    private bool isUpdating = false;
    private bool heartsDisplayed = false;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
        if (!isUpdating)
        {
            isUpdating = true;
            if (!heartsDisplayed && exorcist.gotHearts)
            {
                spaceBetween = heart.GetComponent<Renderer>().bounds.size.x * 10;
                canvas = GetComponent<Canvas>();
                var rect = canvas.transform.GetComponent<RectTransform>();
                spaceBetween = heart.GetComponent<Renderer>().bounds.size.x * (rect.sizeDelta.x / 100);
                for (int i = 1; i < exorcist.maxHealth + 1; i++)
                {
                    var hearts = Instantiate(heart);
                    hearts.transform.SetParent(canvas.transform);
                    hearts.name = "heart" + i.ToString();
                    hearts.transform.localPosition = new Vector3((rect.sizeDelta.x / 15) - (rect.sizeDelta.x / 2) + (i * spaceBetween), (rect.sizeDelta.y / 15) - rect.sizeDelta.y / 2, 0);
                }
                currentlyHearts = exorcist.maxHealth;
                heartsDisplayed = true;
            }
            if (exorcist != null && exorcist.currentHealth < currentlyHearts)
            {
                Destroy(GameObject.Find("heart" + currentlyHearts));
                currentlyHearts--;
            }
            else if (exorcist.currentHealth > currentlyHearts)
            {
                if (canvas != null)
                {
                    var rect = canvas.transform.GetComponent<RectTransform>();
                    var hearths = Instantiate(heart);
                    hearths.transform.SetParent(canvas.transform);
                    hearths.name = "heart" + exorcist.currentHealth.ToString();
                    hearths.transform.localPosition = new Vector3((rect.sizeDelta.x / 15) - (rect.sizeDelta.x / 2) + (exorcist.currentHealth * spaceBetween), (rect.sizeDelta.y / 15) - rect.sizeDelta.y / 2, 0);
                    currentlyHearts++;
                }
            }
            isUpdating = false;
        }
    }
}
