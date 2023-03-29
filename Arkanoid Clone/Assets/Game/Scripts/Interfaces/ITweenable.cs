public interface ITweenable 
{
    void Tween(TweenType tween);
}
public enum TweenType
{
    lineer,slowDown,pass,bounce
};