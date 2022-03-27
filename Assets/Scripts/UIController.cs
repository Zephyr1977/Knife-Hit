using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private bool _isGeneralMenu;

    [SerializeField] private Text _moneyText;

    [SerializeField] private GameObject _knifeImage;
    [SerializeField] private Transform _knifeParent;

    private List<GameObject> _knifeList = new List<GameObject>();
    private int _numberDecrease;

    private void Start()
    {
        if (_isGeneralMenu) 
        {
            GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();
        }
        UpdateText();

    }
    public void UpdateText() 
    {
        _moneyText.text = Money.GetMoney.ToString();
    }

    public void CreateNewList(GameObject logManager) 
    {
        ClearList();
        GameObject log = logManager.GetComponent<LogManager>().GetNowLog();
        int num = log.GetComponentInChildren<Log>().GetHealth();

        for (int i = 0; i < num; i++) 
        {
            
            GameObject newKnife = Instantiate(_knifeImage, _knifeParent);
            _knifeList.Add(newKnife);

        }
    }

    public void DecreaseKnife() 
    {
        if (_numberDecrease < _knifeList.Count) 
        {
            _knifeList[_numberDecrease].GetComponent<Image>().color = new Color(0, 0, 0);
            _numberDecrease++;
        }
       
    }

    private void ClearList() 
    {
        foreach (GameObject obj in _knifeList) 
        {
            Destroy(obj);
        }
        _numberDecrease = 0;
        _knifeList.Clear();
    }




}
