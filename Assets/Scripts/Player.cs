using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity = 0.5f;
    public bool podeMover = true;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover) { 
        movimento(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Rotate();

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    void movimento(float x, float y)
    {
        Vector3 movement = new Vector3(x, y, 0) * velocity * Time.deltaTime;
        rb.velocity = movement;
    }

    void Rotate()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
