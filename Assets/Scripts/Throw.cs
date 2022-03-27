using UnityEngine;
using System.Collections;

public class Throw : MonoBehaviour
{
    [Header("Интервал")]
    [Range(0f, 10f)]
    [SerializeField] private float _delay;


    [SerializeField] private Rigidbody2D _knife;



    private static bool IsStop=false;

    private float _timer;

 

    public static void  StopThrow(bool value) 
    {
        IsStop = value;
    }

    public void Tap() 
    {
        ThrowKnife();
    }

    public void SetKnife(GameObject knife) 
    {
        _knife = knife.GetComponent<Rigidbody2D>();
    }

    private void ThrowKnife() 
    {
        if (!IsStop & _timer<=0) 
        {
            _timer = _delay;
            _knife.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
            _knife.gravityScale = 1;

            StartCoroutine(StartTimer());
        }
   
    }

    private IEnumerator StartTimer()
    {
        while (_timer > 0) 
        {
            _timer -= 1 * Time.deltaTime * 2;
            yield return null;
        }
 
    }
}
