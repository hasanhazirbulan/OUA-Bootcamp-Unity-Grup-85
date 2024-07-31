using UnityEngine;
using TMPro;

public class Diamond : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private AudioSource _audio;

    private void Awake()
    {
        // Component'leri doğru bir şekilde atayın
        _audio = GetComponent<AudioSource>();
        if (_text == null)
        {
            Debug.LogError("TextMeshProUGUI component is not assigned to Points script!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Diamond"))
        {
            // Elmas nesnesini yok et
            Destroy(other.gameObject);

            // Puanı artır
            score.totalScore++;

            // Puanı UI üzerinde güncelle
            UpdateScoreUI();
            
            // Ses efektini çal
            if (_audio != null)
            {
                _audio.Play();
            }
            else
            {
                Debug.LogWarning("AudioSource component is not assigned to Points script!");
            }
        }
    }

    private void UpdateScoreUI()
    {
        // _text null değilse ve score.totalScore güncellenmişse
        if (_text != null)
        {
            _text.text = "Score: " + score.totalScore.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component is not assigned to Points script!");
        }
    }
}
