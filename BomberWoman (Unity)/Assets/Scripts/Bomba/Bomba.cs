using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] GameObject fogoHorizontal;
    [SerializeField] GameObject fogoVertical;
    [SerializeField] GameObject fogoMeio;

    GerenciadorDeObstaculos gerenciadorDeObstaculos;

    public Personagem personagem;
    public Vector3 movement;
    Rigidbody2D rb;

    [SerializeField]
    float velocity = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        gerenciadorDeObstaculos = FindObjectOfType<GerenciadorDeObstaculos>();
    }

    private void FixedUpdate()
    {
        //Debug.Log("MOVEMENT: " + movement);
        rb.MovePosition(this.transform.position + (movement * Time.fixedDeltaTime * velocity));
    }

    public void Explodir()
    {
        Instantiate(fogoMeio, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.identity);

        for (float i = this.transform.position.x + 1; i <= this.transform.position.x + personagem.range; i++)
        {
            Obstaculo obstaculo = gerenciadorDeObstaculos.TemUmObstaculoNaPosicao(Mathf.RoundToInt(i), Mathf.RoundToInt(this.transform.position.y));
            if (obstaculo != null)
            {
                obstaculo.Destruir();
                break;
            }

            Instantiate(fogoHorizontal, new Vector3(i, this.transform.position.y), Quaternion.identity);
        }

        for (float i = this.transform.position.x - 1; i >= this.transform.position.x - personagem.range; i--)
        {
            Obstaculo obstaculo = gerenciadorDeObstaculos.TemUmObstaculoNaPosicao(Mathf.RoundToInt(i), Mathf.RoundToInt(this.transform.position.y));
            if (obstaculo != null)
            {
                obstaculo.Destruir();
                break;
            }

            Instantiate(fogoHorizontal, new Vector3(i, this.transform.position.y), Quaternion.identity);
        }

        for (float j = this.transform.position.y + 1; j <= this.transform.position.y + personagem.range; j++)
        {
            Obstaculo obstaculo = gerenciadorDeObstaculos.TemUmObstaculoNaPosicao(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(j));
            if (obstaculo != null)
            {
                obstaculo.Destruir();
                break;
            }

            Instantiate(fogoVertical, new Vector3(this.transform.position.x, j), Quaternion.identity);
        }

        for (float j = this.transform.position.y - 1; j >= this.transform.position.y - personagem.range; j--)
        {
            Obstaculo obstaculo = gerenciadorDeObstaculos.TemUmObstaculoNaPosicao(Mathf.RoundToInt(this.transform.position.x), Mathf.RoundToInt(j));
            if (obstaculo != null)
            {
                obstaculo.Destruir();
                break;
            }

            Instantiate(fogoVertical, new Vector3(this.transform.position.x, j), Quaternion.identity);
        }

        personagem.bombas++;
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            movement = Vector3.zero;
        }
    }
}
