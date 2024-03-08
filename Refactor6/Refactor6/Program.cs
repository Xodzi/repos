using Refactor6;

internal class Program
{
    public static void Main()
    {
        // Создаем экземпляр ContentFileReader
        IContentFileReader contentFileReader = new ContentFileReader();

        // Устанавливаем источник данных (файл example.txt)
        string filename = "BillInfo.yaml";
        contentFileReader.SetSource(filename);

        // Получаем данные из файла
        Customer customer = contentFileReader.GetCustomer();
        List<Item> items = ReadItems(contentFileReader);

        // Создаем объект Bill
        Bill bill = new Bill(customer);
        foreach (var item in items)
        {
            bill.addGoods(item);
        }

        // Выводим результат на экран
        Console.WriteLine(bill.statement());
    }

    private static List<Item> ReadItems(IContentFileReader contentFileReader)
    {
        List<Item> items = new List<Item>();
        int itemsCount = contentFileReader.GetItemsCount();

        for (int i = 0; i < itemsCount; i++)
        {
            Item item = contentFileReader.GetNextItem();
            if (item != null)
            {
                items.Add(item);
            }
        }

        return items;
    }

    public static Bill CreateBill(TextReader sr)
    {
        // read customer
        var content = new ContentFileReader();
        content.SetSource("BillInfo.yaml");
        string line = sr.ReadLine();
        string[] result = line.Split(':');
        string name = result[1].Trim();
        // read bonus
        line = sr.ReadLine();
        result = line.Split(':');
        int bonus = Convert.ToInt32(result[1].Trim());
        Customer customer = new Customer(name, bonus);
        Bill b = new Bill(customer);
        // read goods count
        line = sr.ReadLine();
        result = line.Split(':');
        int goodsQty = Convert.ToInt32(result[1].Trim());
        Goods[] g = new Goods[goodsQty];
        for (int i = 0; i < g.Length; i++)
        {
            // Пропустить комментарии
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            result = result[1].Trim().Split();
            string type = result[1].Trim();
            int t = 0;
            switch (type)
            {
                case "REG":
                    t = Goods.REGULAR;
                    break;
                case "SAL":
                    t = Goods.SALE;
                    break;
                case "SPO":
                    t = Goods.SPECIAL_OFFER;
                    break;
            }
            g[i] = new Goods(result[0], t);
        }
        // read items count
        // Пропустить комментарии
        do
        {
            line = sr.ReadLine();
        } while (line.StartsWith("#"));
        result = line.Split(':');
        int itemsQty = Convert.ToInt32(result[1].Trim());
        for (int i = 0; i < itemsQty; i++)
        {
            // Пропустить комментарии
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            result = line.Split(':');
            result = result[1].Trim().Split();
            int gid = Convert.ToInt32(result[0].Trim());
            double price = Convert.ToDouble(result[1].Trim());
            int qty = Convert.ToInt32(result[2].Trim());
            b.addGoods(new Item(g[gid - 1], qty, price));
        }
        return b;
    }
}