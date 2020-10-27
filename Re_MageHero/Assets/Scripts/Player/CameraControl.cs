using UnityEngine;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float MaxZ;
    [SerializeField] private float MinZ;

    private void Update()
    {

        Vector3 pos = transform.position;
        pos.z = player.position.z - 10;

        if (pos.z > MaxZ) pos.z = MaxZ;
        if (pos.z < MinZ) pos.z = MinZ;

        transform.position = pos;

    }

}
