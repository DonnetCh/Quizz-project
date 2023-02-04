using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Respuesta : MonoBehaviour
{
    public bool esCorrecto = false;
    public QuizzManager quizManager;
    

    public void Respuestas()
    {
        
        if (esCorrecto)
        {
            Debug.Log("Respuesta Correcta");
            quizManager.correct();
            this.GetComponent<Image>().color = Color.green;
            StartCoroutine(Change());
        }
        else
        {
            Debug.Log("Respuesta Incorrecta");
            quizManager.incorrect();
            this.GetComponent<Image>().color = Color.red;
            
            StartCoroutine(Change());
        }
        
        
    }
    public void CambiaColor()
    {

        if (esCorrecto == true)
        {
          //  this.GetComponent<Image>().color = Color.green;
            Debug.Log("Verde");
        }
        else if (esCorrecto == false)
        {
        //    this.GetComponent<Image>().color = Color.red;
            Debug.Log("Rojo");
        }
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(.8f);
     
        RegresarColor();
    }
    public void RegresarColor()
    {
        this.GetComponent<Image>().color = Color.white;
    }
    
}
