using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    string viradoPara;
    
    [SerializeField] float velocity;

    List<Transform> filhos;

    [SerializeField] GameObject gameobject;

    private void Awake()
    {
        viradoPara = "direita";

        filhos = new List<Transform>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            filhos.Add(this.transform.GetChild(i));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            viradoPara = "cima";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            viradoPara = "baixo";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            viradoPara = "esquerda";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            viradoPara = "direita";
        }
    }

    public void Move()
    {
        Debug.Log(filhos.Count);
        for (int i = filhos.Count - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                if (viradoPara.Equals("direita"))
                {
                    filhos[i].Translate(new Vector2(velocity, 0));
                }
                else if (viradoPara.Equals("esquerda"))
                {
                    filhos[i].Translate(new Vector2(-velocity, 0));
                }
                else if (viradoPara.Equals("cima"))
                {
                    filhos[i].Translate(new Vector2(0, velocity));
                }
                else if (viradoPara.Equals("baixo"))
                {
                    filhos[i].Translate(new Vector2(0, -velocity));
                }
            }
            else
            {
                filhos[i].Translate(filhos[i - 1].transform.position - filhos[i].transform.position);
            }
        }
    }

    public void AddFilho()
    {
        GameObject filho;
        filho = Instantiate(gameobject, (filhos[^1].transform.position - filhos[^2].transform.position) + filhos[^1].transform.position, Quaternion.identity, this.transform);

        /*
        Debug.Log("2: " + filhos[^2].transform.position);
        Debug.Log("1: " + filhos[^1].transform.position);
        Debug.Log("resultado: " + filho.transform.position);
        */

        filhos.Add(filho.transform);
    }
}
