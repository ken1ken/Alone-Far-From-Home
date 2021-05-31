using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

// Helped by: https://www.raywenderlich.com/9454-introduction-to-unity-unit-testing

namespace Tests
{
    /**
     * The test suite which tests Alone. Far from Home
     */
    public class TestSuite
    {
        [UnityTest]
        public IEnumerator PlayerIsCreated()
        {
            yield return LoadScene();
            
            GameObject player = GameObject.Find("Player");
            Assert.NotNull(player);
        }

        // [UnityTest]
        public IEnumerator TestMovement()
        {
            yield return LoadScene();
            
            GameObject player = GameObject.Find("Player");
            PlayerCameraMovement movement = player.GetComponent<PlayerCameraMovement>();
            
            // TODO: Somehow finish the test.
            // There is no easy way to simulate input in the base version of Unity.
            // Kinda idiotic, if you ask me.
            // movement.UpdateMovement();
        }

        /** Load the scene before each test, non-additively.
         * Then we need to wait for the scene to load. Even when using the non-async version of the loading method,
         * SceneManager.LoadScene, there is a race condition which makes the tests fail.
         */ 
        private WaitForSceneLoaded LoadScene()
        {
            SceneManager.LoadSceneAsync("SpaceStationGame", LoadSceneMode.Single);
            return new WaitForSceneLoaded("SpaceStationGame");
        }
    }
}
