using UnityEngine;

public class AutoRemove : MonoBehaviour
{
    public float inactiveTime = 60f;
    private float timer= 0f;

    void Update()
    {
        timer++;
        if (timer >= inactiveTime)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

}
