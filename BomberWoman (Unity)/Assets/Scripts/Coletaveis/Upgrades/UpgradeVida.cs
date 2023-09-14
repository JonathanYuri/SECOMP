using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVida : MonoBehaviour, IColetavel
{
    public bool Pego { get; private set; }

    public void Coletar(Personagem personagem)
    {
        if (personagem.vida < 2)
        {
            personagem.vida++;
        }
        Pego = true;
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
