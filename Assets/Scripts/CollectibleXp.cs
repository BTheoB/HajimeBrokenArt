using UnityEngine;

public class CollectibleXp : MonoBehaviour
{
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    PlayerController controller = other.GetComponent<PlayerController>();
    //    if(controller != null && controller.health < controller.maxHealth )
    //    {
    //        controller.AddHealth(1);
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.AddEnergie(Random.Range(1, 5));
            Destroy(gameObject);
        }
    }
}
