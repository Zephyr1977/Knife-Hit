using UnityEngine;


public class KnifeManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _listSkins;

    [SerializeField] private GameObject _knif;

    private void Start()
    {
        CreateKnife();
    }

    public void CreateKnife() 
    {
        GameObject newKnife = Instantiate(_knif);
        newKnife.transform.position = new Vector2(0, -3);
        newKnife.GetComponent<SpriteRenderer>().sprite = _listSkins[PlayerPrefs.GetInt("Skin")];
        GetComponent<Throw>().SetKnife(newKnife);
    }

   
}
