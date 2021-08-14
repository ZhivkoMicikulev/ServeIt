namespace ServeIt.Services.Data.Helper
{
    public class HelperService : IHelperService
    {
        public string MakeFirstLetterCapital(string word)
        {
            var result = char.ToUpper(word[0]) + word.Substring(1);
            return result;
        }
    }
}
