using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenManager : MonoBehaviour
{
    public string sceneToLoad;  // Nama scene yang akan diload
    public TextMeshProUGUI loadingText;  // Text untuk menampilkan loading progress
    public Slider progressBar;  // Slider untuk progres bar

    public float moveSpeed = 2f;  // Kecepatan gerakan pemain
    public Vector2 moveDirection = Vector2.right;  // Arah gerakan, bisa diubah ke kiri/kanan/atas/bawah
    private Animator playerAnimator;  // Animator untuk player berjalan
    private Rigidbody2D rb;  // Rigidbody2D untuk pergerakan pemain

    private void Start()
    {
        // Mendapatkan komponen Animator dan Rigidbody2D
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Memulai animasi berjalan dan memulai coroutine untuk load scene secara async
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Memulai load scene secara async
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        
        // Loop untuk terus update selama loading berlangsung
        while (!operation.isDone)
        {
            // Kalkulasi loading progress
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Unity load sampai 90%, jadi skalanya diatur
            loadingText.text = (progress * 100f).ToString("F0") + "%";  // Update text progress
            progressBar.value = progress;  // Update progres bar

            // Menggerakkan pemain secara otomatis
            if (rb != null)
            {
                rb.velocity = moveDirection * moveSpeed;
            }

            yield return null;  // Menunggu frame berikutnya
        }
    }
}
