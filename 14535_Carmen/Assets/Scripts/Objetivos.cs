using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //librería
using TMPro; //librería

public class Objetivos : MonoBehaviour
{
    public int numDeObjetivos; //contabilizar los objetivos
    public TextMeshProUGUI textoMision; //cambiar texto
    public GameObject botonDeMision; //para activar el botón al terminar de recolectar

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("Objetivo").Length; //findgame -> buscar  mediante la etiqueta, lenght ->cuántos ha encontrado
        textoMision.text = "Recoje las esferas" + 
                            "\n Restantes: " + numDeObjetivos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "objetivo"){
            Destroy(col.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Obtén las esferas rojas" + 
                                "\n Restantes: " + numDeObjetivos;
            if(numDeObjetivos <= 0) {
                textoMision.text = "Misión completada!:D";
                botonDeMision.SetActive(true);
            }
        }
    }
}
