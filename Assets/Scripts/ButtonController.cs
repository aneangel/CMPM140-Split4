using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public VerticalPlatformController verticalPlatform;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            verticalPlatform.MoveUp();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            verticalPlatform.MoveDown();
        }
    }
}
