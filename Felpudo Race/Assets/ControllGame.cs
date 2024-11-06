using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllGame : MonoBehaviour
{

    public bool gameLigado = false;


    [SerializeField] private GameObject Menuprincipal;
    [SerializeField] private GameObject Menucredito;
    [SerializeField] private GameObject MenuTutorialPrincipal;

    // Start is called before the first frame update
    void Start()
    {
        gameLigado = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
