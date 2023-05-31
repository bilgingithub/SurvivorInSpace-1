using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceProject;
// erhan


public class Auto_Fire : MonoBehaviour
{

    public Transform GunBarrel; // Silah namlusu
    public string EnemyTag = "Enemy"; // Düşman tag'ı
    public float DetectionRadius = 20f; // Algılama yarıçapı
    public float RotationSpeed = 5f; // Dönüş hızı
    public float FireInterval = 2f; // Ateş etme aralığı

    private float m_fireTimer = 0f; // Ateş etme zamanlayıcısı

    private void Update()
    {
        // En yakın düşmanı bul
        GameObject closestEnemy = FindClosestEnemy();

        // Dönme ve ateş etme işlemleri
        if (closestEnemy != null)
        {
            // Karakteri düşmana döndür
            Vector3 direction = closestEnemy.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

            // Ateş etme zamanlayıcısı kontrolü
            m_fireTimer += Time.deltaTime;
            if (m_fireTimer >= FireInterval)
            {
                // Ateş etme işlemi
                Fire(closestEnemy);

                m_fireTimer = 0f; // Zamanlayıcıyı sıfırla
            }
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        return closestEnemy;
    }

    private void Fire(GameObject enemy)
    {
        // Mermi oluştur
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = GunBarrel.position;
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

        // Mermiye hedefi atayarak düşmana doğru hareket etmesini sağla
        BulletMovement bulletMovement = bullet.AddComponent<BulletMovement>();
        bulletMovement.SetTarget(enemy);
        bulletMovement.OnEnemyHit += DestroyEnemy;
    }

    private void DestroyEnemy(GameObject enemy)
    {
        if (enemy != null)
        {
            Destroy(enemy);
        }
    }




}
