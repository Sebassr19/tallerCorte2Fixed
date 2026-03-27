using TMPro;
using UnityEngine;

public class ControllerScene1 : MonoBehaviour
{
    public Timer tiempoJuego;

    public TextMeshProUGUI txtCountApple;
    public TextMeshProUGUI txtCountOrange;
    public TextMeshProUGUI txtCountBanana;
    public TextMeshProUGUI txtCountKiwi;

    private void Start()
    {
        if (!ReferenceEquals(tiempoJuego, null))
        {
            tiempoJuego.TimerStart();
        }

        ActualizarUI();
    }

    private void Update()
    {
        ActualizarUI();
    }

    public void GetTimeScene()
    {
        if (!ReferenceEquals(GameManager.Instance, null) && !ReferenceEquals(tiempoJuego, null))
        {
            GameManager.Instance.TotalTime(tiempoJuego.StopTime);
        }
    }

    private void ActualizarUI()
    {
        if (ReferenceEquals(GameManager.Instance, null))
        {
            Debug.LogWarning("GameManager.Instance es null");
            return;
        }

        if (!ReferenceEquals(txtCountApple, null))
            txtCountApple.text = GameManager.Instance.TotalApple.ToString();

        if (!ReferenceEquals(txtCountOrange, null))
            txtCountOrange.text = GameManager.Instance.TotalOrange.ToString();

        if (!ReferenceEquals(txtCountBanana, null))
            txtCountBanana.text = GameManager.Instance.TotalBanana.ToString();

        if (!ReferenceEquals(txtCountKiwi, null))
            txtCountKiwi.text = GameManager.Instance.TotalKiwi.ToString();

        Debug.Log(
            "UI -> Apple: " + GameManager.Instance.TotalApple +
            " Orange: " + GameManager.Instance.TotalOrange +
            " Banana: " + GameManager.Instance.TotalBanana +
            " Kiwi: " + GameManager.Instance.TotalKiwi
        );
    }
}

