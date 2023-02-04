using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizzManager : MonoBehaviour
{
    public List <Pregunta> preguntas;
    private int  preguntaactual;
    [SerializeField]
    private TextMeshProUGUI preguntatxt;
    [SerializeField]
    public GameObject[] opciones;
    
    public GameObject QuizzPanel;
    public GameObject GameOverPanel;
    public TextMeshProUGUI scoretxt;
    public TextMeshProUGUI Finalscoretxt;
    public int Score = 0;
    int TotalPreguntas = 0;
    
   


    private void Start()
    {
    
        TotalPreguntas = preguntas.Count;
        GameOverPanel.SetActive(false);
        
        PreguntaElegida();
       
      
    }

    IEnumerator Started()
    {
       
        yield return new WaitForSeconds(1);
        PreguntaElegida();
        
       
    }
    void PreguntaElegida()
    {
        if(preguntas.Count > 0)
        {
            preguntaactual = Random.Range(0, preguntas.Count);

            preguntatxt.text = preguntas[preguntaactual].Preguntas;
            OpcionesDisponibles();
        }
       else
        {
            Debug.Log("SinPreguntas");
            GameOver();
        }
     
    }
    void OpcionesDisponibles()
    {
        for (int i = 0; i < opciones.Length; i++)
        {
            opciones[i].GetComponent<Respuesta>().esCorrecto = false;
            opciones[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = preguntas[preguntaactual].Respuestas[i];

            if (preguntas[preguntaactual].ResCorrect == i + 1)
            {
                opciones[i].GetComponent<Respuesta>().esCorrecto = true;
               
            }
        }
    }
 

   public void correct()
    {

    
        Score = Score + 100;
        scoretxt.text = Score.ToString();
        preguntas.RemoveAt(preguntaactual);
        StartCoroutine(Started());
       
    }
    public void incorrect()
    {
       

        preguntas.RemoveAt(preguntaactual);
        StartCoroutine(Started());
      
    }
  
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        QuizzPanel.SetActive(false);
        Finalscoretxt.text = Score.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
