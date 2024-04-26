using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public LayerMask LM_normal, LM_levouDano, Invencivel;
    public Color CorNormal, CorLevouDano, Dashando;
    public int ContadorEskudo = 0;
    public bool possuiArma;

    [SerializeField]
    public eskudo eskudo;

    public Image BarraEstamina;

    public float Estamina, MaxEstamina;
    public float CustoDash;
    public float quantidadecarga;

    private Coroutine Recarga;

    Vector3 moverDirecao;

    [Header("Configurações Dash")]
    [SerializeField] float dashVelocidade = 1f;
    [SerializeField] float dashDuracao = 1f;
    [SerializeField] float dashRecarga = 1f;
    private bool estaDashando;
    bool podeDashar;
    public bool invencivelDuranteDash = true;

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

        podeDashar = true;
    }








    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);

        if (estaDashando)
        {
            return;
        }
            // Floats para o Movimento Individual no plano 2D
            float movimentoX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
            float movimentoY = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            Rotate();
           
            moverDirecao = new Vector2(movimentoX, movimentoY).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && podeDashar && Estamina >= CustoDash)
            {
                Estamina -= CustoDash;
                if (Estamina < 0) Estamina = 0;
                BarraEstamina.fillAmount = Estamina / MaxEstamina;
                StartCoroutine(Dash());

                if (Recarga != null) StopCoroutine(Recarga);
                Recarga = StartCoroutine(recargaEstamina());
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

    private void FixedUpdate()
    {
        if (estaDashando)
        {
            return;
        }

        rb.velocity = new Vector2(moverDirecao.x * velocity, moverDirecao.y * velocity);
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

    private IEnumerator recargaEstamina()
    {

        yield return new WaitForSeconds(1f);

        while (Estamina < MaxEstamina)
        {
            Estamina += CustoDash / 3F;
            if (Estamina > MaxEstamina) Estamina = MaxEstamina;
            BarraEstamina.fillAmount = Estamina / MaxEstamina;
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "eskudo")
        {
            Physics2D.IgnoreCollision(eskudo.GetComponent<CircleCollider2D>(), GetComponent<Collider2D>());
        }
    }

    private IEnumerator Dash()
    {

        podeDashar = false;
        estaDashando = true;
        rb.velocity = new Vector2(moverDirecao.x * dashVelocidade, moverDirecao.y * dashVelocidade);

        if (estaDashando)
        {
            GetComponent<Collider2D>().excludeLayers = Invencivel;
            GetComponent<SpriteRenderer>().color = Dashando;
            yield return new WaitForSeconds(dashDuracao);
            GetComponent<Collider2D>().excludeLayers = LM_normal;
            GetComponent<SpriteRenderer>().color = CorNormal;
        }

        yield return new WaitForSeconds(dashDuracao);
        estaDashando = false;

        yield return new WaitForSeconds(dashRecarga);
        podeDashar = true;

    }
}
