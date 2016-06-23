For the safety of those who have medical conditions which cause them to be sensitive to flashing images, etc, the viewer is disabled by default during the initial loading screen.  To enable it, type "understood" into the search bar.  Once removed, it will work as normal.

To keep it enabled, a plugin can reference the public bool "understood" by using the following code:
GameObject.Find("GOLF").GetComponent<GOLF>().enabled = true;
