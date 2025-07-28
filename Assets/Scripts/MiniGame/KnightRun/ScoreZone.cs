using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!scored && other.CompareTag("Player"))
        {
            scored = true;

            Hole hole = transform.parent.GetComponent<Hole>();
            if (hole != null)
            {
                int score = hole.GetScoreByWidth();
                GameManager.Instance.AddScore(score);
                Debug.Log($"Player�� Hole�� �����ϰ� ��� - ����: {score}");
            }
        }
    }
    public void ResetScore()
    {
        scored = false;
    }
}
