using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{


    [Range(1,25)]
    [SerializeField] private int _health;
    [Space]
    [SerializeField] private DataChance _chance;
    [Space]
    [Header("Prefabs")]
    [SerializeField] private GameObject _apple;
    [SerializeField] private GameObject _knife;
    [Space]
    [SerializeField] private GameObject _listDecorationLog;


    private List<Vector2> _listVector = new List<Vector2>();
    private List<Quaternion> _listQuaternoin = new List<Quaternion>();
    private int _startIndex;

    private UIController _controllerUI;



    private void Start()
    {
        _controllerUI = FindObjectOfType<UIController>();

        if (Random.Range(0f, 1f) <= _chance.ChanceNumber) 
        {
            CreateDecoration(_apple,1);
            _startIndex = 1;
        }
        CreateDecoration(_knife, Random.Range(1, 4));
        CreateListCorrect();
    }


    private void SeachMin(GameObject knife) 
    {
        float _difference = 10;
        int indexMinVector=0;

        for (int i = 0;i<_listVector.Count;i++) 
        {
            if (Vector2.Distance((Vector2)knife.transform.localPosition, _listVector[i]) < _difference) 
            {
                _difference = Vector2.Distance((Vector2)knife.transform.localPosition, _listVector[i]);
                Debug.Log("—ходство:" + (Vector2)knife.transform.localPosition + " | " + _listVector[i] + " | " + _difference);
                indexMinVector = i;
            }
        }
        knife.transform.localPosition = _listVector[indexMinVector];
        knife.transform.localRotation = _listQuaternoin[indexMinVector];


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife")) 
        {
            _controllerUI.DecreaseKnife();
            VibrationController.VibrationLog();
        
            FindObjectOfType<SoundEffects>().PlaySound(0);

            Effects.PlayParticle();

            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            collision.transform.SetParent(gameObject.transform);
            SeachMin(collision.gameObject);
            Camera.main.GetComponent<KnifeManager>().CreateKnife();
            Decrease();

            transform.GetComponentInParent<Animator>().SetTrigger("Anim");
        }
    }

    private void CreateListCorrect() 
    {
        Vector2 center = transform.localPosition;
        for (int i = 0; i < 18; i++)
        {
            Vector2 pos = RandomCircle(center, 0.6f, i * 20);
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, center - pos);
            _listQuaternoin.Add(rot);
            _listVector.Add (pos);


        }
    }


    private  void CreateDecoration(GameObject decoration,int number)
    {
        Vector2 center = transform.localPosition;
        for (int i = _startIndex; i < number; i++)
        {
            Vector2 pos = RandomCircle(center, 0.6f, i * 90);
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, center - pos);
            GameObject newDecoration = Instantiate(decoration);

            newDecoration.transform.SetParent(transform);

            newDecoration.transform.localPosition = pos;
            newDecoration.transform.localRotation = rot;


        }
    }

    private Vector3 RandomCircle(Vector2 center, float radius,int a)
    {
        float ang = a;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

    private void Decrease() 
    {
        if (_health > 1)
        {
            _health--;
        }
        else 
        {
            StartCoroutine(DestroyLog());
            Score.AddScore();
        }
    }

  

    private IEnumerator DestroyLog() 
    {
       transform.parent.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        Throw.StopThrow(true);
        _listDecorationLog.SetActive(true);
        DestroyDecoration();
        yield return new WaitForSeconds(1);

        Camera.main.GetComponent<LogManager>().CreateNewLog();
        Destroy( transform.root.gameObject);

    }

    private void DestroyDecoration() 
    {
        foreach (Transform obj in GetComponentsInChildren<Transform>()) 
        {
            if(!obj.GetComponent<Log>())
            Destroy(obj.gameObject);
        }
    }

    public int GetHealth() 
    {
        return _health;
    }
}
