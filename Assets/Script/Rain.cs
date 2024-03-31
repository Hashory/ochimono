using UnityEngine;

public class Rain : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Rain")
        {
            Destroy(gameObject);
        }
    }

}
