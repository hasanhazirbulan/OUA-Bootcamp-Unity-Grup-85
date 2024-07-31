using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class points : MonoBehaviour
{
   
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        if (_text != null)
        {
            _text.text = score.totalScore.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            _audio.Play();
            Destroy(other.gameObject);
            score.totalScore++;
            _text.text = score.totalScore.ToString();
        }
    }
}