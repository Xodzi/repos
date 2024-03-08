using Refactor6;
using System.ComponentModel.Design;

namespace RefactorTests6
{
    public class UnitTest1
    {
        private IContentFileReader contentFileReader;

        public class BillTests
        {
            [Theory]
            [InlineData("test1.yaml", "John", 50, 2, 2, 110, 5)]
            [InlineData("test2.yaml", "Alice", 20, 3, 3, 1400, 70)]
            [InlineData("test3.yaml", "Bob", 0, 1, 1, 80, 0)]
            [InlineData("test4.yaml", "Emma", 15, 4, 4, 435, 20)]
            [InlineData("test5.yaml", "David", 30, 2, 2, 111, 12)]
            public void TestCreateBill(string input, string expectedCustomerName, int expectedCustomerBonus, int expectedGoodsCount, int expectedItemsCount, double expectedTotalAmount, int expectedTotalBonus)
            {
                ContentFileReader contentFileReader = new ContentFileReader();
                contentFileReader.SetSource(input);

                Customer customer = contentFileReader.GetCustomer();
                List<Item> items = ReadItems(contentFileReader);
                BillFactory billFactory = new BillFactory();
                TextReader textReader = new StreamReader(input);
                Bill bill = billFactory.CreateBill(contentFileReader, textReader);
                foreach (var item in items)
                {
                    bill.addGoods(item);
                }

                string statement = bill.statement();

                Assert.NotNull(customer);
                Assert.Equal(expectedCustomerName, customer.getName());
                Assert.Equal(expectedCustomerBonus, customer.getBonus());
                var stop = contentFileReader.GetItemsCount();
                Assert.Equal(expectedItemsCount, contentFileReader.GetItemsCount());
            }

            private List<Item> ReadItems(IContentFileReader contentFileReader)
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
        }
    }
}
