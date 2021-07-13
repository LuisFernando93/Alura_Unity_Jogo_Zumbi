using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private Controla_Jogador scriptControlaJogador;
    public Slider SliderVidaJogador;


    // Start is called before the first frame update
    void Start()
    {
        scriptControlaJogador = GameObject.FindGameObjectWithTag("Jogador")
                                .GetComponent<Controla_Jogador>();
        SliderVidaJogador.maxValue = scriptControlaJogador.Vida;
        AtualizarSliderVidaJogador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptControlaJogador.Vida;
    }
}
