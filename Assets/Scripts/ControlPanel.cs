using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{
    private Image imgVisor;
    public Image imgFuelBar;
    public GameObject telaTutorial;
    [Space(20)]
    public Button btoClassifica;
    public Button btoViajar;
    [Space(20)]
    public Sprite[] arrAstro;
    public int valorMin = 0;
    public int valorMax = StaticVar.cngResources;
    private int valorSorteado;
    [Space(20)]
    public Sprite imgLightSpeed; // Imagem da viagem no espaço
    public Text txtValScore;
    public Text txtValResources;
    [Space(20)]
    // --- variáveis para animação da transição ---
    public float velocidadeDeSalto;
    private float width;
    private float widthOrig;
    private float increaseWidth;
    private float height;
    private float heightOrig;
    private float increaseHeight;
    private float porcentagem;
    private bool viajando;

    private void Start()
    {
        if (StaticVar.totClassificadas >= 3) SceneManager.LoadScene("Conclusao");
        telaTutorial.SetActive(false);

        imgVisor = GetComponentInChildren<Image>();
        if (StaticVar.ClassifiedStars.Contains(StaticVar.imgAtiva))
        {
            //--- essa estrela já foi classificada ---
            StaticVar.imgAtiva = -1;
        }
        if (StaticVar.fuel < StaticVar.cngMaxFuel && StaticVar.imgAtiva > -1)
        {
            imgVisor.sprite = arrAstro[StaticVar.imgAtiva]; 
        }

        txtValScore.text = StaticVar.score.ToString();
        txtValResources.text = StaticVar.resources.ToString();
        VerifyFuel();

        // --- Inicializa o tutorial conforme o gerenciador ---
        if (StaticVar.imgAtiva == -1)
        {
            btoClassifica.interactable = false;
            //btoViajar.interactable = true;
        } else
        {
            btoViajar.interactable = false;
        }
        if (StaticVar.tutorialOn) StartCoroutine(ShowTutorial(StaticVar.tutorialOn));
    }

    public void ChangeAstro()
    {
        if (!viajando)
        {
            //--- Consome combustível durante a viagem ---
            StaticVar.fuel = StaticVar.fuel - (Mathf.Clamp(1, 0, StaticVar.cngMaxFuel)*3); //--- multiplica por 2 para fuel acabar mais rápido
            VerifyFuel();

            //--- Ativa o botão de classificação, e desativa o de viajar ---
            btoClassifica.interactable = true;
            btoViajar.interactable = false;

            //--- Chama a animação ---
            StartCoroutine(lightSpeedJump());
        }
    }

    public void hideTutorial()
    {
        StartCoroutine(ShowTutorial(false));
    }

    IEnumerator ShowTutorial(bool show)
    {
        // --- valores para versão PC ---
        int distancia = (int)(Canvas.FindObjectOfType<Button>().transform.position.y - imgFuelBar.transform.position.y);
        int Ymaior = (int)(imgFuelBar.transform.position.y)+(distancia*2);
        int Ymenor = Ymaior - distancia;
        int Xfixo = (int)imgFuelBar.transform.position.x;

        int speed = 10;
        if (distancia < 400) speed = 5;
        float wait = 0.005f;
        if (show)
        {
            StaticVar.tutorialOn = true;
            telaTutorial.SetActive(true);
            for (int y = Ymaior; y >= Ymenor; y = y - speed)
            {
                telaTutorial.transform.position = new Vector3(Xfixo, y, 0);
                yield return new WaitForSeconds(wait);
            }
        }
        else
        {
            StaticVar.tutorialOn = false;
            for (int y = Ymenor; y <= Ymaior; y = y + speed)
            {
                telaTutorial.transform.position = new Vector3(Xfixo, y, 0);
                yield return new WaitForSeconds(wait);
            }
            telaTutorial.SetActive(false);
        }
    }

    IEnumerator lightSpeedJump()
    {
        //--- Faz a animação da sprite de estrelas
        viajando = true;

        imgVisor.sprite = imgLightSpeed; //--- atribui o sprite da animação
        widthOrig = imgVisor.transform.localScale.x; //--- guarda a largura original para retornar ao tamanho depois
        heightOrig = imgVisor.transform.localScale.y; //--- guarda a altura original para retornar ao tamanho depois

        // --- Ajusta o incremento para o tamanho da imagem e a diminuição do tempo durante a animação
        //     quanto maior a porcentagem, mais rápido a animação executa
        porcentagem = 0.001f;

        // --- As 3 variáveis seguintes são ajustadas pela porcentagem
        //     Aqui estão definidas apenas seus valores iniciais
        increaseWidth = 0;
        increaseHeight = 0;
        velocidadeDeSalto = 0.1f;
        yield return new WaitForSeconds(velocidadeDeSalto);

        while (increaseWidth < 1)
        {
            //--- faz os cálculos de ajute de tamanho e de tempo de exposição da imagem
            width = imgVisor.sprite.rect.width;
            height = imgVisor.sprite.rect.height;
            increaseWidth = increaseWidth + (width * porcentagem / 100);
            increaseHeight = increaseHeight + (height * porcentagem / 100);
            velocidadeDeSalto = velocidadeDeSalto - (velocidadeDeSalto * (porcentagem * 10000) / 100);

            //--- aguarda um tempinho e depois ajusta o tamanho da imagem
            yield return new WaitForSeconds(velocidadeDeSalto);
            imgVisor.transform.localScale = new Vector3(imgVisor.transform.localScale.x + increaseWidth, imgVisor.transform.localScale.y + increaseHeight, imgVisor.transform.localScale.z);
        }

        //--- Verifica se já visitou todas as estrelas ---


        //if (Mathf.Abs(arrAstro.Length - 0) > StaticVar.ClassifiedStars.Count)
        if (StaticVar.totClassificadas < 3)
        {
            while (true)
            {
                int numeroAleatorio = Random.Range(0, arrAstro.Length);
                if (!StaticVar.ClassifiedStars.Contains(numeroAleatorio))
                {
                    StaticVar.imgAtiva = numeroAleatorio;
                    imgVisor.sprite = arrAstro[StaticVar.imgAtiva];
                    break;
                }
            }
        }
        else
        {
            SceneManager.LoadScene("Conclusao");
        }

        //--- Retorna o tamanho da imagem para seu original
        imgVisor.transform.localScale = new Vector3(widthOrig, heightOrig, imgVisor.transform.localScale.z);
        viajando = false;
    }

    private void VerifyFuel()
    {
        if (StaticVar.fuel <= 6f)
        {
            imgFuelBar.color = new Color32(255, 0, 86, 255);
        }
        if (StaticVar.fuel <= 0f)
        {
            //Debug.Log(StaticVar.fuel);
            SceneManager.LoadScene("GameOver");
        }

        imgFuelBar.fillAmount = StaticVar.fuel / 14;
    }

    public void Abastecer()
    {
        if (StaticVar.resources > 10)
        {
            imgFuelBar.color = new Color32(87, 255, 0, 255);
            imgFuelBar.fillAmount = 100;
            StaticVar.fuel = StaticVar.cngMaxFuel;
            StaticVar.resources -= 10;
            txtValResources.text = StaticVar.resources.ToString();
        }
    }
}
