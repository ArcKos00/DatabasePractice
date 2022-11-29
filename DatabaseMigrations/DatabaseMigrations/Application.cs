using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Models;
using DatabaseMigrations.Services.Abstractions;

namespace DatabaseMigrations
{
    public class Application
    {
        private readonly ICategoryService _category;
        private readonly ICustomerService _customer;
        private readonly IOrderService _order;
        private readonly IOrderDetailService _orderDetails;
        private readonly IPaymentService _payment;
        private readonly IProductService _product;
        private readonly IShipperService _shipper;
        private readonly ISupplierService _supplier;

        public Application(
            ICategoryService category,
            ICustomerService customer,
            IOrderService order,
            IOrderDetailService orderDetails,
            IPaymentService payment,
            IProductService product,
            IShipperService shipper,
            ISupplierService supplier)
        {
            _category = category;
            _customer = customer;
            _order = order;
            _orderDetails = orderDetails;
            _payment = payment;
            _product = product;
            _shipper = shipper;
            _supplier = supplier;
        }

        public void Start()
        {
            Console.WriteLine("Hello World!");
            var customer1 = _customer.AddCustomerAsync("st.Shevchenko", "sampla@ukr.net", "Volod'ka", "Zelensky", "+380004245324", "KVN95");
            var category1 = _category.AddCategotyAsync("SomeCategory", "Sample", true);
            var supplier1 = _supplier.AddSupplierAsync("SomeCompany", "Peter", "+380884834843", "bebka@ukr.net", new List<Product>());
            var orderDetails1 = _orderDetails.AddOrderDetailsAsync(15, 30f)
            var order1 = _order.AddOrderAsync
            var payment1 = _payment.AddPaymentAsync
                var product1 = _product.AddProductAsync
                var product2 = _product.AddProductAsync
                var shipper1 = _shipper.AddShipperAsync
        }
    }
}
