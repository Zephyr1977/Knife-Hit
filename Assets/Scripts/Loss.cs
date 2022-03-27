using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loss : MonoBehaviour
{
    [SerializeField] private GameObject _lossPanel;

    public  void ActivePanel() 
    {
        _lossPanel.SetActive(true);
    }
}
