using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadBuffsDebuffs : MonoBehaviour
{
    public void DisplayText()
    {
        gameObject.GetComponent<Text>().text = BuffDebuff.GetDisplayText();
    }
    // Use this for initialization
    void Start()
    {
        DisplayText();
    }
}
