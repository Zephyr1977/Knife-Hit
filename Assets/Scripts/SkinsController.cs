using UnityEngine.UI;
using UnityEngine;

public class SkinsController : MonoBehaviour
{
    [SerializeField] private GameObject _parentSkins;

    private void Start()
    {
        _parentSkins.transform.GetChild(PlayerPrefs.GetInt("Skin")).GetComponent<Button>().Select() ;
    }

    public void SetSkins(int number) 
    {
        PlayerPrefs.SetInt("Skin", number);
    }
}
