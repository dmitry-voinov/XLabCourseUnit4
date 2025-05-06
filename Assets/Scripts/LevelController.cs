using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public StoneSpawner spawner;
        public float maxDelay = 2f;
        public float minDelay = 0.5f;
        public float delayStep = 0.1f;

        private float m_delay = 0.5f;

        private float m_lastSpawnedTime = 0;
        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnEnable()
        {
            Stone.onCollisionStone += GameOver;
        }
        private void OnDisable()
        {
            Stone.onCollisionStone -= GameOver;
        }
        private void GameOver()
        {
            enabled = false;
        }
        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(minDelay, maxDelay);
            maxDelay = Mathf.Max(minDelay, maxDelay - delayStep);
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                spawner.Spawn();
                m_lastSpawnedTime = Time.time;
                RefreshDelay();
            }
        }
    }
}
