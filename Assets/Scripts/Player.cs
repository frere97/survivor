using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{





    /// ///////////////////////////////////////////////////////////////////////////////////////////


    public float velocity = 0.5f;
    public bool podeMover = true;
    public Rigidbody2D rb;
    public static Player Instance;
    public int vida = 3;
    public int VidaMax = 3;
    public bool escudoAtivo = false;
    public LayerMask LM_normal, LM_levouDano;
    public Color CorNormal, CorLevouDano;
    public int ContadorEskudo = 0;

    [SerializeField]
    public eskudo eskudo;


    /// ///////////////////////////////////////////////////////////////////////////////////////////





    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        rb = GetComponent<Rigidbody2D>();

        Time.timeScale = 1f;
    }

    private void Start()
    {
        CorNormal = GetComponent<SpriteRenderer>().color;
    }








    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    void Update()
    {
        if (podeMover)
        {
            movimento(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        Rotate();

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
        if (Input.GetKeyDown(KeyCode.F) && ContadorEskudo >= 10)
        {
            this.eskudo.Ativa();
            ContadorEskudo -= 10;
        }
    }
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////







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

    public IEnumerator LevaDano(int dano)
    {
        vida -= dano;
        GetComponent<Collider2D>().excludeLayers = LM_levouDano;
        GetComponent<SpriteRenderer>().color = CorLevouDano;
        AtualizaVida();
        ChecaSeMorre();

        yield return new WaitForSeconds(1f);
        GetComponent<Collider2D>().excludeLayers = LM_normal;
        GetComponent<SpriteRenderer>().color = CorNormal;
    }

    public void AtualizaVida()
    {
        UI.Instance.AtualizaVidaPlayer(vida, VidaMax);
    }

    void ChecaSeMorre()
    {
        if (vida <= 0)
        {
            Time.timeScale = 0.1f;
            UI.Instance.LigaTelaDeMorte();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "eskudo")
        {
            Physics2D.IgnoreCollision(eskudo.GetComponent<CircleCollider2D>(), GetComponent<Collider2D>());
        }
    }
}
