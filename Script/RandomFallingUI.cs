using UnityEngine;

public class RandomFallingUI : MonoBehaviour
{
    public GameObject[] uiElementPrefabs; // 游戏对象的预制件
    public float fallSpeed = 5f; // 下落速度
    public float spawnInterval = 1f; // 生成间隔时间
    public float startDelay = 5f; // 开始生成前的延迟时间，等待教程显示完毕

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        // 开始生成前等待5秒
        InvokeRepeating("SpawnUIElement", startDelay, spawnInterval);
    }

    void SpawnUIElement()
    {
        GameObject selectedPrefab = uiElementPrefabs[Random.Range(0, uiElementPrefabs.Length)];

        // 计算屏幕边界
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        float spawnXPosition = Random.Range(-screenBounds.x, screenBounds.x);

        // 在屏幕上方随机位置生成预制件
        Vector3 spawnPosition = new Vector3(spawnXPosition, screenBounds.y + 1, 0);
        GameObject newElement = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        // 设置刚体的下落速度
        Rigidbody2D rb = newElement.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -fallSpeed);
    }
}
