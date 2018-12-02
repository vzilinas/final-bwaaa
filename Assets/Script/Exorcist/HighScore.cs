using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static HighScore instance = null;
    public static HighScore Instance
    {
        get { return instance; }
    }
	public static int score;
}
