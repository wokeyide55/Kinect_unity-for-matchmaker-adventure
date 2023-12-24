using UnityEngine;

public class projectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 如果子弹碰撞到其他物体
        if (other.CompareTag("Respawn")) // 假设障碍物的tag为"Obstacle"
        {
            // 在碰撞到障碍物时进行处理，比如播放爆炸效果等
            // ...

            // 然后销毁子弹对象
            Destroy(gameObject);
        }
    }
}
