using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// erhan
namespace SpaceProject
{
    public class BulletMovement : MonoBehaviour
    {
        private GameObject m_target; // Hedef düşman
        public float speed = 10f; // Mermi hızı

        public delegate void EnemyHitAction(GameObject enemy);
        public event EnemyHitAction OnEnemyHit;

        private void Update()
        {
            if (m_target != null)
            {
                Move(); // Mermiyi hareket ettir
            }
        }

        public void SetTarget(GameObject enemy)
        {
            m_target = enemy;
        }

        private void Move()
        {
            Vector3 direction = m_target.transform.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime); // Mermiyi hedefe doğru hareket ettir
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == m_target)
            {
                OnEnemyHit?.Invoke(m_target); // Hedefi yok etmek için olayı tetikle
                Destroy(other.gameObject); // Hedefi yok et
                Destroy(gameObject); // Mermiyi yok et
            }
        }
    }

}


