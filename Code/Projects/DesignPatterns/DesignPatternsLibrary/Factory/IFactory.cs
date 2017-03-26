using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsLibrary.Factory
{
    public interface IFactory
    {
        string Drive(int miles);
    }
}
