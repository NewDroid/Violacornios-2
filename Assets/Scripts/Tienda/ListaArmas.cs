using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ListaArmas : MonoBehaviour {

    public List<Arma> lista = new List<Arma>();

	public void AñadirArma(Arma arma)
    {
        lista.Add(arma);
    }

    public void AñadirArma(float dañosSegundo, float tiempoDisparo, float distanciaMax, int daño, bool laser, bool arcoiris, bool auto, int balasPorCargador, float tiempoRecarga, float maximoSobrecalentamiento)
    {
        lista.Add(new Arma(dañosSegundo, tiempoDisparo, distanciaMax, daño, laser, arcoiris, auto, balasPorCargador, tiempoRecarga,maximoSobrecalentamiento));
    }
}
