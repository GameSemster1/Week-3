using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public Image[] hearts; // Image of heart
    private int life = 3;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == triggeringTag && enabled)
        {
            life--;
            Destroy(hearts[life]);
            if (life == 0)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            
        }
    }
}
