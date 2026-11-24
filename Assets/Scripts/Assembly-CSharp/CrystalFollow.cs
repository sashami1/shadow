using UnityEngine;

public class CrystalFollow : MonoBehaviour
{
    public Vector3 headOffset = new Vector3(0f, 0.5f, 0f);

    public static bool isAnyCrystalFollowing = false;

    private Transform playerHead;
    private bool isFollowing;
    private bool isPlaced;
    private string glowEffectName = "GlowEffect";

    private void Start()
    {
        if (!isFollowing && !isPlaced)
        {
            isAnyCrystalFollowing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFollowing && !isPlaced && !isAnyCrystalFollowing)
        {
            playerHead = collision.transform.Find("HeadPoint");
            if (playerHead != null)
            {
                isFollowing = true;
                isAnyCrystalFollowing = true;

                GetComponent<Collider2D>().isTrigger = true;
                Rigidbody2D component = GetComponent<Rigidbody2D>();
                if (component != null)
                {
                    component.isKinematic = true;
                }
            }
        }

        if (collision.CompareTag("Socket") && isFollowing)
        {
            PlaceInSocket(collision.transform);
        }
    }

    private void Update()
    {
        if (isFollowing && playerHead != null)
        {
            base.transform.position = playerHead.position + headOffset;
        }
    }

    private void PlaceInSocket(Transform socketTransform)
    {
        isFollowing = false;
        isPlaced = true;

        isAnyCrystalFollowing = false;

        base.transform.position = socketTransform.position;
        Transform transform = socketTransform.Find(glowEffectName);
        if (transform != null)
        {
            transform.gameObject.SetActive(value: true);
        }
        else
        {
            Debug.LogWarning("У формочці '" + socketTransform.name + "' не знайдено об'єкт 'GlowEffect'!");
        }

        socketTransform.GetComponent<Collider2D>().enabled = false;
        LevelManager levelManager = Object.FindObjectOfType<LevelManager>();
        if (levelManager != null)
        {
            levelManager.AddCrystal();
        }
        Debug.Log("Кристал встановлено!");
    }
}