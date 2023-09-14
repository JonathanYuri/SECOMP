using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilhoSnake : MonoBehaviour
{
    Snake snake;
    public Vector3 destino;

    private void Awake()
    {
        destino = this.transform.position;
        snake = GetComponentInParent<Snake>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            snake.Crescer();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            snake.Destruir();
        }
    }

    public void SetarDestino(Vector3 destino)
    {
        destino.x = Mathf.RoundToInt(destino.x);
        destino.y = Mathf.RoundToInt(destino.y);
        this.destino = destino;
    }

    public bool ChegouNoDestino()
    {
        return this.transform.position == destino;
    }

    public void MoverParaODestino()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, destino, snake.velocidade * Time.deltaTime);
    }

    private void OnBecameInvisible() // saiu dos limites
    {
        snake.Destruir();
    }
}
