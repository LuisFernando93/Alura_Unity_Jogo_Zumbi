using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Jogador : MonoBehaviour 
{

    public float velocidadeDeMovimento = 10;
    private Vector3 direcao;
    public LayerMask MascaraChao;

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update() 
    { 
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX,0,eixoZ);
        
        if(direcao != Vector3.zero) {
            GetComponent<Animator>().SetBool("moving", true);
        } else {
            GetComponent<Animator>().SetBool("moving", false);
        }
            
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (transform.position + (direcao * velocidadeDeMovimento * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}
