using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor
{
    public class BillGenerator
    {
        private readonly Bill _bill;
        private readonly IView _view;

        public BillGenerator(Bill bill, IView view)
        {
            _bill = bill ?? throw new ArgumentNullException(nameof(bill));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public BillSummary Process()
        {
            BillSummary billSummary = new BillSummary();

            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _bill._items.GetEnumerator();
            string result = _view.GetHeader();
            while (items.MoveNext())
            {
                Item each = (Item)items.Current;
                double thisAmount = each.GetSum();


                int bonus = each.GetBonus();
                //int test_bonus = GetBonus(each);

                double discount = each.GetDiscount(_bill._customer);
                //double test_dis = GetDiscount(each);

                // учитываем скидку
                thisAmount -= discount;

                //показать результаты
                result += _view.GetItemString(each, discount, thisAmount, bonus);
                totalAmount += thisAmount;
                totalBonus += bonus;

                ItemSummary itemSummary = new ItemSummary
                {
                    Title = each.getGoods().getTitle(),
                    Price = each.getPrice(),
                    Quantity = each.getQuantity(),
                    Total = thisAmount,
                    Discount = discount,
                    Bonus = bonus
                };
                billSummary.Items.Add(itemSummary);

            }
            //добавить нижний колонтитул
            result += _view.GetFooter(totalAmount, totalBonus);
            billSummary.TotalAmount = totalAmount;
            billSummary.TotalBonus = totalBonus;
            //Запомнить бонус клиента
            _bill._customer.receiveBonus(totalBonus);
            return billSummary;
        }
    }

}
