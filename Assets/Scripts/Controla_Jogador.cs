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
    private Animator animatorJogador;
    public int Vida;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDano;
    private MovimentaPersonagem movimentaJogador;

    // Start is called before the first frame update
    void Start() 
    {
        Time.timeScale = 1;
        animatorJogador = GetComponent<Animator>();
        movimentaJogador = GetComponent<MovimentaPersonagem>();
    }

    // Update is called once per frame
    void Update() 
    { 
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);
        
        if(direcao != Vector3.zero) {
            animatorJogador.SetBool("moving", true);
        } else {
            animatorJogador.SetBool("moving", false);
        }

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

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            movimentaJogador.Rotacionar(posicaoMiraJogador);
        }
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
