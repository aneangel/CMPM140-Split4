using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //public VerticalPlatformController verticalPlatform;
    [SerializeField] private Sprite pressedImage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressedImage; //Changing Sprite
            this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.green; //Changing colour of sprite to green
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //Deactivating BoxCollider2D
            //verticalPlatform.MoveUp();
        }
    }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         verticalPlatform.MoveDown();
    //     }
    // }
}
