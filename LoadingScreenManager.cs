using System.Collections;  // Tambahkan ini untuk mendukung IEnumerator
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; 

public class LoadingScreenManager : MonoBehaviour
{
    public string sceneToLoad;  // Nama scene yang akan diload
    public Image playerImage;   // Gambar atau Sprite animasi player
    public TextMeshProUGUI loadingText;
 public Slider progressBar;  // Slider untuk progres bar

    private Animator playerAnimator;  // Animator untuk player berjalan

    void Start()
    {
        playerAnimator = playerImage.GetComponent<Animator>();
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
            loadingText.text = (progress * 100f).ToString("F0") + "%";
            progressBar.value = progress;  // Update progres bar

            // Play animasi player
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("isWalking", true);  // Jika animasi dibuat dengan parameter
            }

            yield return null;
        }
    }
}
