using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public Transform player; // Refer�ncia ao Transform do jogador que ser� perseguido

    public float velocidade = 2f;
    public float limiteEsquerda = -5f;

    public float limiteDireita = 5f;
    private bool movendoParaDireita = true; // Controla a dire��o do movimento

    private Vector3 screenCenter; // Guarda a posi��o central da tela.
    private Vector3 originalScale; // Guarda a escala original do boss.

    public GameObject projectilePrefab; // Prefab do proj�til
    public Transform firePoint; // Ponto de origem dos proj�teis

    public float shootInterval = 2f; 
    public float projectileSpeed = 5f; 

    public Slider barraDeVida; // Refer�ncia para a barra de vida na UI.
    public int vidaAtual;
    public int vidaMaxima;

    private ControllGame gameController; // Controlador de jogo para checar a vit�ria.

    // Start is called before the first frame update
    void Start()
    {
        // Encontra o jogador na cena
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Configura o disparo autom�tico a cada `shootInterval` segundos
        InvokeRepeating("ShootProjectile", 2f, shootInterval);

        //Calcula a posi��o central da tela em coordenadas do mundo
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
        // Move o boss na dire��o atual
        if (movendoParaDireita)
        {
            transform.position += Vector3.right * velocidade * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * velocidade * Time.deltaTime;
        }

        // Verifica se atingiu os limites e inverte a dire��o
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
            // Verifica se o jogador est� � esquerda ou � direita do centro da tela
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
            // Verifica se o jogador est� � direita ou � esquerda do boss
            bool isPlayerToTheRight = player.position.x > transform.position.x;
            bool isBossFacingRight = transform.localScale.x > 0; // Assume que x > 0 � virado para a direita

            // Checa se o boss est� virado para a dire��o do jogador
            if ((isPlayerToTheRight && isBossFacingRight) || (!isPlayerToTheRight && !isBossFacingRight))
            {
                // Instancia o proj�til no ponto de disparo
                GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                // Verifica se o proj�til possui o componente de dano
                if (projectile.GetComponent<Projetil>() == null)
                {
                    projectile.AddComponent<Projetil>(); // Adiciona o script caso ainda n�o tenha
                }

                // Calcula a dire��o do disparo em dire��o ao jogador
                Vector2 direction = (player.position - firePoint.position).normalized;
                // Adiciona velocidade ao proj�til
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
