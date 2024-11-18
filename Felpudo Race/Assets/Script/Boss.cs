using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Transform player; // Referência ao Transform do jogador que será perseguido

    public float velocidade = 2f;
    public float limiteEsquerda = -5f;

    public float limiteDireita = 5f;
    private bool movendoParaDireita = true; // Controla a direção do movimento

    private Vector3 screenCenter; // Guarda a posição central da tela.
    private Vector3 originalScale; // Guarda a escala original do boss.

    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint; // Ponto de origem dos projéteis

    public float shootInterval = 2f; 
    public float projectileSpeed = 5f; 

    public Slider barraDeVida; // Referência para a barra de vida na UI.
    public int vidaAtual;
    public int vidaMaxima;

    private ControllGame gameController; // Controlador de jogo para checar a vitória.

    // Start is called before the first frame update
    void Start()
    {
        // Encontra o jogador na cena
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Configura o disparo automático a cada `shootInterval` segundos
        InvokeRepeating("ShootProjectile", 2f, shootInterval);

        //Calcula a posição central da tela em coordenadas do mundo
        screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Guarda a escala original do boss
        originalScale = transform.localScale;

        // Inicializa os valores de vida.
        vidaAtual = vidaMaxima;
        barraDeVida.maxValue = vidaAtual;
        barraDeVida.value = vidaAtual; // Atualiza o valor inicial da barra de vida

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllGame>();  // Busca o controlador de jogo.
    }

    // Update is called once per frame
    void Update()
    {
        // Move o boss na direção atual
        if (movendoParaDireita)
        {
            transform.position += Vector3.right * velocidade * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * velocidade * Time.deltaTime;
        }

        // Verifica se atingiu os limites e inverte a direção
        if (transform.position.x >= limiteDireita)
        {
            movendoParaDireita = false;
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Virar para a esquerda
        }
        else if (transform.position.x <= limiteEsquerda)
        {
            movendoParaDireita = true;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Virar para a direita
        }

        if (player != null) 
        {
            // Verifica se o jogador está à esquerda ou à direita do centro da tela
            if (player.position.x < screenCenter.x)
            {
                // Vira o boss para a esquerda sem mudar o tamanho
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else
            {
                // Vira o boss para a direita sem mudar o tamanho
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
        }
       
    }

    void ShootProjectile()
    {
        if (player != null)
        {
            // Verifica se o jogador está à direita ou à esquerda do boss
            bool isPlayerToTheRight = player.position.x > transform.position.x;
            bool isBossFacingRight = transform.localScale.x > 0; // Assume que x > 0 é virado para a direita

            // Checa se o boss está virado para a direção do jogador
            if ((isPlayerToTheRight && isBossFacingRight) || (!isPlayerToTheRight && !isBossFacingRight))
            {
                // Instancia o projétil no ponto de disparo
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                // Verifica se o projétil possui o componente de dano
                if (projectile.GetComponent<Projetil>() == null)
                {
                    projectile.AddComponent<Projetil>(); // Adiciona o script caso ainda não tenha
                }

                // Calcula a direção do disparo em direção ao jogador
                Vector2 direction = (player.position - firePoint.position).normalized;
                // Adiciona velocidade ao projétil
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    rb.velocity = direction * projectileSpeed;
                }

            }
        }

    }

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Pera"))
        {
            vidaAtual--;
            barraDeVida.value = vidaAtual; // Atualiza a barra de vida
            if (vidaAtual <= 0)
            {
                Debug.Log("Vitoria");
                gameController.VitoriaPlayer();
                Destroy(gameObject);
            }
        }
    }
}
