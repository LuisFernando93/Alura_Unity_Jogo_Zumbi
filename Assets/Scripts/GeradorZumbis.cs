using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{

    public GameObject Zumbi;
    float timer = 0;
    public float tempoGerarZumbi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= tempoGerarZumbi)
        {
            timer = 0;
            Instantiate(Zumbi, transform.position, transform.rotation);
        }
    }
}
