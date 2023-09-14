using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownGameManager : MonoBehaviour
{
    [SerializeField]
	private Text _textCountdown;
    // Start is called before the first frame update
    void Start()
    {
        _textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());

    }
    IEnumerator CountdownCoroutine()
	{
		_textCountdown.text = "3";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "2";
		yield return new WaitForSeconds(1.0f);
 
		_textCountdown.text = "1";
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "GO!";
		yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Game");//ゲーム画面に遷移
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}