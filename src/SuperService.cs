namespace NST.Simple.Api
{
    public class SuperService
    {
        private int value = 1;

        public int GetSavedValue()
        {
            return value;
        }

        public void DoubleSavedValue()
        {
            value = value * 2;
        }
    }
}