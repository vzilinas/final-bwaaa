using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour {

    private static BuffManager instance = null;
    public static BuffManager Instance
    {
        get { return instance; }
    }
    public static bool visibilityDebuff;
    public static bool highScoreBuff;
    public static bool movementBuff;
    public static bool healthBuff;
    public static bool highScoreDebuff;
    public static bool monsterHealthDebuff;
    public static bool playerHealthDebuff;
    public static bool playerMovementDebuff;
    public static bool monsterMovemetnBuff;
    public static int buffCounter;
    public static int debuffCounter;
}
