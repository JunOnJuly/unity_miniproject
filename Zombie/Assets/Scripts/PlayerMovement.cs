using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public int moveSpeed = 5; // 앞뒤 움직임의 속도
    public float mouseSpeed = 5000f;

    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate() {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        moveSpeed = GameManager.instance.speed;
        if (!GameManager.instance.onShop)
        {
            Rotate();
            Move();
            playerAnimator.SetFloat("Move", playerInput.move);
            playerAnimator.SetFloat("Move", playerInput.rotate);
        }
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        Vector3 verMove = playerInput.rotate * transform.right * moveSpeed * Time.deltaTime;
        Vector3 horMove = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;

        Vector3 moveDistance = verMove + horMove;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        float xRotateSize = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, xRotateSize, 0);
    }
}