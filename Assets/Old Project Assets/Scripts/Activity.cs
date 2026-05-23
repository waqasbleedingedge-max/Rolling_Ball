using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NA.Vehicles.Ball;
using UnityStandardAssets.Utility;

namespace NA
{
    public class Activity : SimpleSingleton<Activity>
    {
        public bool Water_Lava;
        public float startDelay;

        public SmoothFollow smf;
        public GameObject player;
        public Transform playerPos;

        public Transform playerPosToSpawn;
        public GameObject TrackObj;

        public Transform[] wayPoints;
        public UnityEvent StartEvent, EnableEvent, InitEvent;

        void OnEnable()
        {
            // GameObject smfG = GameObject.FindGameObjectWithTag("Cam");
            // smf = smfG.GetComponent<SmoothFollow>();
            // player = GameObject.FindGameObjectsWithTag("Player");
            StartCoroutine(StartLevel());
           // player = LevelManager.Instance.Ball_Ref.gameObject;
            //playerPos = player.transform;
           // LevelManager.Instance.currentCheckpointTransform = playerPosToSpawn;
            //  smf.target = playerPosToSpawn;
            EnableEvent.Invoke();
            Invoke(nameof(call), 0.1f);
        }

        void call()
        {
          //  LevelManager.Instance.Btn_Water_Lava(Water_Lava);
        }

        IEnumerator StartLevel()
        {
            //   Debug.Log("Spawn Player Run Activity");
            yield return new WaitForSeconds(startDelay);
            // StartEvent.Invoke();
            //  SpawnPlayer();
            //  Debug.Log("Spawn Player Run Activity Later");
          //  BallUserControl.Instance.SpawnPlayer(playerPosToSpawn);
        }

        public void SpawnPlayer(int i)
        {
            player = Instantiate(ReferenceManager.Instance.playersPrefabs[i]);
            player.transform.SetPositionAndRotation(playerPos.position, playerPos.rotation);
        }

        public void SpawnPlayer()
        {
            player.transform.SetPositionAndRotation(new Vector3(playerPos.position.x, playerPos.position.y + 0.5f, playerPos.position.z), playerPos.rotation);
            //  t.SetLocalPositionAndRotation(transform.position, transform.localRotation);
            //  Invoke("isKinameticFalse", 0.2f);

        }
    }
}