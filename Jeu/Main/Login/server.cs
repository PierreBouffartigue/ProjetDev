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

	//Quand le bouton est cliqué il devient indisponible le temps de la vérification 
	public void OnLoginButtonClicked ()
	{
		loginButton.interactable = false;
		StartCoroutine (Login ());
	}

	IEnumerator Login ()
	{
		form = new WWWForm ();
		
		//Envoi les identifiants au serveur web pour qu'il les valide
		form.AddField ("username", username.text);
		form.AddField ("password", password.text);

		WWW w = new WWW (url, form);
		yield return w;

		//Si le serveur web est injoignable alors le message "Erreur" apparait
		if (w.error != null) {
			errorMessages.text = "Erreur";
			Debug.Log("<color=red>"+w.text+"</color>");
		} else {
			if (w.isDone) {
				//Si la liaison au serveur web est bonne et que les identifiants entrés sont invalides alors un message d'erreur apparait
				if (w.text.Contains ("error")) {
					errorMessages.text = "Identifiant invalide";
					Debug.Log("<color=red>"+w.text+"</color>");
				//Une fois l'authentification réussie, la première scène est chargée
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
