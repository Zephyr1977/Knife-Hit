using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static int _nowScore=0;

    public static void AddScore() 
    {
        _nowScore++;
        SetScore();
    }
    private static void SetScore() 
    {
        if (_nowScore > PlayerPrefs.GetInt("Score")) 
        {
            PlayerPrefs.SetInt("Score", _nowScore);
        }
    }
}
