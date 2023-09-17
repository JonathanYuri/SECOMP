using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 movement;
    public float velocidade;

    SpawnarCerejas spawnarCerejas;

    [SerializeField] List<FilhoSnake> filhos;
    [SerializeField] GameObject body;

    bool crescer = false;

    private void Awake()
    {
        movement = Vector3.right;
    }

    private void Start()
    {
        spawnarCerejas = FindObjectOfType<SpawnarCerejas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Vector2.Angle(filhos[0].destino - filhos[0].transform.position, Vector3.up) == 90.0f)
            {
                movement = Vector3.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (Vector2.Angle(filhos[0].destino - filhos[0].transform.position, Vector3.down) == 90.0f)
            {
                movement = Vector3.down;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Vector2.Angle(filhos[0].destino - filhos[0].transform.position, Vector3.left) == 90.0f)
            {
                movement = Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Vector2.Angle(filhos[0].destino - filhos[0].transform.position, Vector3.right) == 90.0f)
            {
                movement = Vector3.right;
            }
        }

        for (int i = filhos.Count - 1; i > 0; i--)
        {
            if (filhos[i].ChegouNoDestino())
            {
                filhos[i].SetarDestino(filhos[i - 1].transform.position);
            }
        }

        if (filhos[0].ChegouNoDestino())
        {
            if (crescer)
            {
                CrescerInstantaneamente();
            }
            filhos[0].SetarDestino(filhos[0].transform.position + movement);
        }

        foreach (var filho in filhos)
        {
            filho.MoverParaODestino();
        }
    }

    void CrescerInstantaneamente()
    {
        GameObject gameObject = Instantiate(body, filhos[^1].transform.position - filhos[^2].transform.position + filhos[^1].transform.position, Quaternion.identity, this.transform);
        FilhoSnake filho = gameObject.GetComponent<FilhoSnake>();
        filhos.Add(filho);
        filho.SetarDestino(filhos[^2].transform.position);
        spawnarCerejas.SpawnarCereja();
        crescer = false;
    }

    public void Crescer()
    {
        crescer = true;
        //Debug.LogError("");
    }

    public void Destruir()
    {
        TrocarDeCena.Instance.SetScore(filhos.Count - 2);
        TrocarDeCena.ChangeScene("Menu");
        Destroy(gameObject);
    }

    public List<Vector3> PosicoesDaCobra()
    {
        List<Vector3> list = new();
        for (int i = 0; i < filhos.Count; i++)
        {
            list.Add(filhos[i].transform.position);
        }
        return list;
    }
}
