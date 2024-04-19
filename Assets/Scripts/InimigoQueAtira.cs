using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoQueAtira : Inimigo
{
    protected override void Anda()
    {
        if (Vector2.Distance(Player.Instance.transform.position, transform.position) > 5) { base.Anda(); }
        else {
            rb.velocity = (Player.Instance.transform.position - transform.position) * -1 / 2;
        }

        Rotate();
    }

    void Rotate()
    {
        Vector3 diff = Player.Instance.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    void Atira()
    {
        Debug.Log("PEW PEW PEW");
    }

    protected override void Update()
    {
        base.Update();
        Atira();
    }
}
