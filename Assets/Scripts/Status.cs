using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaInicial = 100;
    [HideInInspector]
    public int Vida;
    public int Velocidade = 10;

    private void Start()
    {
        Vida = VidaInicial;
    }
}
