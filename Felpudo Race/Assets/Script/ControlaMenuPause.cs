using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaMenuPause : MonoBehaviour
{

    public bool gameLigado = false;

    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuTutorial;

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

    public void MenuPause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0;
        gameLigado = false;
    }

    public void FecharMenuPause()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        gameLigado = true;
    }

    public void MenuTutorial()
    {
        menuPause.SetActive(false);
        menuTutorial.SetActive(true);
        Time.timeScale = 0;
        gameLigado = false;

    }

    public void FecharTutorial()
    {
        menuTutorial.SetActive(false);
        menuPause.SetActive(true);
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
