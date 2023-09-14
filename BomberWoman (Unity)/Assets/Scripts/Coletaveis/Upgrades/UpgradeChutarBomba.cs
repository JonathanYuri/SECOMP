using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeChutarBomba : MonoBehaviour, IColetavel
{
    public bool Pego { get; private set; }

    public void Coletar(Personagem personagem)
    {
        personagem.chutarBomba = true;
        Pego = true;
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
