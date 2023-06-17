using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public LineRenderer _renderer;

    public void SetPosition(Vector3 pos)
    {
        if (!CanAppend(pos))
            return;

        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    private bool CanAppend(Vector3 pos)
    {
        // LineRenderer �� positionCount�� 0�̸� true�� ��ȯ
        if (_renderer.positionCount == 0)
            return true;

        // ���� LineRenderer�� ������ ��°�� Position ���� pos(���콺 Position ��) ������ ���� DrawManager���� ������ �Ѱ� ��(0.25f)���� Ŭ �� true�� ��ȯ
        return Vector3.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.LIMIT;
    }
}
