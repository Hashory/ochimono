using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class RainSpawner : MonoBehaviour
{
    /// <summary>
    /// スポーンさせたいオブジェクトのプレファブ
    /// </summary>
    [SerializeField] private GameObject objectToSpawn;

    /// <summary>
    /// スポーンエリアの半径
    /// </summary>
    public float radius = 5f;

    /// <summary>
    /// スポーンエリアの高さ
    /// <summary>
    public float height = 5f;

    /// <summary>
    /// スポーンエリアの中心
    /// </summary>
    private Vector3 spawnAreaCenter;

    public float PlayerAboveProbability = 0.05f;

    public float SpawnSpeed = 0.5f;

    public Transform PlayerTransform;

    /// <summary>
    /// スポーンの状態
    /// </summary>
    private bool _isSpawning = false;

    private GameObject _parentObject;

    public bool IsSpawning
    {
        get => _isSpawning;
        set
        {
            if (_isSpawning == value) return; // 値が変わっていなければ何もしない

            _isSpawning = value;
            if (_isSpawning)
            {
                _parentObject = new GameObject("SpawnedObjects");
                StartCoroutine(SpawnRoutine()); // スポーン開始
            }
            else
            {
                StopAllCoroutines(); // すべてのCoroutineを停止
                Destroy(_parentObject); // 生成したオブジェクトを削除
            }
        }
    }



    private void Start()
    {
        spawnAreaCenter = transform.position;
    }

    private IEnumerator SpawnRoutine()
    {
        while (_isSpawning)
        {
            SpawnObject();
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }

    /// <summary>
    /// オブジェクトを指定されたエリア内にランダムに発生させる
    /// </summary>
    private void SpawnObject()
    {
        float angle = Random.Range(0, Mathf.PI * 2);

        Vector3 spawnPosition;
        if (Random.value < PlayerAboveProbability)
        {
            spawnPosition = new Vector3(
                PlayerTransform.position.x,
                spawnAreaCenter.y + Random.Range(-height / 2, height / 2), 
                PlayerTransform.position.z
            );
        }
        else
        {
             spawnPosition = spawnAreaCenter + new Vector3(
                Random.Range(0, radius) * math.cos(angle),
                Random.Range(-height / 2, height / 2),
                Random.Range(0, radius) * math.sin(angle)
            );
        }
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity, _parentObject.transform);
    }

}
