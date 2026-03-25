using UnityEngine;

public class ControllerScene2 : MonoBehaviour
{

    public Timer tiempoJuego;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        tiempoJuego.TimerStart();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowGlobalTime()
    {
        Debug.Log("Tiempo total: " + GameManager.Instance.GlobalTime);
    }

    public void GetTimeScene()
    {

        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

}
