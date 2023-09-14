using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    [SerializeField]
    float tempoPraSumir = 1f;

    private void Awake()
    {
        StartCoroutine(Sumir());
    }

    IEnumerator Sumir()
    {
        yield return new WaitForSeconds(tempoPraSumir);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // dar dano
            Personagem personagem = collision.gameObject.GetComponent<Personagem>();
            personagem.LevarDano();
        }
        else if (collision.GetComponent<IColetavel>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
