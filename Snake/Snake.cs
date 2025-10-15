namespace Snake;

public class Snake
{
    private int _headPositionX =  0;
    private int _headPositionY = 0;
    //private Vector2 _tailPosition =  new Vector2(0, 0);

   public int GetHeadPositionX()
    {
        return _headPositionX;
    }

    public int GetHeadPositionY()
    {
        return _headPositionY;
    }

    public void SetHeadPositionX(int newHeadPositionX)
    {
        _headPositionX = newHeadPositionX;
    }

    public void SetHeadPositionY(int newHeadPositionY)
    {
        _headPositionY = newHeadPositionY;
    }

    public void Initialize()
    {
        _headPositionX = 20;
        _headPositionY = 20;
    }
}