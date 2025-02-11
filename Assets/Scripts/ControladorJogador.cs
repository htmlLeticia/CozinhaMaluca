using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float taxaMovimentacao;
    public Geral juizDoJogo;

    // Update is called once per frame
    void Update()
    {
        float altX, altY;

        //Para cima e para baixo -  mexe com o Y
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 471)
        {
            altY = 60 * Time.deltaTime * taxaMovimentacao;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 28)
        {
            altY = -60 * Time.deltaTime * taxaMovimentacao;
        }
        else altY = 0;

        //Para os lados -  mexe com o X
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 940)
        {
            altX = 60 * Time.deltaTime * taxaMovimentacao;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 21)
        {
            altX = -60 * Time.deltaTime * taxaMovimentacao;
        }
        else altX = 0;

        //modifica a posição 
        Vector3 novaPos = new Vector3(altX, altY, 0);
        transform.position += novaPos;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador") 
        {
            juizDoJogo.MarcarPonto();
            collision.GetComponent<ControladorVoador>().posicaoObj.x = 
                collision.GetComponent<ControladorVoador>().posInicialX; 
        }
    }
}
