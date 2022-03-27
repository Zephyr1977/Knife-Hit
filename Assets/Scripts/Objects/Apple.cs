using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private GameObject[] _listHalf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife")) 
        {
           
          Money.AddMoney =1;
            _listHalf[0].SetActive(true);
            _listHalf[1].SetActive(true);

            GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);

            Destroy(gameObject.GetComponent<CircleCollider2D>());
            Destroy(gameObject,2);
        }
    }
}
