using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class TransportVillage : MonoBehaviour {
	public Button BoutonVoyageVillage;

	void Start () {
		Button btn = BoutonVoyageVillage.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene(0);
	}
}