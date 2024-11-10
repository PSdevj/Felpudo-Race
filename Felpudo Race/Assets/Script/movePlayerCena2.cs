using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movePlayerCena2 : MonoBehaviour
{
    public Rigidbody2D corpoPlayer;
    public float velocidadePlayer;

    public int vidaMaxima;
    public int vidaAtual;

    public Slider barraDeVida;
    public ControllGame genJ;

    private Animator animator; // Controlador de animação do objeto atual
    private Vector3 originalScale; // Guarda a escala original do player

    public GameObject laserPlayer;
    public Transform localLaserPlayer;

    public bool temEnergia;
    public int energia = 10;
    public float tempoDeEnergia = 0f;

    public float tempoMaximoTiro;
    public float tempoAtualTiro;

    public float forcaPulo = 5f;
    public bool estaNoChao;

    // Start is called before the first frame update
    void Start()
    {
        corpoPlayer = GetComponent<Rigidbody2D>();
        temEnergia = true;
        tempoAtualTiro = tempoMaximoTiro;

        // Inicializa o componente Animator
        animator = GetComponent<Animator>();

        // Armazena a escala original do player quando o jogo começa
        originalScale = transform.localScale;

        vidaAtual = vidaMaxima;
        barraDeVida.maxValue = vidaAtual;
        barraDeVida.value = vidaAtual; // Atualiza o valor inicial da barra de vida
    }

    // Update is called once per frame
    void Update()
    {
        movimentacaoPlayer();
        puloPlayer(); // Chama o método de pulo


        if (tempoAtualTiro <= 0)
        {
            AtirarFruta();
        }
        tempoAtualTiro -= Time.deltaTime;

    }
    public void movimentacaoPlayer()
    {
        velocidadePlayer = Input.GetAxis("Horizontal") * 3.5f;
        corpoPlayer.velocity = new Vector2(velocidadePlayer, corpoPlayer.velocity.y);

        if (velocidadePlayer > 0)
        {
            // Vira para a direita
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (velocidadePlayer < 0)
        {
            // Vira para a esquerda
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }

    public void puloPlayer()
    {
        if (Input.GetButtonDown("Jump") && estaNoChao) // Verifica se a tecla de pulo foi pressionada e se está no chão
        {
            corpoPlayer.velocity = new Vector2(corpoPlayer.velocity.x, forcaPulo);
            estaNoChao = false; // Define que o player não está mais no chão
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão") || collision.gameObject.CompareTag("plataforma")) // Certifique-se de que o chão tem a tag "Chao"
        {
            estaNoChao = true;
        }
    }


    public void AtirarFruta()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Instancia o projétil e armazena a referência em uma variável
            GameObject proj = Instantiate(laserPlayer, localLaserPlayer.position, localLaserPlayer.rotation);

            // Define a direção do projétil para cima
            Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(0, 5f); // Ajuste o valor para controlar a velocidade do tiro
            }

            // Reseta o tempo do tiro
            tempoAtualTiro = tempoMaximoTiro;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Banana"))
        {
            vidaAtual--;
            barraDeVida.value = vidaAtual;
            Destroy(collision.gameObject);

            if (vidaAtual <= 0)
            {
                Destroy(gameObject);
                genJ.PersonagemMorreu();
            }
        }
    }

}
