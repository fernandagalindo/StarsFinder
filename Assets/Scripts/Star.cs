using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private ParticleSystem estrela;

    //--- Variáveis/Campos de texto ---
    public Text txtTemp;
    public Text txtLumi;
    public Text txtClas;
    public Text txtScor;

    //--- Se acertou ou errou ---
    private bool acertou;
    public GameObject particleCeleb;
    public GameObject goAcertou;
    //--- Se errou ---
    public GameObject particleExplosion;
    public GameObject goErrou;


    //--- Variável classificação feita pelo player ---
    private int intClass;
    //--- Variável que vai ser mostrada na classificação ---
    private string txtClass;

    //--- efeito de texto piscando ---
    private float adicao;
    private bool soma;



    [SerializeField]
    private int speed;

    //--- tentativa de mover a estrela com o mouse ---
    private Vector3 mousePos;
    private bool draggingmode;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        estrela = GetComponent<ParticleSystem>();
        goAcertou.SetActive(false);
        goErrou.SetActive(false);

        draggingmode = false;
        //--- Mostra a temperatura e a Luminosidade da estrela a classificar ---
        // if (StaticVar.imgAtiva == 1) { txtTemp.text = "Temperatura: xxxxK"; txtLumi.text = "Luminosidade: xxxxx"; }
        //iAtiva = GetComponent<Image>("imagemAtiva");
        //iAtiva.sprite = 
        txtTemp.text = "- 500K";
        txtLumi.text = "- 10.000";
        txtClas.text = "-";
        intClass = -1;
        adicao = 1f;
        soma = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Quando o usuário clica com o botão esquerdo
        if (Input.GetMouseButtonDown(0))
        {
            if (txtClas.text == "-")
            {
                StaticVar.resources -= 10; //--- Representa um gasto de recursos a cada expedição e classificação
                VerificaClassificacao(intClass);
                if (acertou)
                {
                    StaticVar.score += 5; //--- Soma 5 pontos ao Score
                    Instantiate(particleCeleb, rb2D.position, rb2D.transform.rotation);
                    txtClas.color = Color.yellow;
                    txtClas.fontStyle = FontStyle.Bold;
                    txtClas.text = "- " + txtClass;
                    goAcertou.SetActive(true);
                }
                else
                {
                    StaticVar.score -= 1; //--- Subtrai 1 ponto do Score
                    Instantiate(particleExplosion, rb2D.position, rb2D.transform.rotation);
                    txtClas.color = Color.red;
                    txtClas.fontStyle = FontStyle.Bold;
                    txtClas.text = "- INCORRETO!";
                    goErrou.SetActive(true);
                }
                txtScor.text = "SUA PONTUAÇÃO: " + StaticVar.score;
                txtScor.fontStyle = FontStyle.Bold;
                estrela.Stop();
                StartCoroutine("BlinkText");
            }
        }

        // every frame when user hold left mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (draggingmode)
            {
                //touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //newGOCenter = touchPosition - offSet;
                rb2D.transform.position = Input.mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            draggingmode = false;
        }

        StartCoroutine(BlinkText());
    }


    private void FixedUpdate()
    {
        //--- Movimento pelo teclado (não funciona porque o mouse está ativo o tempo todo)
        float moveH = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(moveH * speed, rb2D.velocity.y);

        float moveV = Input.GetAxis("Vertical");
        rb2D.velocity = new Vector2(rb2D.velocity.x, moveV * speed);

        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb2D.position = mousePos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hrAnasBrancas")) { intClass = 5; txtClass = "ANÃ BRANCA"; }
        else if (other.CompareTag("hrSeqPrincipal")) { intClass = 1; txtClass = "SEQUÊNCIA PRINCIPAL"; }
        else if (other.CompareTag("hrGigantesVermelhas")) { intClass = 2; txtClass = "GIGANTE VERMELHA"; }
        else if (other.CompareTag("hrGigantesAzuis")) { intClass = 3; txtClass = "GIGANTE AZUL"; }
        else if (other.CompareTag("hrSuperGigVermelhas")) { intClass = 4; txtClass = "SUPER GIGANTE VERMELHA"; }
    }
    
    private void VerificaClassificacao(int playerClass)
    {
        acertou = false;
        if (StaticVar.imgAtiva == 0 && playerClass == 5) acertou = true;
        else if (StaticVar.imgAtiva == 1 && playerClass == 2) acertou = true;
        else if (StaticVar.imgAtiva == 2 && playerClass == 3) acertou = true;
        else if (StaticVar.imgAtiva == 3 && playerClass == 4) acertou = true;
        else if (StaticVar.imgAtiva == 4 && playerClass == 5) acertou = true;
        else if (StaticVar.imgAtiva == 5 && playerClass == 1) acertou = true;
    }

    IEnumerator BlinkText()
    {
        txtClas.color = new Color(255, 255, 255, adicao);
        if (soma) adicao += 0.05f;
        else adicao -= 0.05f;
        if (adicao >= 1.05f) { soma = false; adicao = 1f; }
        else if (adicao <= -0.05f) { soma = true; adicao = 0f; }
        yield return new WaitForSeconds(0.01f);
    }

}



