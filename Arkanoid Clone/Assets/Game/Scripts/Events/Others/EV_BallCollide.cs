namespace Events.Others
{
    public readonly struct EV_BallCollide
    {
        public readonly BallCollisionSide side;
        public EV_BallCollide(BallCollisionSide Side)
        {
            side = Side;
        }
    }
}
