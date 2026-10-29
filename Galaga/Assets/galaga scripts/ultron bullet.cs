using UnityEngine;

public class ultronbullet : MonoBehaviour
{
    public float speed = 6f;
    public GameObject explosion;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("galagaPlayer"))
        {
            collision.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);

            if (explosion != null)
            {
                GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(temp, 1.0f);
            }

            Destroy(gameObject);
        }
    }
}
