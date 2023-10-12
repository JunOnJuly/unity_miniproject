using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

// 점수와 게임 오버 여부를 관리하는 게임 매니저
public class GameManager : MonoBehaviour {
    // 싱글톤 접근용 프로퍼티
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    public CinemachineVirtualCamera TPSCamera;
    public CinemachineVirtualCamera FPSCamera;
    public Canvas RedDot;

    public int gameMoney;
    public bool isShop = false;
    public bool onShop = false;
    public string selectedItem = null;

    public int heartCount = 0;
    public int gunCount = 0;
    public int bulletCount = 0;
    public int speedCount = 0;

    public int heartPrice = 150;
    public int gunPrice = 150;
    public int blletPrice = 150;
    public int speedPrice = 150;

    public float heart = 100;
    public int gun = 20;
    public int bullet = 25;
    public int speed = 5;

    private void Awake() {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    private void Start() {
        // 플레이어 캐릭터의 사망 이벤트 발생시 게임 오버
        FindObjectOfType<PlayerHealth>().onDeath += EndGame;
        RedDot.enabled = false;
    }

    // 점수를 추가하고 UI 갱신
    public void AddScore(int newScore, int money) {
        // 게임 오버가 아닌 상태에서만 점수 증가 가능
        if (!isGameover)
        {
            // 점수 추가
            score += newScore;
            gameMoney += money;
            // 점수 UI 텍스트 갱신
            UIManager.instance.UpdateScoreText(score);
            UIManager.instance.UpdateMoeyText(gameMoney);
        }
    }

    // 게임 오버 처리
    public void EndGame() {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UIManager.instance.SetActiveGameoverUI(true);
    }

    private void Update()
    {
        ChangeCamera();
    }


    public void ChangeCamera()
    {
        if (!GameManager.instance.onShop)
        {
            if (Input.GetMouseButtonDown(1))
            {
                TPSCamera.Priority = 0;
                RedDot.enabled = true;
                FPSCamera.Priority = 1;
            }

            else if (Input.GetMouseButtonUp(1))
            {
                TPSCamera.Priority = 1;
                RedDot.enabled = false;
                FPSCamera.Priority = 0;
            }
        }
    }

}