using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controla_Jogador : MonoBehaviour, IMatavel
{

    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    private AnimacaoPersonagem animacaoJogador;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDano;
    private MovimentaJogador movimentaJogador;
    public Status statusJogador;

    // Start is called before the first frame update
    void Start() 
    {
        Time.timeScale = 1;
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        movimentaJogador = GetComponent<MovimentaJogador>();
        statusJogador = GetComponent<Status>();
    }

    // Update is called once per frame
    void Update() 
    { 
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);

        animacaoJogador.AnimarMovimento(direcao);

        if(statusJogador.Vida <= 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }



    void FixedUpdate()
    {
        movimentaJogador.Movimentar(direcao, statusJogador.Velocidade);

        movimentaJogador.RotacionarJogador(MascaraChao);
    }

    public void TomarDano(int dano)
    {
        statusJogador.Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDano);
        if (statusJogador.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Time.timeScale = 0;
        TextoGameOver.SetActive(true);
    }
}
