using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Services.FormService
{
    public delegate void FormOpenedHandler(object sender, EventArgs e, Form openedForm);
    public delegate void FormClosedHandler(object sender, EventArgs e, Form closedFormName);
}
