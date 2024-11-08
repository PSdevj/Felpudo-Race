using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllGame : MonoBehaviour
{
    //Código responsável por controlar o jogo e manipular as cenas

    public bool gameLigado = false;


    [SerializeField] private GameObject Menuprincipal;
    [SerializeField] private GameObject Menucredito;
    [SerializeField] private GameObject MenuTutorialPrincipal;
    [SerializeField] private GameObject MenuVitoria;
    [SerializeField] private GameObject MenuPausa;
    public GameObject telaGameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameLigado = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pausar();
        }
    }



    public bool EstadoDoJogo()
    {
        return gameLigado;
    }

    public void MenuTutorial()
    {
        MenuTutorialPrincipal.SetActive(true);
        Menuprincipal.SetActive(false);
        
    }
    public void Pausar()
    {
        MenuPausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReniciarPause()
    {
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void FecharMenuTutorial()
    {
        Menuprincipal.SetActive(true);
        MenuTutorialPrincipal.SetActive(false);
    }


    public void MenuCredito()
    {
        Menucredito.SetActive(true);
        Menuprincipal.SetActive(false);

    }
    public void FecharCredito()
    {
        Menucredito.SetActive(false);
        Menuprincipal.SetActive(true);

    }


    public void PersonagemMorreu()
    {
        telaGameOver.SetActive(true);
        Time.timeScale = 0;
        gameLigado = false;

    }

    public void VitoriaPlayer()
    {
        MenuVitoria.SetActive(true);
        Time.timeScale = 0;
        gameLigado = false;
    }

    public void LoadScene(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    public void RestatGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
