using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor6
{
    public class GoodsFactory
    {
        public Goods Create(string title, string priceCode)
        {
            // В зависимости от переданного кода цены, создаем соответствующий объект Goods
            switch (priceCode)
            {
                case "REGULAR":
                    return new RegularGoods(title);
                case "SALE":
                    return new SaleGoods(title);
                case "SPECIAL_OFFER":
                    return new SpecialOfferGoods(title);
                default:
                    // Возможно, следует бросить исключение, если код цены не распознан
                    return null;
            }
        }
    }

    // RegularGoods.cs

    public class RegularGoods : Goods
    {
        public RegularGoods(string title) : base(title, 0)
        {
            // Дополнительная логика для создания товара с ценой REGULAR
        }
    }

    // SaleGoods.cs

    public class SaleGoods : Goods
    {
        public SaleGoods(string title) : base(title, 1)
        {
            // Дополнительная логика для создания товара с ценой SALE
        }
    }

    // SpecialOfferGoods.cs

    public class SpecialOfferGoods : Goods
    {
        public SpecialOfferGoods(string title) : base(title, 2)
        {
            // Дополнительная логика для создания товара с ценой SPECIAL_OFFER
        }
    }

}
