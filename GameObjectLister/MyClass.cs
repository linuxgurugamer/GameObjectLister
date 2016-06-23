using System;
using UnityEngine;

namespace GameObjectLister
{

	[KSPAddon(KSPAddon.Startup.EveryScene, false)]
	public class GOLF : MonoBehaviour
	{

		public Rect windowRect = new Rect(0, 0, 300, 500);
		public Vector2 scroll = new Vector2(0, 0);
		static string search = "";
		public bool understood = false;

		void Start ()
		{



		}

		void Update ()
		{

			if (search == "understood")
			{

				understood = true;

			}

		}

		void OnGUI ()
		{

			windowRect = GUI.Window(90923, windowRect, OnWindow, "GameObjects");

		}

		void OnWindow (int windowID)
		{

			GUILayout.BeginVertical();
			search = GUILayout.TextField(search);
			scroll = GUILayout.BeginScrollView(scroll);
			if (HighLogic.LoadedScene == GameScenes.LOADING && understood == false)
			{
				
				understood = false;

			}
			else {

				understood = true;

			}
			if (understood)
			{
				foreach (GameObject x in FindObjectsOfType<GameObject>())
				{

					if (search != "" && search != " ")
					{
						if (x.name.ToLower().Contains(search.ToLower()))
						{
							GUILayout.Label(x.name);
						}
					}
					else {

						GUILayout.Label(x.name);

					}

				}
			}
			else {

				GUILayout.Label("Please read the ReadMe.txt");
				GUILayout.Label("for why loading is disabled by default.");

			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();

			GUI.DragWindow();

		}

	}
}

