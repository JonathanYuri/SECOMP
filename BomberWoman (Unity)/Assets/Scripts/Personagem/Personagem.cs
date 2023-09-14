using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector3 movement;
    public float velocity = 3f;

    public Vector2 olhandoPara;
    [SerializeField] GameObject bomba;

    public int bombas = 1;
    public int range = 1;
    public bool chutarBomba = false;
    public int vida = 1;

    bool invencivel = false;
    [SerializeField]
    float tempoInvencivel = 1.5f;

    public KeyCode upArrow;
    public KeyCode downArrow;
    public KeyCode leftArrow;
    public KeyCode rightArrow;
    public KeyCode colocarBomba;

    SpriteRenderer spriteRenderer;
    GerenciadorDePersonagens gerenciadorDePersonagens;

    private void Awake()
    {
        olhandoPara = new Vector3(0, -1);
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gerenciadorDePersonagens = FindObjectOfType<GerenciadorDePersonagens>();
    }

    private void Update()
    {
        int horizontal = 0;
        int vertical = 0;
        if (Input.GetKey(upArrow))
        {
            vertical = 1;
        }
        else if (Input.GetKey(downArrow))
        {
            vertical = -1;
        }

        if (Input.GetKey(leftArrow))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(rightArrow))
        {
            horizontal = 1;
        }

        movement = new Vector3(horizontal, vertical);

        if (movement != Vector3.zero)
        {
            olhandoPara = movement;
        }

        if (Input.GetKeyDown(colocarBomba) && bombas > 0)
        {
            // spawnar bomba
            GameObject b = Instantiate(bomba,
                                new Vector3(
                                    Mathf.RoundToInt(this.transform.position.x),
                                    Mathf.RoundToInt(this.transform.position.y),
                                    Mathf.RoundToInt(this.transform.position.z)
                                ),
                                Quaternion.identity);
            b.GetComponent<Bomba>().personagem = this;
            bombas--;
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), b.GetComponent<Collider2D>(), true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomba") && chutarBomba)
        {
            Bomba bomba = collision.gameObject.GetComponent<Bomba>();
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                bomba.movement = Vector3.right * movement.x;
            }
            else
            {
                bomba.movement = Vector3.up * movement.y;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomba"))
        {
            if (Physics2D.GetIgnoreCollision(this.GetComponent<Collider2D>(), collision))
            {
                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision, false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IColetavel>(out var coletavel))
        {
            if (!coletavel.Pego)
            {
                coletavel.Coletar(this);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(this.transform.position + Time.fixedDeltaTime * velocity * movement);
    }

    public void LevarDano()
    {
        if (invencivel)
        {
            return;
        }

        vida -= 1;
        if (vida <= 0)
        {
            gerenciadorDePersonagens.MatarPersonagem(this.gameObject);
        }
        else
        {
            invencivel = true;
            StartCoroutine(TirarInvencibilidade());
        }
    }

    IEnumerator TirarInvencibilidade()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        yield return new WaitForSeconds(tempoInvencivel / 3f);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        yield return new WaitForSeconds(tempoInvencivel / 3f);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
        yield return new WaitForSeconds(tempoInvencivel / 3f);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
        invencivel = false;
    }
}
