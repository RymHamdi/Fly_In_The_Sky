using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalTimer : MonoBehaviour
{
    private static GlobalTimer instance;
    private float startTime;
    private float lastRecordedTime;
    private bool isCounting;

    public TextMeshProUGUI timerText;

    public static GlobalTimer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalTimer>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "GlobalTimer";
                    instance = obj.AddComponent<GlobalTimer>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isCounting)
        {
            float currentTime = Time.time - startTime;
            UpdateTimerText(currentTime);
        }
    }

    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        timerText.SetText(""+ string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    public void StartCountUpTimer()
    {
        if (!isCounting)
        {
            startTime = Time.time;
            isCounting = true;
        }
    }

    public void StopTimerAndRecord()
    {
        if (isCounting)
        {
            lastRecordedTime = Time.time - startTime;
            isCounting = false;
        }
    }

    public void DisplayLastRecordedTime()
    {
        UpdateTimerText(lastRecordedTime);
    }
}
