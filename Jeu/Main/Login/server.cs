using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class server : MonoBehaviour
{
	[SerializeField] InputField username;
	[SerializeField] InputField password;
	[SerializeField] Text errorMessages;
	[SerializeField] Button loginButton;
	[SerializeField] string url;

	WWWForm form;

	public void OnLoginButtonClicked ()
	{
		loginButton.interactable = false;
		StartCoroutine (Login ());
	}

	IEnumerator Login ()
	{
		form = new WWWForm ();

		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		WWW w = new WWW (url, form);
		yield return w;

		if (w.error != null) {
			errorMessages.text = "Erreur";
			Debug.Log("<color=red>"+w.text+"</color>");
		} else {
			if (w.isDone) {
				if (w.text.Contains ("error")) {
					errorMessages.text = "Identifiant invalide";
					Debug.Log("<color=red>"+w.text+"</color>");
				} else {
					SceneManager.LoadScene(1);
					Debug.Log("<color=green>"+w.text+"</color>");
				}
			}
		}

		loginButton.interactable = true;

		w.Dispose ();
	}
}
