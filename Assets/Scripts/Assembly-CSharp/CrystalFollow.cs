using UnityEngine;
using System.Collections;

public class CrystalFollow : MonoBehaviour
{
    [Header("Налаштування польоту кристала")]
    public Vector3 headOffset = new Vector3(0f, 0.5f, 0f);

    [Header("Налаштування підказки")]
    public GameObject heavyWarningText;
    public float warningShowTime = 2.5f;

    public static bool isAnyCrystalFollowing = false;
    private static float lastPickupTime = -10f;

    private Transform playerHead;
    private bool isFollowing;
    private bool isPlaced;
    private string glowEffectName = "GlowEffect";
    private Coroutine hideWarningCoroutine;

    private void Start()
    {
        if (!isFollowing && !isPlaced)
        {
            isAnyCrystalFollowing = false;
        }

        if (heavyWarningText != null)
        {
            heavyWarningText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Взаємодія з гравцем
        if (collision.CompareTag("Player"))
        {
            // Беремо перший кристал
            if (!isFollowing && !isPlaced && !isAnyCrystalFollowing)
            {
                playerHead = collision.transform.Find("HeadPoint");
                if (playerHead != null)
                {
                    isFollowing = true;
                    isAnyCrystalFollowing = true;
                    lastPickupTime = Time.time;

                    // Колайдер залишаємо УВІМКНЕНИМ як тригер, щоб він міг торкнутися формочки (Socket)!
                    GetComponent<Collider2D>().isTrigger = true;
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }
                }
            }
            // Підійшли до іншого кристала, коли вже тримаємо один
            else if (!isFollowing && !isPlaced && isAnyCrystalFollowing && (Time.time - lastPickupTime > 0.3f))
            {
                ShowHeavyWarning();
            }
        }

        // 2. Взаємодія з формочкою (Socket) — повертаємо вставку кристала!
        if (collision.CompareTag("Socket") && isFollowing)
        {
            PlaceInSocket(collision.transform);
        }
    }

    private void Update()
    {
        if (isFollowing && playerHead != null)
        {
            transform.position = playerHead.position + headOffset;
        }
    }

    public void PlaceInSocket(Transform socketTransform)
    {
        isFollowing = false;
        isPlaced = true;
        isAnyCrystalFollowing = false;

        transform.position = socketTransform.position;
        Transform glow = socketTransform.Find(glowEffectName);
        if (glow != null)
        {
            glow.gameObject.SetActive(true);
        }

        socketTransform.GetComponent<Collider2D>().enabled = false;
        LevelManager levelManager = Object.FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.AddCrystal();
        }
    }

    private void ShowHeavyWarning()
    {
        if (heavyWarningText == null) return;

        heavyWarningText.SetActive(true);

        if (hideWarningCoroutine != null)
            StopCoroutine(hideWarningCoroutine);

        hideWarningCoroutine = StartCoroutine(HideWarningRoutine());
    }

    private IEnumerator HideWarningRoutine()
    {
        yield return new WaitForSeconds(warningShowTime);
        if (heavyWarningText != null)
            heavyWarningText.SetActive(false);
    }
}