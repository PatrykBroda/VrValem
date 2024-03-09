using UnityEngine;

[CreateAssetMenu(fileName = "FireConfiguration", menuName = "ScriptableObjects/FireConfiguration", order = 1)]
public class FireConfiguration : ScriptableObject
{
    // Define the fields you want to store in the ScriptableObject
    public float damage = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float ProjectileLifeTime = 5f;
   
    // You can add any additional configuration data or methods as needed
}
