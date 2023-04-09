namespace Events.Features
{
    public readonly struct EV_EyeValues
    {
        public readonly float EyeScale;
        public readonly float EyePos;
        public EV_EyeValues(float EyeScale, float EyePos)
        {
            this.EyeScale = EyeScale;
            this.EyePos = EyePos;
        }
    }
}