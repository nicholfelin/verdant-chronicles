using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Referensi untuk sprite renderer background
    public SpriteRenderer backgroundRenderer;

    // Sprite siang dan malam
    public Sprite daySprite;
    public Sprite nightSprite;

    // Durasi siang dan malam (dalam detik)
    public float dayDuration = 10f;  // 10 detik untuk siang
    public float nightDuration = 10f; // 10 detik untuk malam

    // Timer untuk pergantian siang-malam
    private float timer;
    private bool isDay = true;  // Mulai dari siang

    void Start()
    {
        // Set sprite awal ke siang
        backgroundRenderer.sprite = daySprite;
        timer = dayDuration;  // Mulai hitung waktu untuk siang
    }

    void Update()
    {
        // Kurangi timer setiap frame
        timer -= Time.deltaTime;

        if (isDay && timer <= 0)
        {
            // Beralih ke malam
            SwitchToNight();
        }
        else if (!isDay && timer <= 0)
        {
            // Beralih ke siang
            SwitchToDay();
        }
    }

    // Fungsi untuk mengganti ke background malam
    void SwitchToNight()
    {
        backgroundRenderer.sprite = nightSprite;
        isDay = false;
        timer = nightDuration;  // Reset timer untuk malam
    }

    // Fungsi untuk mengganti ke background siang
    void SwitchToDay()
    {
        backgroundRenderer.sprite = daySprite;
        isDay = true;
        timer = dayDuration;  // Reset timer untuk siang
    }
}
