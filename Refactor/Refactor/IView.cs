using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public interface IView
    {
        string GetHeader();
        string GetFooter(double totalAmount, int totalBonus);
        string GetItemString(Item item, double discount, double thisAmount, int bonus);
    }
}
