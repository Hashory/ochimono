using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rain")
        {
            OnHitRain();
        }
    }

    private void OnHitRain()
    {
        Debug.Log("Hit Rain");
        InGameManager.Instance.ReducePlayerHP();
    }
}
