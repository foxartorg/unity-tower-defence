using System.Collections;
using UnityEngine;

namespace Enemy {
    public class SpawnEnemy : MonoBehaviour {
        [SerializeField] private GameObject enemyPrefab;
        private int


        private void Start() {
                StartCoroutine(EnemySpawn());
        }
        private IEnumerator EnemySpawn() {
            for (var i = 0; i < 5; i++) {
                CreateEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
        private void CreateEnemy() {
            Instantiate(enemyPrefab,transform.position,transform.rotation);



        }
    }
}
