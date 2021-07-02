using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Jogador : MonoBehaviour 
{

    public float velocidadeDeMovimento = 10;
    private Vector3 direcao;

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
    }
}
