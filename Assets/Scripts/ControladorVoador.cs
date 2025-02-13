using UnityEngine;
using UnityEngine.UI;

public class ControladorVoador : MonoBehaviour
{
    public float deslocamentoObjeto; // determina a velocidade inicial do obj
    public float incrementoVelocidade; // determina o aumento da velocidade por segundo
    public float posInicialX;
    public Sprite[] imagensObjetos;


    internal int sentidoV; // para qual lado o objeto vai na vertical
    internal Vector3 posicaoObj; // a variavel em que indicamento a nova posição (x, y, z) dinamicamente
    internal float deslocamentoAbs; // o deslocamento do aplicado ao objeto por quadro (update)
    internal int numImagemAtual = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentidoV = 1; 
        posicaoObj = transform.position;
        posInicialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //movimentação: velocidade do deslocamento do objeto * sentido(vertical) * Time.deltaTime * velocidade dinamica
        posicaoObj.y += deslocamentoAbs * sentidoV * Time.deltaTime;
        posicaoObj.x += deslocamentoAbs * Time.deltaTime;

        deslocamentoAbs += incrementoVelocidade * Time.deltaTime;

        transform.position = posicaoObj;

        //limetadores verticais
        if (transform.position.y > 471) 
        {
            sentidoV = -1;
        }
        else if (transform.position.y < 28)
        {
            sentidoV = 1;
        }
    }

    public void MudarImagem()
    {
        numImagemAtual++;

        if (numImagemAtual == imagensObjetos.Length)
            numImagemAtual = 0;

        GetComponent<Image>().sprite = imagensObjetos[numImagemAtual];
    }
}
