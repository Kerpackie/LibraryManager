using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Services.FormService
{
    public interface IFormService
    {
        event FormOpenedHandler FormOpened;
        event FormClosedHandler FormClosed;

        void OpenForm<T>() where T : Form;
        void OpenFormWithArgument<T, TArg>(TArg arg) where T : Form;
    }
}
