using UnityEngine;

public class projectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����ӵ���ײ����������
        if (other.CompareTag("Respawn")) // �����ϰ����tagΪ"Obstacle"
        {
            // ����ײ���ϰ���ʱ���д������粥�ű�ըЧ����
            // ...

            // Ȼ�������ӵ�����
            Destroy(gameObject);
        }
    }
}
