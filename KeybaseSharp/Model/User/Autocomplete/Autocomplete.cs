using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class Autocomplete : BaseObject
    {
        public List<Completion> Completions { get; set; }
    }
}