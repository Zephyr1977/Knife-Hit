using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _listLog;

    private UIController _controllerUI;

    private int _numberLog;
    private void Start()
    {
        _controllerUI = FindObjectOfType<UIController>();
        CreateNewLog();
    }

    private void RepeatLog() 
    {
        if (_numberLog >= _listLog.Length) 
        {
            _numberLog = 0;
        }
    }
    public void CreateNewLog() 
    {
        RepeatLog();

        Throw.StopThrow(false);
        GameObject newLog = Instantiate(_listLog[_numberLog]);

        newLog.transform.position = new Vector3(0, 2, -11);
        _controllerUI.CreateNewList(gameObject);
        _numberLog++;
    }

    public GameObject GetNowLog() 
    {
        return _listLog[_numberLog];
    }

    
}
