using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchaRentzBLL.Interfaces.ReusableLogics
{
    public interface IReusableCodeSnippets
    {
        public void SaveDataTemp<T>(T exsistingData, T NewData) where T : class;
    }
}
