using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVelocidade : MonoBehaviour, IColetavel
{
    public bool Pego { get; private set; }
    [SerializeField] float quantidadeMudar = 0.5f;

    public void Coletar(Personagem personagem)
    {
        personagem.velocity += quantidadeMudar;
        Pego = true;
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
