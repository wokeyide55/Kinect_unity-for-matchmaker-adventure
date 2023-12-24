using UnityEngine;

public class RandomFallingUI : MonoBehaviour
{
    public GameObject[] uiElementPrefabs; // ��Ϸ�����Ԥ�Ƽ�
    public float fallSpeed = 5f; // �����ٶ�
    public float spawnInterval = 1f; // ���ɼ��ʱ��
    public float startDelay = 5f; // ��ʼ����ǰ���ӳ�ʱ�䣬�ȴ��̳���ʾ���

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        // ��ʼ����ǰ�ȴ�5��
        InvokeRepeating("SpawnUIElement", startDelay, spawnInterval);
    }

    void SpawnUIElement()
    {
        GameObject selectedPrefab = uiElementPrefabs[Random.Range(0, uiElementPrefabs.Length)];

        // ������Ļ�߽�
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        float spawnXPosition = Random.Range(-screenBounds.x, screenBounds.x);

        // ����Ļ�Ϸ����λ������Ԥ�Ƽ�
        Vector3 spawnPosition = new Vector3(spawnXPosition, screenBounds.y + 1, 0);
        GameObject newElement = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        // ���ø���������ٶ�
        Rigidbody2D rb = newElement.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -fallSpeed);
    }
}
