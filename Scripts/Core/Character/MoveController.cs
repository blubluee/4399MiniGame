using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float _speed = 5f;

    [SerializeField]
    private float height = 2f;
    [SerializeField]
    private float radius = 0.5f;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveDistance = _speed * Time.deltaTime;
        Vector3 moveDir = Vector3.zero;
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        moveDir = moveDir.normalized;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * height, radius,
            moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            // 判断x轴方向是否可以移动
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * height, radius,
                moveDirX, moveDistance);
            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                // 判断z轴方向是否可以移动
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position,
                    transform.position + Vector3.up * height, radius, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
            }
        }
        
        if (canMove) // 移动
        {
            transform.position += moveDir * moveDistance;
        }
        
        // 转向
        const float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
    }
}
