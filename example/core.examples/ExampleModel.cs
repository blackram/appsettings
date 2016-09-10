using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.examples
{
    public class ExampleModel : BaseModel
    {
        public ExampleModel(bool designMode=false) : base(designMode) { }

        public string FirstLine => $"{ApplicationSettings.Title} Black";
        public string SecondLine => $"{ApplicationSettings.Title} White";
    }
}
