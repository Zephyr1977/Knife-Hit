using UnityEngine;

public class Knife : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife")) 
        {
            VibrationController.VibrationLog();

            Rigidbody2D knifeRigiBody = collision.GetComponent<Rigidbody2D>();
            FindObjectOfType<SoundEffects>().PlaySound(1);
            knifeRigiBody.constraints = RigidbodyConstraints2D.None;
            knifeRigiBody.AddForce(new Vector2(Random.Range(-1, 2), -1) * 10, ForceMode2D.Impulse);
            knifeRigiBody.gravityScale = 0;
            knifeRigiBody.AddTorque(5*Mathf.Deg2Rad * collision.GetComponent<Rigidbody2D>().inertia,ForceMode2D.Impulse);
            Camera.main.GetComponent<Loss>().ActivePanel();
        }

    }
}
