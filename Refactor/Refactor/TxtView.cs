using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class TxtView : IView
    {
        private readonly string _directory;

        public TxtView(string directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }
        public TxtView()
        {
            
        }

        public string GetHeader()
        {
            return "Текстовый счет\n";
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            return $"Сумма счета составляет {totalAmount}\nВы заработали {totalBonus} бонусных баллов";
        }

        public string GetItemString(Item item, double discount, double thisAmount, int bonus)
        {
            return $"\t{item.getGoods().getTitle()}\t{item.getPrice()}\t{item.getQuantity()}\t{thisAmount}\t{discount}\t{bonus}\n";
        }

        public void SaveToFile(string fileName, string content)
        {
            string filePath = Path.Combine(_directory, fileName);
            File.WriteAllText(filePath, content);
        }

    }
}
