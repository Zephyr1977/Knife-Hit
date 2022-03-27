using System.Collections;
using UnityEngine;

public class LogRotation : MonoBehaviour
{

    [SerializeField] private Scenario[] _scenarios;

    [Range(0.1f,10f)]
    [SerializeField] private float _speed = 0.2f;

    private float _speedNow;

    private int _numberScenario;
    private int _direction = 1;



    private void Start()
    {
        _speedNow = _speed;
        NextScenario();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _direction * _speed * Time.deltaTime*50));
    }
    private void NextScenario() 
    {
        if (_numberScenario >= _scenarios.Length) 
        {
            _numberScenario = 0;
        }



        Debug.Log("NextScenario: "+_numberScenario);

        switch (_scenarios[_numberScenario]._state) 
        {
            case Scenario._directionEnum.clockwise : StartCoroutine(Rotation(_scenarios[_numberScenario]._timeState,-1)); _numberScenario++; break;
            case Scenario._directionEnum.counterclockwise: StartCoroutine(Rotation(_scenarios[_numberScenario]._timeState, 1)); _numberScenario++; break;
            case Scenario._directionEnum.delay: StartCoroutine(DecreaseDelay(_scenarios[_numberScenario]._timeState)); _numberScenario++; break;
        }
      
    }




    IEnumerator Rotation(float time,int direction) 
    {
        _direction = direction;
        yield return new WaitForSeconds(time);
        NextScenario();
    }


    IEnumerator DecreaseDelay(float timeDelay) 
    {
        Debug.Log("Start Decrease");

        while (_speed > 0) 
        {
            _speed -= 1 * Time.deltaTime*3;
            yield return null;
        }
        yield return new WaitForSeconds(timeDelay);
        StartCoroutine(IncreaseDelay());
    }
    IEnumerator IncreaseDelay()
    {
        NextScenario();
        Debug.Log("Start Increase");
        while (_speed < _speedNow)
        {
            _speed += 1 * Time.deltaTime*3;
            yield return null;
        }
 

    }

}
[System.Serializable]
public class Scenario 
{
    [SerializeField]public enum _directionEnum
    {
        clockwise,
        counterclockwise,
        delay
    }
    [Header("Состояние")]
    public _directionEnum _state;
    [Header("Длительность состояния")]
    public float _timeState;
}


