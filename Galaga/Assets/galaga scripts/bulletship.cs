using UnityEngine;

public class bulletship : MonoBehaviour
{
    public float speed = 3;
    public GameObject bullet;
    public GameObject explosion; 

    public float bullettimer = 0, bulletwait = 3;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);

        bullettimer += Time.deltaTime;
        if (bullettimer > bulletwait)
        {
            bullettimer = 0;
            Instantiate(bullet, transform.position - new Vector3(0, .5f, 0), Quaternion.identity);

        }
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<seekingship>() != null ||
            collision.gameObject.GetComponent<bulletship>() != null ||
            collision.gameObject.GetComponent<enemybullet>() != null)
        {
            return;
        }


        if (collision.gameObject.CompareTag("Player Bullet") || collision.gameObject.CompareTag("galagaPlayer"))
        
            if (collision.gameObject.CompareTag("Player Bullet"))
                Destroy(collision.gameObject);

            GameObject temp= Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);

        }
    }
