namespace MonoDevelop.GapHighlighting.Suggest
{
    public interface ICharValidator
    {
        bool IsCharValid(char charToValidate);
    }

    public class CharValidator : ICharValidator
    {
        private const char ground = '_';

        public bool IsCharValid(char charToValidate)
        {
            return char.IsLetterOrDigit(charToValidate) || charToValidate == ground;
        } 
    }
}