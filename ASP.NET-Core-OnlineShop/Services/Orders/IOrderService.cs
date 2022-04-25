namespace ASP.NET_Core_OnlineShop.Services.Orders
{
    using System.Collections.Generic;
    using ASP.NET_Core_OnlineShop.Data.Models;
    using ASP.NET_Core_OnlineShop.Models;
    using ASP.NET_Core_OnlineShop.Models.Orders;
    public interface IOrderService
    {
        public void CreateOrder(OrdersFormViewModel order);
        public List<string> GetMyOrderId(string Username);

        public List<MyOrdersViewModel> MyOrders(List<string> idmyOrdersId);



    }
}
