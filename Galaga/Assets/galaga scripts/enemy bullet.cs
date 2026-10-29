using UnityEngine;

public class enemybullet : MonoBehaviour
{
public float Speed = 6;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("galagaPlayer"))
        {
            Destroy(gameObject);
        }
    }
}
