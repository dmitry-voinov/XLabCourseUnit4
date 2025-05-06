using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : GameState
    {
        public LevelController LevelController;
        public PlayerController PlayerController;
        public GameState gameOverState;
        public TMP_Text scoreText;


        protected override void OnEnable()
        {
            base.OnEnable();

            LevelController.enabled = true;
            PlayerController.enabled = true;

            GameEvents.onCollisionStones += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
            OnStickHit();
        }

        private void OnStickHit()
        {
            scoreText.text = $" Score: {LevelController.score}";
        }

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStones -= OnGameOver;

            LevelController.enabled = false;
            PlayerController.enabled = false;
        }
    }
}
