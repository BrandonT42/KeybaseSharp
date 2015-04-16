using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class UserAutocomplete : BaseObject
    {
        public List<Completion> Completions { get; set; }
    }
}