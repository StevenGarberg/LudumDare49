﻿using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField]
    private float _secondsUntilDestroy = 1.0f;

    private void Start()
    {
        Destroy(gameObject, _secondsUntilDestroy);
    }
}