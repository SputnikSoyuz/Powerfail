using System;
using NewHorizons.Components;
using NewHorizons.Utility;
using UnityEngine;

namespace PowerFail;

public class WarpHandler : MonoBehaviour
{
	public NomaiWarpTransmitterCooldown warpTransmitterCooldown;

    public void Start() 
	{

        warpTransmitterCooldown.enabled = false;
        warpTransmitterCooldown = SearchUtilities.Find("WildsRefuge_Body/Sector/AsteroidWarp").GetComponent<NomaiWarpTransmitterCooldown>();
	}

	public void Update()
	{
		if (Locator.GetToolModeSwapper().GetItemCarryTool().GetHeldItem().name == "Asteroid")
		{
			warpTransmitterCooldown.enabled = true;
		}
		else
		{
			warpTransmitterCooldown.enabled = false;
        }
	}
}
