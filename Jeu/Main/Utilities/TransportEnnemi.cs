using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class TransportEnnemi : MonoBehaviour {
	public Button BoutonVoyageEnnemi;

	void Start () {
		Button btn = BoutonVoyageEnnemi.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene(2);
	}
}