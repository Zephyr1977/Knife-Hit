using UnityEngine;

[CreateAssetMenu(fileName = "Chance",menuName ="DataChance",order = 51)]
public class DataChance : ScriptableObject
{
    [Range(0,1)]
    [SerializeField] private float _chance = 0.25f;

    public float ChanceNumber 
    {
        get 
        {
            return _chance;
        }
    }
}