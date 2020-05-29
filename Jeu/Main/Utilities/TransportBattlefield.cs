using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransportBattlefield : MonoBehaviour
{
	public Button ButtonAttack;

	void Start()
	{
		Button btn = ButtonAttack.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene(3);
	}
}
