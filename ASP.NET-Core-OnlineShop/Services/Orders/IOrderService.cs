namespace ASP.NET_Core_OnlineShop.Services.Orders
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models;

    public interface IOrderService
    {
        public void CreateOrder(Order order);
        public List<string> GetMyOrderId(string Username);

        public List<MyOrdersViewModel> MyOrders(List<string> idmyOrdersId);



    }
}
