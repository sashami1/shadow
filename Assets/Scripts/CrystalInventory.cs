using UnityEngine;
using TMPro; // ѕотр≥бно дл€ роботи з TextMeshPro
using System.Collections;

public class CrystalInventory : MonoBehaviour
{
    [Header("Ќалаштуванн€ кристал≥в")]
    public bool hasCrystal = false; // „и тримаЇ персонаж кристал зараз
    public int deliveredCrystals = 0; // —к≥льки вже в≥днесено (з 4 на р≥вн≥)
    public int totalCrystalsOnLevel = 4;

    [Header("“екст попередженн€")]
    public GameObject warningTextObject; // —юди перет€гнеш WarningText
    public float warningDuration = 2.5f; // —к≥льки секунд висить фраза

    private Coroutine hideCoroutine;

    // ¬икликаЇтьс€, коли персонаж торкаЇтьс€ кристала
    public bool TryPickUpCrystal()
    {
        if (hasCrystal)
        {
            // якщо вже несе один кристал Ч показуЇмо попередженн€ ≥ не даЇмо вз€ти
            ShowWarning();
            return false;
        }

        // якщо руки в≥льн≥ Ч беремо кристал
        hasCrystal = true;
        return true;
    }

    // ¬икликаЇтьс€, коли персонаж доносить кристал до бази/дверей/в≥втар€
    public void DeliverCrystal()
    {
        if (hasCrystal)
        {
            hasCrystal = false;
            deliveredCrystals++;
            Debug.Log(" ристал здано! ¬сього на р≥вн≥: " + deliveredCrystals + "/" + totalCrystalsOnLevel);
        }
    }

    private void ShowWarning()
    {
        if (warningTextObject == null) return;

        warningTextObject.SetActive(true);

        // ѕерезапускаЇмо таймер зникненн€ тексту, €кщо гравець тиц€Їтьс€ в кристал к≥лька раз≥в
        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);

        hideCoroutine = StartCoroutine(HideWarningAfterDelay());
    }

    private IEnumerator HideWarningAfterDelay()
    {
        yield return new WaitForSeconds(warningDuration);
        warningTextObject.SetActive(false);
    }
}