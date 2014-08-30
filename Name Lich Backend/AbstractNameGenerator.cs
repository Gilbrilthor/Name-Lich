namespace Name_Lich_Backend
{
    public abstract class AbstractNameGenerator
    {
        public string NameType
        {
            get
            {
                return getNameType();
            }
            set
            {
            }
        }

        public abstract string GenerateName();

        public override string ToString()
        {
            return string.Format("{0}",
                NameType);
        }

        protected abstract string getNameType();
    }
}