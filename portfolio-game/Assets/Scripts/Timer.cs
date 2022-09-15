using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI text;

    public int Duration;

    private int remainingDuration;

    private bool Pause;

    // Start is called before the first frame update
    private void Start()
    {
        Being(Duration);
        Debug.Log("thisran");
    }

    // Update is called once per frame
    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
        Debug.Log("thisran");
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                text.text = $"{remainingDuration}";
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        //End turn when timer is done
    }
}
