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
        // LineRenderer 의 positionCount가 0이면 true를 반환
        if (_renderer.positionCount == 0)
            return true;

        // 현재 LineRenderer의 마지막 번째의 Position 값과 pos(마우스 Position 값) 사이의 값이 DrawManager에서 설정한 한계 점(0.25f)보다 클 때 true를 반환
        return Vector3.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.LIMIT;
    }
}
