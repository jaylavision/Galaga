using Unity.VisualScripting;
using UnityEngine;

public class seekingship : MonoBehaviour
{
    private GameObject player;
    public GameObject explosion;

    public float speed = 2f;

    public float maxDegrees = 10f;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = -(player.transform.position - transform.position);
        transform.rotation = Quaternion.Euler(Mathf.Rad2Deg * transform.rotation.x,
                                              Mathf.Rad2Deg * transform.rotation.y,
                                              Mathf.Clamp(Mathf.Rad2Deg * transform.rotation.z, -maxDegrees, maxDegrees));
        transform.Translate(-transform.up * speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<seekingship>() != null || collision.gameObject.GetComponent<bulletship>() != null)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player Bullet") || collision.gameObject.CompareTag("galagaPlayer"))
        {
            

            if (collision.gameObject.CompareTag("Player Bullet"))
                Destroy(collision.gameObject);

            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);

        }
    }
}
