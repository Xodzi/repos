using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor6
{
    public interface IContentFileReader
    {
        void SetSource(string fileName);
        Customer GetCustomer();
        int GetGoodsCount();
        Goods GetNextGood();
        int GetItemsCount();
        Item GetNextItem();
    }
    public class ContentFileReader : IContentFileReader
    {
        private string fileName;
        private TextReader reader;

        public void SetSource(string fileName)
        {
            this.fileName = fileName;
            this.reader = new StreamReader(fileName);
        }

        public Customer GetCustomer()
        {
            string line;
            do
            {
                line = reader.ReadLine();
            } while (line != null && !line.StartsWith("CustomerName:"));

            if (line != null)
            {
                string customerName = line.Split(':')[1].Trim();
                int customerBonus = int.Parse(reader.ReadLine().Split(':')[1].Trim());

                return new Customer(customerName, customerBonus);
            }

            return null;
        }

        public int GetGoodsCount()
        {
            string line;
            do
            {
                line = reader.ReadLine();
            } while (line != null && !line.StartsWith("GoodsTotalCount:"));

            return line != null ? int.Parse(line.Split(':')[1].Trim()) : 0;
        }


        public int GetItemsCount()
        {
            string line;

            TextReader reader = new StreamReader(fileName);
            
            do
            {
                line = reader.ReadLine();
            } while (line != null && !line.StartsWith("ItemsTotalCount:"));

            return line != null ? int.Parse(line.Split(':')[1].Trim()) : 0;
        }


        public Goods GetNextGood()
        {
            string line;
            do
            {
                line = reader.ReadLine();
            } while (line != null && !line.StartsWith("# ID:"));

            if (line != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string[] info = parts[1].Trim().Split(' ');
                    if (info.Length == 3)
                    {
                        string name = info[1];
                        string type = info[2];

                        return new Goods(name, GetPriceCode(type));
                    }
                }
            }

            return null;
        }

        public Item GetNextItem()
        {
            string line;
            do
            {
                line = reader.ReadLine();
            } while (line != null && !line.StartsWith("# ID:"));

            if (line != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string test = reader.ReadLine();
                    string[] info = test.Trim().Split(' ');
                    if (info.Length == 4)
                    {
                        int goodsId = int.Parse(info[1]);
                        double price = double.Parse(info[2]);
                        int quantity = int.Parse(info[3]);

                        Goods goods = GetGoodsById(goodsId);
                        if (goods != null)
                        {
                            return new Item(goods, quantity, price);
                        }
                    }
                }
            }

            return null;
        }

        private Goods GetGoodsById(int goodsId)
        {
            // Здесь вам нужно реализовать логику получения товара по его идентификатору
            // В данном примере просто создается Goods с REGULAR типом цены
            return new RegularGoods($"Товар {goodsId}");
        }

        private int GetPriceCode(string type)
        {
            switch (type)
            {
                case "REG":
                    return 0;
                case "SAL":
                    return 1;
                case "SPO":
                    return 2;
                default:
                    return 0;
            }
        }
    }

}
