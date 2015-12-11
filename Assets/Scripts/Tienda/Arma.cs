[System.Serializable]
public class Arma
{
    float dañosSegundo = 8; //Cuantas veces hace el daño por segundo
    float tiempoDisparo = 0.3f;
    float distanciaMax = 200f; //unidades para el raycast
    int daño = 1; //En puntos de vida, ya hare la clase pambi para controlar todo eso
    bool laser = true;//Es un laser o son balas?
    bool arcoiris = true; //El laser sera arcoiris? :3
    bool auto;//Es automatica?
    int balasPorCargador = 5;//Cuantas balas caben en un cargador
    float tiempoRecarga = 2.5f;//Cuanto tarda en recargar
    float maximoSobrecalentamiento = 10f; //El maximo antes de que haga bum	

    public Arma(float dañosSegundo, float tiempoDisparo, float distanciaMax, int daño, bool laser, bool arcoiris, bool auto, int balasPorCargador, float tiempoRecarga, float maximoSobrecalentamiento)
    {
        this.dañosSegundo = dañosSegundo;
        this.tiempoDisparo = tiempoDisparo;
        this.distanciaMax = distanciaMax;
        this.daño = daño;
        this.laser = laser;
        this.arcoiris = arcoiris;
        this.auto = auto;
        this.balasPorCargador = balasPorCargador;
        this.tiempoRecarga = tiempoRecarga;
        this.maximoSobrecalentamiento = maximoSobrecalentamiento;
    }
}
