using Refactor;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

//Goods cola = new Goods("Cola", Goods.REGULAR);
//Goods pepsi = new Goods("Pepsi", Goods.SALE);
RegularGoods cola_new = new RegularGoods("Cola");
SaleGoods pepsi_new = new SaleGoods("Pepsi");

//Item i1 = new Item(cola, 6, 65);
//Item i2 = new Item(pepsi, 3, 50);

HtmlView view = new HtmlView(".");

Item i1_new = new Item(cola_new, 6, 65);
Item i2_new = new Item(pepsi_new, 3, 50);

Customer x = new Customer("test", 10);
Customer y = new Customer("test", 10);
//act
//Bill b1 = new Bill(x);
//b1.addGoods(i1);
//b1.addGoods(i2);

Bill b2 = new Bill(y, view);
b2.addGoods(i1_new);
b2.addGoods(i2_new);
view.SaveToFile("bill.html",b2.GetBill());

//string bill = b1.statement();

//Console.WriteLine(b1.statement_New());

Console.WriteLine(b2.GetBill());

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
    public List<Item> _items { get; private set; }
    public Customer _customer { get; private set; }
    IView _view { get; set; }

    public double TotalAmount { get; set; }

    public int TotalBonus { get; set; }
    public Bill(Customer customer, IView view)
    {
        this._customer = customer;
        this._items = new List<Item>();
        _view = view;
    }
    public void addGoods(Item arg)
    {
        _items.Add(arg);
    }
    //public string statement()
    //{
    //    double totalAmount = 0;
    //    int totalBonus = 0;
    //    List<Item>.Enumerator items = _items.GetEnumerator();
    //    string result = "Счет для " + _customer.getName() + "\n";
    //    result += "\t" + "Название" + "\t" + "Цена" +
    //    "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
    //    "\t" + "Сумма" + "\t" + "Бонус" + "\n";
    //    while (items.MoveNext())
    //    {
    //        double thisAmount = 0;
    //        double discount = 0;
    //        int bonus = 0;
    //        Item each = (Item)items.Current;
    //        //определить сумму для каждой строки
    //        switch (each.getGoods().getPriceCode())
    //        {
    //            case Goods.REGULAR:
    //                if (each.getQuantity() > 2)
    //                    discount =
    //                    (GetSum(each)) * 0.03; // 3%
    //                bonus =
    //                (int)(GetSum(each) * 0.05);
    //                break;
    //            case Goods.SPECIAL_OFFER:
    //                if (each.getQuantity() > 10)
    //                    discount =
    //                    (GetSum(each)) * 0.005; // 0.5%
    //                break;
    //            case Goods.SALE:
    //                if (each.getQuantity() > 3)
    //                    discount =
    //                    (GetSum(each)) * 0.01; // 0.1%
    //                bonus =
    //                (int)(GetSum(each) * 0.01);
    //                break;
    //        }
    //        // сумма
    //        thisAmount = each.getQuantity() * each.getPrice();
    //        // используем бонусы
    //        if ((each.getGoods().getPriceCode() ==
    //        Goods.REGULAR) && each.getQuantity() > 5)
    //            discount +=
    //            _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
    //        if ((each.getGoods().getPriceCode() ==
    //        Goods.SPECIAL_OFFER) && each.getQuantity() > 1)
    //            discount =
    //            _customer.useBonus((int)(each.getQuantity() * each.getPrice()));
    //        // учитываем скидку
    //        thisAmount =
    //        each.getQuantity() * each.getPrice() - discount;
    //        //показать результаты
    //        result += "\t" + each.getGoods().getTitle() + "\t" +
    //        "\t" + each.getPrice() + "\t" + each.getQuantity() +
    //        "\t" + (each.getQuantity() * each.getPrice()).ToString() +
    //        "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
    //        "\t" + bonus.ToString() + "\n";
    //        totalAmount += thisAmount;
    //        totalBonus += bonus;
    //    }
    //    //добавить нижний колонтитул
    //    result += "Сумма счета составляет " +
    //    totalAmount.ToString() + "\n";
    //    result += "Вы заработали " +
    //    totalBonus.ToString() + " бонусных балов";
    //    TotalAmount = totalAmount;
    //    TotalBonus = totalBonus;
    //    //Запомнить бонус клиента
    //    _customer.receiveBonus(totalBonus);
    //    return result;
    //}
    public string GetBill()
    {
        double totalAmount = 0;
        int totalBonus = 0;
        List<Item>.Enumerator items = _items.GetEnumerator();
        string result = _view.GetHeader();
        while (items.MoveNext())
        {
            Item each = (Item)items.Current;
            double thisAmount = each.GetSum();


            int bonus = each.GetBonus();
            //int test_bonus = GetBonus(each);

            double discount = each.GetDiscount(_customer);
            //double test_dis = GetDiscount(each);

            // учитываем скидку
            thisAmount -= discount;

            //показать результаты
            result += _view.GetItemString(each, discount, thisAmount, bonus);
            totalAmount += thisAmount;
            totalBonus += bonus;
        }
        //добавить нижний колонтитул
        result += _view.GetFooter(totalAmount, totalBonus);
        TotalAmount = totalAmount;
        TotalBonus = totalBonus;
        //Запомнить бонус клиента
        _customer.receiveBonus(totalBonus);
        return result;
    }

    public BillSummary Process()
    {
        BillGenerator billGenerator = new BillGenerator(this, _view);
        return billGenerator.Process();
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
    public int GetBonus()
    {
        return _Goods.GetBonus( _quantity, _price);
    }
    public double GetDiscount(Customer _customer)
    {
        return _Goods.GetDiscount(_quantity, _price, _customer);
    }
    public double GetSum()
    {
        return _quantity * _price;
    }

}

public class Goods
{
    //public const int REGULAR = 0;
    //public const int SALE = 1;
    //public const int SPECIAL_OFFER = 2;
    private String _title;
    public Goods(string title)
    {
        _title = title;
    }
    //public int getPriceCode()
    //{
    //    return _priceCode;
    //}
    //public void setPriceCode(int arg)
    //{
    //    _priceCode = arg;
    //}
    public String getTitle()
    {
        return _title;
    }
    public virtual int GetBonus(int _quantity, double _price)
    {
        return 0;
        //int bonus = 0;

        //switch (_priceCode)
        //{
        //    case Goods.REGULAR:
        //        bonus = (int)(GetSum(_quantity, _price) * 0.05);
        //        break;
        //    case Goods.SALE:
        //        bonus = (int)(GetSum(_quantity, _price) * 0.01);
        //        break;
        //}

        //return bonus;
    }
    public virtual double GetDiscount(int _quantity, double _price, Customer _customer)
    {
        return 0;
        //double discount = 0;

        //switch (_priceCode)
        //{
        //    case Goods.REGULAR:
        //        if (_quantity > 2)
        //        {
        //            double itemSum = GetSum(_quantity, _price);
        //            discount = itemSum * 0.03;
        //            double sumWithDiscount = itemSum - discount;
        //            // Используем бонусы
        //            discount += GetUsedBonus(sumWithDiscount, _customer);
        //        }
        //        break;
        //    case Goods.SPECIAL_OFFER:
        //        if (_quantity > 10)
        //            discount = GetSum(_quantity, _price) * 0.005;
        //        break;
        //    case Goods.SALE:
        //        if (_quantity > 3)
        //        {
        //            double itemSum = GetSum(_quantity, _price);
        //            discount = itemSum * 0.01;
        //            double sumWithDiscount = itemSum - discount;
        //            // Используем бонусы
        //            discount += GetUsedBonus(sumWithDiscount, _customer);
        //        }
        //        break;
        //}

        //return discount;
    }
    public double GetSum(int _quantity, double _price)
    {
        return _quantity * _price;
    }
    public int GetUsedBonus(double discountedAmount, Customer _customer)
    {
        int usedBonus = _customer.useBonus((int)discountedAmount);
        return usedBonus;
    }
}
public class RegularGoods : Goods
{
    public RegularGoods(string title) : base(title)
    {
    }
    public override int GetBonus(int _quantity, double _price)
    {
        return (int)(GetSum(_quantity, _price) * 0.05);
    }
    public override double GetDiscount(int _quantity, double _price, Customer _customer)
    {
        double discount = 0;
        if (_quantity > 2)
        {
            double itemSum = GetSum(_quantity, _price);
            discount = itemSum * 0.03;
            double sumWithDiscount = itemSum - discount;
            // Используем бонусы
            discount += GetUsedBonus(sumWithDiscount, _customer);
        }
        return discount;
    }
}
public class SpecialGoods : Goods
{
    public SpecialGoods(string title) : base(title)
    {
    }
    public override int GetBonus(int _quantity, double _price)
    {
        return 0;
    }
    public override double GetDiscount(int _quantity, double _price, Customer _customer)
    {
        double discount = 0;
        if (_quantity > 10)
            discount = GetSum(_quantity, _price) * 0.005;
        return discount;
    }
}
public class SaleGoods : Goods
{
    public SaleGoods(string title) : base(title)
    {
    }
    public override int GetBonus(int _quantity, double _price)
    {
        return (int)(GetSum(_quantity, _price) * 0.01);
    }
    public override double GetDiscount(int _quantity, double _price, Customer _customer)
    {
        double discount = 0;
        if (_quantity > 3)
        {
            double itemSum = GetSum(_quantity, _price);
            discount = itemSum * 0.01;
            double sumWithDiscount = itemSum - discount;
            // Используем бонусы
            discount += GetUsedBonus(sumWithDiscount, _customer);
        }
        return discount;
    }
}

