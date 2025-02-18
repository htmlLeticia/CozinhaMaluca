using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Geral : MonoBehaviour
{
    internal int placarJogadorNum, recordeNum;
    public Text placarJogadorTexto, recordeTexto;
    public AudioSource somPontoGanho;

    public GameObject telaBoasVindas, telaGameOver;
    public ControladorVoador objetoVoador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        placarJogadorNum = 0; 
        //recordeNum = 0;

        AtualizarTextoPlacar();

        Time.timeScale = 0;
    }

    public void MarcarPonto()
    {
        placarJogadorNum += 1;

        if (recordeNum < placarJogadorNum)        
            recordeNum += 1;

        AtualizarTextoPlacar();

        somPontoGanho.Play();
    }

    public void AtualizarTextoPlacar()
    {
        placarJogadorTexto.text = "Itens coletados: " + placarJogadorNum;
        recordeTexto.text = "Recorde atual: " + recordeNum;
    }

    public void ComecarJogo()
    {
        Time.timeScale = 1; // descongela o tempo
        // sumir com as telas bem vindo e game over
        telaBoasVindas.SetActive(false);
        telaGameOver.SetActive(false);

        //volta o objeto voador a sua posição original
        objetoVoador.deslocamentoAbs = objetoVoador.deslocamentoObjeto;
        objetoVoador.posicaoObj.x = objetoVoador.posInicialX;

        //zera o placar do jogador
        placarJogadorNum = 0;
        AtualizarTextoPlacar();
    }

    public void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
