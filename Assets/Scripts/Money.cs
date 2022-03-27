using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static int _money = 0;

    private static UIController _cotrollerUI;

    private void Start()
    {
        _money = PlayerPrefs.GetInt("Money");

        _cotrollerUI = FindObjectOfType<UIController>();
        _cotrollerUI.UpdateText();
    }

    public static int AddMoney 
    {
        
        set 
        {
            _money+= value;
            SaveMoney();
            _cotrollerUI.UpdateText();
        }
     
    }

    public void AddMoneyButton() 
    {
        AddMoney=1;
    }

    public static int GetMoney 
    {
        get 
        {
            return _money;
        }
    }

    private static void SaveMoney() 
    {
        PlayerPrefs.SetInt("Money", _money);
    }
}
