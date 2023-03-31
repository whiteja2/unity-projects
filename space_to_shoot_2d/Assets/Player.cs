using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float speed = 7f;
    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float bulletSpeed = 10f;
    private float cooldown = 0.5f;
    private float nextFire = 0f;
    private int bulletCount = 0;
    private int bulletMax = 6;

    void Start () {
      rb2d = GetComponent<Rigidbody2D> ();
    }
	
    void Update () {
      UpdateMotion();
      ProcessBulletSpwan();
      if (Input.GetKey("r")) {
        reload();
      }
    }

    private void UpdateMotion() {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        transform.position = pos;
    }
    
    private void ProcessBulletSpwan() {
      if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0)) && Time.time > nextFire && bulletCount < bulletMax) {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
        re.velocity = firePoint.up * bulletSpeed;
        bulletCount++;
        nextFire = Time.time + cooldown;
      }
    }

    private void reload() {
      bulletCount = 0;
    }
}
