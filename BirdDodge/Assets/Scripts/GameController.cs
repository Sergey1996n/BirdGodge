using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject rating;

    private float boundaryX;
    private float timer = 1;
    private bool ispuse;

    [Header("Настройки бомб")]
    [Tooltip("Список")]
    public List<BombData> bombsSettings;
    [Tooltip("Количество объектов в пуле")]
    public int bombsPoolCount;
    [Tooltip("Ссылка на базовый префаб")]
    public GameObject bombPrefab;
    [Tooltip("Время между спауном")]
    public float bombSpawnTime;

    [Header("Настройки Action")]
    [Tooltip("Список Action")]
    public List<ActionData> actionsSettings;
    [Tooltip("Количество объектов в пуле")]
    public int actionPoolCount;
    [Tooltip("Ссылка на базовый префаб")]
    public GameObject actionPrefab;
    [Tooltip("Время между спауном")]
    public float actionSpawnTime;

    public static Dictionary<GameObject, Bomb> bombs;
    public static Dictionary<GameObject, Action> actions;
    private Queue<GameObject> currentBombs;
    private Queue<GameObject> currentActions;

    void Start()
    {
        if (!PublicClass.rating.Item2)
            PublicClass.rating.Item1++;

        Transform trCanvas = canvas.GetComponent<Transform>();
        CircleCollider2D ccAsteroidPrefab = bombPrefab.GetComponent<CircleCollider2D>();
        Transform trAsteroidPrefab = bombPrefab.GetComponent<Transform>();
        boundaryX = Screen.width / 2 * trCanvas.localScale.x - ccAsteroidPrefab.radius * trAsteroidPrefab.localScale.x;

        SettingsBomb();
        SettingsAction();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!lose.activeInHierarchy && !rating.activeInHierarchy)
            {
                if (!ispuse)
                    timer = 1f;
                else
                    timer = 0;
                ispuse = !ispuse;
                Time.timeScale = timer;

            }
            else
                Time.timeScale = 1;
        }

        score.GetComponent<Text>().text = PublicClass.coint.ToString();
    }

    void SettingsBomb()
    {
        bombs = new Dictionary<GameObject, Bomb>();
        currentBombs = new Queue<GameObject>();
        for (int i = 0; i < bombsPoolCount; i++)
        {
            var prefab = Instantiate(bombPrefab);
            var script = prefab.GetComponent<Bomb>();
            prefab.SetActive(false);
            bombs.Add(prefab, script);
            currentBombs.Enqueue(prefab);
        }

        Bomb.onBombOverFly += ReturnBomb;

        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        while (!Player.lose)
        {
            yield return new WaitForSeconds(bombSpawnTime);
            if (currentBombs.Count > 0)
            {
                var bomb = currentBombs.Dequeue();
                var script = bombs[bomb];
                bomb.SetActive(true);

                int rand = Random.Range(0, bombsSettings.Count);
                script.Init(bombsSettings[rand]);

                bomb.transform.position = new Vector2(Random.Range(-boundaryX, boundaryX), transform.position.y);
            }
        }
        lose.SetActive(true);
    }

    private void ReturnBomb(GameObject _bomb)
    {
        _bomb.transform.position = new Vector2(0, 6f);
        _bomb.SetActive(false);
        currentBombs.Enqueue(_bomb);
    }

    void SettingsAction()
    {
        actions = new Dictionary<GameObject, Action>();
        currentActions = new Queue<GameObject>();
        for (int i = 0; i < actionPoolCount; i++)
        {
            var prefab = Instantiate(actionPrefab);
            var script = prefab.GetComponent<Action>();
            prefab.SetActive(false);
            actions.Add(prefab, script);
            currentActions.Enqueue(prefab);
        }

        Action.onActionOverFly += ReturnAction;

        StartCoroutine(SpawnAction());
    }

    IEnumerator SpawnAction()
    {
        while (!Player.lose)
        {
            yield return new WaitForSeconds(actionSpawnTime);
            if (currentActions.Count > 0)
            {
                var action = currentActions.Dequeue();
                var script = actions[action];
                action.SetActive(true);

                int rand = Random.Range(0, actionsSettings.Count);
                script.Init(actionsSettings[rand]);

                action.transform.position = new Vector2(Random.Range(-boundaryX, boundaryX), transform.position.y);
            }
        }
    }

    private void ReturnAction(GameObject _action)
    {
        _action.transform.position = new Vector2(0, 6f);
        _action.SetActive(false);
        currentActions.Enqueue(_action);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("X2", PublicClass.x2.Item1);
        PlayerPrefs.SetInt("Shield", PublicClass.shield.Item1);
        PlayerPrefs.SetInt("Timer", PublicClass.timer.Item1);
    }
}
