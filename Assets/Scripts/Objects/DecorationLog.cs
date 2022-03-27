using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationLog : MonoBehaviour
{
    private enum _directions 
    {
        leftDown,
        rightDown,
        leftUp,
        rightUp
    }

    [SerializeField]private _directions _enumDirections;

    private int _randomEnergy;

    private void Start()
    {
        _randomEnergy = Random.Range(30, 80);

        switch (_enumDirections) 
        {
            case _directions.leftDown: GetComponent<Rigidbody2D>().AddForce(new Vector2(-1,-1) * _randomEnergy, ForceMode2D.Impulse); break;
            case _directions.rightDown: GetComponent<Rigidbody2D>().AddForce(new Vector2(1, -1) * _randomEnergy, ForceMode2D.Impulse); break;
            case _directions.leftUp: GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * _randomEnergy, ForceMode2D.Impulse); break;
            case _directions.rightUp: GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1)* _randomEnergy, ForceMode2D.Impulse); break;
        }
   
    }
}
