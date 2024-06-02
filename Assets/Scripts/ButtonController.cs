using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //public VerticalPlatformController verticalPlatform;
    [SerializeField] private Sprite pressedImage;
    private bool pressed;

    void Start(){
        pressed = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pressedImage; //Changing Sprite
            this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.green; //Changing colour of sprite to green
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //Deactivating BoxCollider2D
            this.gameObject.GetComponent<AudioSource>().Play(); //Playing Audio
            pressed = true;
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

    public bool isPressed(){
        return pressed;
    }
}
