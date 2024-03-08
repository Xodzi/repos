using Refactor;

namespace TestsLab1
{
    public class UnitTest1
    {

        //[Theory]
        //[InlineData("Cola", Goods.REGULAR, 6, 65, "Pepsi", Goods.SALE, 3, 50, 518.3, 20)]
        //[InlineData("Tea", Goods.REGULAR, 2, 30, "Coffee", Goods.SALE, 5, 40, 248, 5)]
        //[InlineData("Chips", Goods.REGULAR, 3, 20, "Chocolate", Goods.SALE, 8, 25, 246.2, 5)]
        //[InlineData("Milk", Goods.REGULAR, 1, 2.5, "Bread", Goods.REGULAR, 3, 1.8, 2.7380000000000004, 0)]
        //[InlineData("Laptop", Goods.SPECIAL_OFFER, 2, 800, "Mouse", Goods.SPECIAL_OFFER, 1, 25, 1625, 0)]
        //[InlineData("Headphones", Goods.REGULAR, 2, 50, "Phone", Goods.SALE, 1, 300, 400, 8)]
        //[InlineData("Pizza", Goods.SALE, 3, 15, "Soda", Goods.SALE, 4, 5, 54.8, 0)]
        //[InlineData("Pen", Goods.REGULAR, 5, 1, "Notebook", Goods.REGULAR, 2, 3, 6.85, 0)]
        //[InlineData("Chair", Goods.REGULAR, 1, 50, "Table", Goods.REGULAR, 1, 80, 130, 6)]
        //[InlineData("Hat", Goods.REGULAR, 4, 10, "Sunglasses", Goods.SPECIAL_OFFER, 2, 15, 58.8, 2)]
        //[InlineData("T-shirt", Goods.SPECIAL_OFFER, 12, 20, "Jeans", Goods.SALE, 3, 40, 358.8, 1)]
        //// еще случаи
        //public void CalculateTotalAmountAndBonus(
        //string goods1Title, int goods1PriceCode, int quantity1, double price1,
        //string goods2Title, int goods2PriceCode, int quantity2, double price2,
        //double expectedTotalAmount, int expectedTotalBonus)
        //{
        //    //arrange
        //    Goods goods1 = new Goods(goods1Title, goods1PriceCode);
        //    Goods goods2 = new Goods(goods2Title, goods2PriceCode);

        //    Item item1 = new Item(goods1, quantity1, price1);
        //    Item item2 = new Item(goods2, quantity2, price2);

        //    Customer customer = new Customer("test", 10);

        //    Customer customer2 = new Customer("test", 10);

        //    Bill bill = new Bill(customer);
        //    //act
        //    bill.addGoods(item1);
        //    bill.addGoods(item2);

        //    Bill bill2 = new Bill(customer2);
        //    bill2.addGoods(item1);
        //    bill2.addGoods(item2);

        //    //string actualStatement = bill.statement();
        //    //string expectedStatement = bill.statement_New();
        //    string expectedStatement = bill2.statement_New();


        //    //result
        //    Assert.Equal(expectedTotalAmount, bill2.TotalAmount);
        //    Assert.Equal(expectedTotalBonus, bill2.TotalBonus);
        //}
        [Theory]
        [InlineData("Cola", typeof(RegularGoods), 6, 65, "Pepsi", typeof(SaleGoods), 3, 50, 518.3, 20)]
        [InlineData("Tea", typeof(RegularGoods), 2, 30, "Coffee", typeof(SaleGoods), 5, 40, 248, 5)]
        [InlineData("Chips", typeof(RegularGoods), 3, 20, "Chocolate", typeof(SaleGoods), 8, 25, 246.2, 5)]
        [InlineData("Milk", typeof(RegularGoods), 1, 2.5, "Bread", typeof(RegularGoods), 3, 1.8, 2.7380000000000004, 0)]
        [InlineData("Laptop", typeof(SpecialGoods), 2, 800, "Mouse", typeof(SpecialGoods), 1, 25, 1625, 0)]
        [InlineData("Headphones", typeof(RegularGoods), 2, 50, "Phone", typeof(SaleGoods), 1, 300, 400, 8)]
        [InlineData("Pizza", typeof(SaleGoods), 3, 15, "Soda", typeof(SaleGoods), 4, 5, 54.8, 0)]
        [InlineData("Pen", typeof(RegularGoods), 5, 1, "Notebook", typeof(RegularGoods), 2, 3, 6.85, 0)]
        [InlineData("Chair", typeof(RegularGoods), 1, 50, "Table", typeof(RegularGoods), 1, 80, 130, 6)]
        [InlineData("Hat", typeof(RegularGoods), 4, 10, "Sunglasses", typeof(SpecialGoods), 2, 15, 58.8, 2)]
        [InlineData("T-shirt", typeof(SpecialGoods), 12, 20, "Jeans", typeof(SaleGoods), 3, 40, 358.8, 1)]
        public void CalculateTotalAmountAndBonus(
        string goods1Title, Type goods1Type, int quantity1, double price1,
        string goods2Title, Type goods2Type, int quantity2, double price2,
        double expectedTotalAmount, int expectedTotalBonus)
        {
            //arrange
            Goods goods1 = CreateGoods(goods1Title, goods1Type);
            Goods goods2 = CreateGoods(goods2Title, goods2Type);

            Item item1 = new Item(goods1, quantity1, price1);
            Item item2 = new Item(goods2, quantity2, price2);

            Customer customer = new Customer("test", 10);

            IView view = new TxtView();

            Bill bill = new Bill(customer, view);
            //act
            bill.addGoods(item1);
            bill.addGoods(item2);

            //string actualStatement = bill.statement();
            // Ваш тестовый метод, который должен возвращать ожидаемый результат

            //string expectedStatement = bill.Process();
            BillSummary billSummary = bill.Process();

            //result
            Assert.Equal(expectedTotalAmount, billSummary.TotalAmount, 2);
            Assert.Equal(expectedTotalBonus, billSummary.TotalBonus);
            //Assert.Equal(expectedStatement, actualStatement);
        }

        private Goods CreateGoods(string title, Type type)
        {
            if (type == typeof(RegularGoods))
            {
                return new RegularGoods(title);
            }
            else if (type == typeof(SpecialGoods))
            {
                return new SpecialGoods(title);
            }
            else if (type == typeof(SaleGoods))
            {
                return new SaleGoods(title);
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, "Unsupported Goods Type");
        }
    }
}