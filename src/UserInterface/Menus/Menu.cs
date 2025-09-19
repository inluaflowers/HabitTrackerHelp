using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Menus;
public abstract class Menu
{
    public abstract Selection<T> SetActive<T>();
}

