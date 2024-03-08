using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class HtmlView : IView
    {
        private readonly string _directory;

        public HtmlView(string directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }
        public HtmlView()
        {
            
        }

        public string GetHeader()
        {
            return "<html><body><h1>HTML счет</h1><ul>";
        }

        public string GetFooter(double totalAmount, int totalBonus)
        {
            return $"</ul><p>Сумма счета составляет {totalAmount}</p><p>Вы заработали {totalBonus} бонусных баллов</p></body></html>";
        }

        public string GetItemString(Item item, double discount, double thisAmount, int bonus)
        {
            return $"<li>{item.getGoods().getTitle()} - {item.getPrice()} - {item.getQuantity()} - {thisAmount} - {discount} - {bonus}</li>";
        }

        public void SaveToFile(string fileName, string content)
        {
            string filePath = Path.Combine(_directory, fileName);
            File.WriteAllText(filePath, content);
        }
    }
}
