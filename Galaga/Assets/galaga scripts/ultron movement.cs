using UnityEngine;

public class ultronmovement : MonoBehaviour
{
    public float speed = 4f;
    public float frequency = 2f;
    public float magnitude = 3f;
    public GameObject bullet;
    public GameObject explosion;
    public float bullettimer = 0, bulletwait = 2.5f;

    private Vector3 pos;
    private int direction = 1;

    void Start()
    {
        pos = transform.position;

        if (transform.position.x > 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    void Update()
    {
        pos += transform.right * direction * speed * Time.deltaTime;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

        bullettimer += Time.deltaTime;
        if (bullettimer > bulletwait)
        {
            bullettimer = 0;
            if (bullet != null)
            {
                Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);
            }
        }

        if (transform.position.x < -12 || transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<seekingship>() != null ||
            collision.gameObject.GetComponent<bulletship>() != null ||
            collision.gameObject.GetComponent<ultronmovement>() != null ||
            collision.gameObject.GetComponent<enemybullet>() != null ||
            collision.gameObject.CompareTag("Enemy"))
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player Bullet") || collision.gameObject.CompareTag("galagaPlayer"))
        {
            if (collision.gameObject.CompareTag("Player Bullet"))
            {
                Destroy(collision.gameObject);
            }

            if (explosion != null)
            {
                GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(temp, 1.0f);
            }

            Destroy(gameObject);
        }
    }
}