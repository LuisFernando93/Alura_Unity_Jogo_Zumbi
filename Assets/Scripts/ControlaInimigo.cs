using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float Velocidade;
    private Animator animatorInimigo;
    private MovimentaPersonagem movimentaInimigo;

    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

        animatorInimigo = GetComponent<Animator>();
        movimentaInimigo = GetComponent<MovimentaPersonagem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        movimentaInimigo.Rotacionar(direcao);

        if (distancia > 2.5)
        {

            movimentaInimigo.Movimentar(direcao, Velocidade);

            animatorInimigo.SetBool("Atacando", false);
        }
        else
        {
            animatorInimigo.SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(10, 20);
        Jogador.GetComponent<Controla_Jogador>().TomarDano(dano);
    }
}
