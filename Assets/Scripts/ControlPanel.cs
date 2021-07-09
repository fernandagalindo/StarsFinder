using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlPanel : MonoBehaviour
{
    private GameObject SceneMng;
    private Image imgVisor;
    public Image imgFuelBar;
    public Sprite[] arrAstro;
    public Sprite imgLightSpeed; // Imagem da viagem no espa�o
    public Text txtValScore;
    public Text txtValResources;
    
    // --- vari�veis para anima��o da transi��o ---
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
        imgVisor = GetComponentInChildren<Image>();
        if (StaticVar.fuel < 14) imgVisor.sprite = arrAstro[StaticVar.imgAtiva];
        txtValScore.text = StaticVar.score.ToString();
        txtValResources.text = StaticVar.resources.ToString();
        VerifyFuel();
    }

    public void ChangeAstro()
    {
        if (!viajando)
        {
            //--- Consome combust�vel durante a viagem ---
            StaticVar.fuel = StaticVar.fuel - Mathf.Clamp(1, 0, 14);
            VerifyFuel();
            //--- Chama a anima��o ---
            StartCoroutine(lightSpeedJump());
        }
    }

    IEnumerator lightSpeedJump()
    {
        //--- Faz a anima��o da sprite de estrelas
        viajando = true;

        imgVisor.sprite = imgLightSpeed; //--- atribui o sprite da anima��o
        widthOrig = imgVisor.transform.localScale.x; //--- guarda a largura original para retornar ao tamanho depois
        heightOrig = imgVisor.transform.localScale.y; //--- guarda a altura original para retornar ao tamanho depois

        // --- Ajusta o incremento para o tamanho da imagem e a diminui��o do tempo durante a anima��o
        //     quanto maior a porcentagem, mais r�pido a anima��o executa
        porcentagem = 0.001f;

        // --- As 3 vari�veis seguintes s�o ajustadas pela porcentagem
        //     Aqui est�o definidas apenas seus valores iniciais
        increaseWidth = 0;
        increaseHeight = 0;
        velocidadeDeSalto = 0.1f;
        yield return new WaitForSeconds(velocidadeDeSalto);

        while (increaseWidth < 1)
        {
            //--- faz os c�lculos de ajute de tamanho e de tempo de exposi��o da imagem
            width = imgVisor.sprite.rect.width;
            height = imgVisor.sprite.rect.height;
            increaseWidth = increaseWidth + (width * porcentagem / 100);
            increaseHeight = increaseHeight + (height * porcentagem / 100);
            velocidadeDeSalto = velocidadeDeSalto - (velocidadeDeSalto * (porcentagem*10000) / 100);

            //--- aguarda um tempinho e depois ajusta o tamanho da imagem
            yield return new WaitForSeconds(velocidadeDeSalto);
            imgVisor.transform.localScale = new Vector3(imgVisor.transform.localScale.x + increaseWidth, imgVisor.transform.localScale.y + increaseHeight, imgVisor.transform.localScale.z);
        }
        
        //--- Sorteia um astro e mostra no Visor
        StaticVar.imgAtiva = Random.Range(0, arrAstro.Length - 1);
        imgVisor.sprite = arrAstro[StaticVar.imgAtiva];
        //--- Retorna o tamanho da imagem para seu original
        imgVisor.transform.localScale = new Vector3(widthOrig, heightOrig, imgVisor.transform.localScale.z);
        viajando = false;
    }

    private void VerifyFuel()
    {
        if (StaticVar.fuel <= 3f)
        {
            imgFuelBar.color = new Color32(255, 0, 86, 255);
        }
        if (StaticVar.fuel <= 0f)
        {
            Debug.Log(StaticVar.fuel);
            SceneManager.LoadScene("GameOver");
        }

        imgFuelBar.fillAmount = StaticVar.fuel / 14;
    }
}
