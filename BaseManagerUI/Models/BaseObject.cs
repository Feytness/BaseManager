namespace BaseManagerUI.Models
{
    internal abstract class BaseObject
    {
        public List<string> Names { get; set; }

        public abstract string DisplayInfo();
    }
}