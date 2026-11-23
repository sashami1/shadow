using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static int maxHearts = 3;
    public static int currentHearts = 3;

    [Header("ѕерет€гни сюди 3 об'Їкти сердець (Image)")]
    public Image[] hearts;

    [Header("—прайти червоного (повного) та с≥рого (порожнього) серц€")]
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    private void Start()
    {
        if (currentHearts <= 0)
        {
            currentHearts = maxHearts;
        }
        UpdateHeartsUI();
    }

    private void Update()
    {
        UpdateHeartsUI();
    }

    public void UpdateHeartsUI()
    {
        if (hearts == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].enabled = true;
                hearts[i].sprite = (i < currentHearts) ? fullHeartSprite : emptyHeartSprite;
            }
        }
    }

    public static void LoseHeart(int amount = 1)
    {
        currentHearts = Mathf.Clamp(currentHearts - amount, 0, maxHearts);
    }

    public static void ResetHearts()
    {
        currentHearts = maxHearts;
    }
}