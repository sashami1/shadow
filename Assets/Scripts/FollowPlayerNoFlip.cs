using UnityEngine;

public class FollowPlayerNoFlip : MonoBehaviour
{
    public Transform playerTransform; // ѕерет€гни сюди об'Їкт Player
    public Vector3 offset = new Vector3(0f, 2.5f, 0f); // ¬исота над персонажем

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // —л≥дуЇмо за позиц≥Їю гравц€, але не коп≥юЇмо його розворот (Scale)
            transform.position = playerTransform.position + offset;
        }
    }
}