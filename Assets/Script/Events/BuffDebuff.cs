using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDebuff : MonoBehaviour {

    public static BuffDebuff instance = null;
    public static BuffDebuff Instance
    {
        get { return instance; }
    }
    public static string text = "";
    public static Dictionary<string, int> effects = new Dictionary<string, int>();

    public static string GetDisplayText()
    {
        var buffsDebuffs = "";
        if (effects.Count != 0)
        {
            foreach (var item in effects)
            {
                buffsDebuffs += (item.Key + "  " + item.Value + "\n");
            }
        }
        return buffsDebuffs;
    }

    public static void UpdateText (string newText) {
        Debug.Log(newText);
        if (effects.ContainsKey(newText))
        {
            effects[newText] += 1;
        }
        else {
            effects.Add(newText, 1);
        }
        text += newText;
        GameObject.Find("BuffDebuff").GetComponent<LoadBuffsDebuffs>().DisplayText();
    }
}
