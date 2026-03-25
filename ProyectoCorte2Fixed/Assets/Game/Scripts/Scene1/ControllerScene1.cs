using TMPro;
using UnityEngine;

public class ControllerScene1 : MonoBehaviour
{

    public Timer tiempoJuego;

    public TextMeshProUGUI txtCountApple;
    public TextMeshProUGUI txtCountOrange;
    public TextMeshProUGUI txtCountBanana;
    public TextMeshProUGUI txtCountKiwi;

    void Start()
    {
        tiempoJuego.TimerStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetTimeScene()
    {

        GameManager.Instance.TotalTime(tiempoJuego.StopTime);
    }

    public void GetTotalItem()
    {
        txtCountApple.text = GameManager.Instance.TotalApple.ToString();
        txtCountOrange.text = GameManager.Instance.TotalOrange.ToString();
        txtCountOrange.text = GameManager.Instance.TotalKiwi.ToString();
        txtCountOrange.text = GameManager.Instance.TotalBanana.ToString();
    }    

}

