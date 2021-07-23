using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controla_Jogador : MonoBehaviour 
{

    public float velocidadeDeMovimento;
    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    private AnimacaoPersonagem animacaoJogador;
    public int Vida;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDano;
    private MovimentaJogador movimentaJogador;

    // Start is called before the first frame update
    void Start() 
    {
        Time.timeScale = 1;
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        movimentaJogador = GetComponent<MovimentaJogador>();
    }

    // Update is called once per frame
    void Update() 
    { 
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);

        animacaoJogador.AnimarMovimento(direcao);

        if(Vida <= 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Game");
            }
        }

    }



    void FixedUpdate()
    {
        movimentaJogador.Movimentar(direcao, velocidadeDeMovimento);

        movimentaJogador.RotacionarJogador(MascaraChao);
    }

    public void TomarDano(int dano)
    {
        Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDano);
        if (Vida <= 0)
        {
            Time.timeScale = 0;
            TextoGameOver.SetActive(true);
        }
    }

}
