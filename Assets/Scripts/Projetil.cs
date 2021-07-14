using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public float Velocidade = 20;
    private Rigidbody rigidbodyProjetil;
    public AudioClip SomMorte;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyProjetil = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbodyProjetil.MovePosition(GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider objetoColisao)
    {
        if (objetoColisao.tag == "Inimigo")
        {
            Destroy(objetoColisao.gameObject);
            ControlaAudio.instancia.PlayOneShot(SomMorte);
            
        }

        Destroy(gameObject);
    }
}
