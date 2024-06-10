using UnityEngine;

public class CCWcollision : MonoBehaviour
{
    // 스킬 충돌처리
    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            // 충돌처리
            Debug.Log("Enemy was hit!");
        }
    }
}
