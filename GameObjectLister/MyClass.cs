using System;
using System.Collections.Generic;
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
		bool destroy = false;

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
			if (destroy)
			{

				GUILayout.Label("Select object to destroy");

			}
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
				List<GameObject> GameObjects = new List<GameObject>( FindObjectsOfType<GameObject>());
				for (int i = GameObjects.Count - 1; i >= 0; --i)
				{

					GameObject x = GameObjects[i];

					if (search != "" && search != " ")
					{
						if (x.name.ToLower().Contains(search.ToLower()))
						{

							if (destroy == false)
							{
								GUILayout.Label(x.name);
							}
							else {

								if (GUILayout.Button(x.name))
								{

									Destroy(x);

								}

							}

						}
					}
					else {

						if (destroy == false)
						{
							GUILayout.Label(x.name);
						}
						else {

							if (GUILayout.Button(x.name))
							{

								Destroy(x);

							}

						}

					}

				}
			}
			else {

				GUILayout.Label("Please read the ReadMe.txt");
				GUILayout.Label("for why loading is disabled by default.");

			}
			GUILayout.EndScrollView();
			destroy = GUILayout.Toggle(destroy, "Destroy mode");
			GUILayout.EndVertical();

			GUI.DragWindow();

		}

	}
}

