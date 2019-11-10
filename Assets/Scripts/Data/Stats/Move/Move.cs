using UnityEngine;
[System.Serializable]
public class Move : IMove, IClone<Move>
{
    [SerializeField]
    private Speed speed;
    public ISpeed Speed { get { return speed; } }

    public void Init()
    {
        LoadDefault();
    }
    public void LoadDefault()
    {
        Speed.LoadDefault();
    }
    public Move Clone()
    {

        Move move = new Move();
        move.speed = speed.Clone();
        move.Init();
        return move;
    }

}
