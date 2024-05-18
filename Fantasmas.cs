using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFantasmas : MonoBehaviour
{
    
    public GameObject[] personajes;

    public int ValAleatorio = 1;
    // Start is called before the first frame update
    public void Start()
    {
        ValAleatorio = Random.Range(1,9);
        
        StartCoroutine("lanzarPersonaje");
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    IEnumerator lanzarPersonaje(){

        personajes[ValAleatorio].GetComponent<Comportamiento_Fantasma>().Mostrar();
        Debug.Log(ValAleatorio);
        yield return new WaitForSeconds(2);
        personajes[ValAleatorio].GetComponent<Comportamiento_Fantasma>().Esconder();
        yield return new WaitForSeconds(2);
        ValAleatorio = Random.Range(1,9);
        
        StartCoroutine("lanzarPersonaje");
        


     }
}
