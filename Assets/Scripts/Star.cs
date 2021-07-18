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
    public Text txtBonu;
    [Space(20)]
    public AudioClip Music;
    [Space(20)]
    //--- Se acertou ou errou ---
    private bool acertou;
    public GameObject particleCeleb;
    public GameObject goAcertou;
    //--- Se errou ---
    public GameObject particleExplosion;
    public GameObject goErrou;
    public GameObject tutorial;

    [Space(20)]
    //--- Variável classificação feita pelo player ---
    private int intClass;
    //--- Variável que vai ser mostrada na classificação ---
    private string txtClass;

    //--- efeito de texto piscando ---
    private float adicao;
    private bool soma;

    //--- Base de Dados de Estrelas ---
    public string[] arrNomeEstrela;
    public string[] arrTempEstrela;
    public string[] arrLumiEstrela;
    public string[] arrDescEstrela;



    [SerializeField]
    private int speed;

    //--- tentativa de mover a estrela com o mouse ---
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        estrela = GetComponent<ParticleSystem>();
        goAcertou.SetActive(false);
        goErrou.SetActive(false);
        if (StaticVar.tutorialOn) tutorial.SetActive(true);
        else tutorial.SetActive(false);

        //--- Mostra a temperatura e a Luminosidade da estrela a classificar ---
        ShowDataStar();

        intClass = -1;
        adicao = 1f;
        soma = true;

        AudioManager.instance.PlaySound(Music);
    }

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
                    StaticVar.ClassifiedStars.Add(StaticVar.imgAtiva);
                    Instantiate(particleCeleb, rb2D.position, rb2D.transform.rotation);
                    txtClas.color = Color.yellow;
                    txtClas.fontStyle = FontStyle.Bold;
                    txtClas.text = "- " + txtClass;
                    txtBonu.text = arrDescEstrela[StaticVar.imgAtiva];
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
                    //StartCoroutine(BlinkText(txt));
                }
                txtScor.text = "SUA PONTUAÇÃO: " + StaticVar.score;
                txtScor.fontStyle = FontStyle.Bold;
                estrela.Stop();
                //StartCoroutine(BlinkText(txtClas));
            }
        } else StartCoroutine(BlinkText(txtClas));

        //--- se a estrela ainda não foi classificada, pisca os dados sobre ela ---
        if (txtClas.text == "-")
        {
            StartCoroutine(BlinkText(txtLumi));
            StartCoroutine(BlinkText(txtTemp));
        }

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
        //Debug.Log(intClass);
    }
    
    private void VerificaClassificacao(int playerClass)
    {
        acertou = false;
        if (StaticVar.imgAtiva == 0 && playerClass == 5) acertou = true; // estrela anã branca
        else if (StaticVar.imgAtiva == 1 && playerClass == 2) acertou = true; // betelgeuse
        else if (StaticVar.imgAtiva == 2 && playerClass == 3) acertou = true; // ESA image
        else if (StaticVar.imgAtiva == 3 && playerClass == 4) acertou = true; // ESA pinpoint
        else if (StaticVar.imgAtiva == 4 && playerClass == 5) acertou = true; // GSFC
        else if (StaticVar.imgAtiva == 5 && playerClass == 1) acertou = true; // Sol
    }

    IEnumerator BlinkText(Text textToBlink)
    {
        textToBlink.color = new Color(255, 255, 255, adicao);
        if (soma) adicao += 0.05f;
        else adicao -= 0.05f;
        if (adicao >= 1.05f) { soma = false; adicao = 1f; }
        else if (adicao <= -0.35f) { soma = true; adicao = 0f; }
        yield return new WaitForSeconds(0.05f);
    }

    private void ShowDataStar()
    {
        StaticVar.imgAtiva = 4;
        //--- Cria os números em SuperScript ----
        string[] strSS = new string[10] { "\u2070", "\u2071", "\u2072", "\u2073", "\u2074", "\u2075", "\u2076", "\u2077", "\u2078", "\u2079" };
        for (int x = 0; x < 10; x++)
        {
            strSS[x] = strSS[x].ToString();
        }

        //--- verifica qual o último caracter da string para fazer o superscript ----
        string strIni = arrLumiEstrela[StaticVar.imgAtiva].Substring(0,1);
        string strNum = arrLumiEstrela[StaticVar.imgAtiva].Substring(arrLumiEstrela[StaticVar.imgAtiva].Length-1);
        int intNum = int.Parse(strNum);
        strNum = strSS[intNum].ToString();

        //--- pega a luminosidade da estrela e retira o último caracter ---
        string strLumi = arrLumiEstrela[StaticVar.imgAtiva].Substring(0, arrLumiEstrela[StaticVar.imgAtiva].Length - 1);

        //--- verifica se o número é negativo para posicionar o sinal no lugar certo ---
        int tam = strLumi.Length - 1;
        if (strIni == "-")
        {
            strNum = "-" + strNum;
            strLumi = strLumi.Substring(1, tam);
        }

        txtTemp.text = arrTempEstrela[StaticVar.imgAtiva] + " K";
        txtLumi.text = strLumi + strNum + " Lsol";
        txtClas.text = "-";
    }
}



