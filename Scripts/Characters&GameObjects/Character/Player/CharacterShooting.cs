using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    private bool ShootViaLMB, ShootViaSpaceBar;

    private void Update()
    {
        ShootViaLMB = Input.GetMouseButtonDown(0);
        ShootViaSpaceBar = Input.GetKeyDown(KeyCode.Space);

        if (ShootViaLMB || ShootViaSpaceBar)
        {
            if (FindObjectOfType<PauseButton>().IsPaused == false)
            Invoke(nameof(SimpleShoot), 0.3f);
        }
    }

    private void SimpleShoot()
    {
        FindObjectOfType<BulletSpawnSystem>().BulletRun(GetComponent<Transform>());
    }
}
