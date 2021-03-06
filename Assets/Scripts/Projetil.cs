using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{

    public float Velocidade = 20;
    private Rigidbody rigidbodyProjetil;
    private int DanoDoProjetil = 1;

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
            objetoColisao.GetComponent<ControlaInimigo>().TomarDano(DanoDoProjetil);
        }

        Destroy(gameObject);
    }
}
