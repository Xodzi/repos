using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor6
{
public class Customer
    {
        private int bonus;
        private String name;
        public Customer(String name, int bonus)
        {
            this.name = name;
            this.bonus = bonus;
        }
        public String getName()
        {
            return name;
        }
        public int getBonus()
        {
            return bonus;
        }
        public void receiveBonus(int bonus)
        {
            this.bonus = bonus;
        }
        public int useBonus(int needBonus)
        {
            int bonusTaken;
            if (needBonus > bonus)
            {
                bonusTaken = bonus;
                bonus = 0;
            }
            else
            {
                bonusTaken = needBonus;
                bonus = bonus - needBonus;
            }
            return bonusTaken;
        }
    }
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            while (items.MoveNext())
            {
                double thisAmount = 0;
                double discount = 0;
                int bonus = 0;
                Item each = (Item)items.Current;
                //определить сумму для каждой строки
                switch (each.getGoods().getPriceCode())
                {
                    case Goods.REGULAR:
                        if (each.getQuantity() > 2)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.03; // 3%
                        bonus =
                       (int)(each.getQuantity() * each.getPrice() * 0.05);
                        break;
                    case Goods.SPECIAL_OFFER:
                        if (each.getQuantity() > 10)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.005; // 0.5%
                        break;
                    case Goods.SALE:
                        if (each.getQuantity() > 3)
                            discount =
                           (each.getQuantity() * each.getPrice()) * 0.01; // 0.1%
                        bonus =
                       (int)(each.getQuantity() * each.getPrice() * 0.01);
                        break;
                }
                // сумма
                thisAmount = each.getQuantity() * each.getPrice();
                // используем бонусы
                if ((each.getGoods().getPriceCode() ==
                Goods.REGULAR) && each.getQuantity() > 5)
                    discount +=
                   _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                if ((each.getGoods().getPriceCode() ==
                Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
                    discount =
                   _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
                // учитываем скидку
                thisAmount =
               each.getQuantity() * each.getPrice() - discount;
                //показать результаты
                result += "\t" + each.getGoods().getTitle() + "\t" +
                "\t" + each.getPrice() + "\t" + each.getQuantity() +
                "\t" + (each.getQuantity() * each.getPrice()).ToString() +
                "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
                "\t" + bonus.ToString() + "\n";
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            //добавить нижний колонтитул
            result += "Сумма счета составляет " +
           totalAmount.ToString() + "\n";
            result += "Вы заработали " +
           totalBonus.ToString() + " бонусных балов";
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
    }
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public double getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }
    }
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
    }
}
